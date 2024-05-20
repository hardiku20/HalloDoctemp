$(document).ready(function () {


    //-------------------- initial data ---------------------------------

    reload();

    //----------------------------------------- view file ---------------------------------------------            
    $('#invoiceReceiptData,#invoiceData').on('click', '.receiptView', function () {
        var fileName = $(this).attr('value');
        var url = "/Admin/GetInvoiceByName?fileName=" + fileName;
        window.open(url, "_blank");
    });


    //----------------------------------------- approve invoice ---------------------------------------------            
    $('#invoiceData').on('click', '.approveTimeSheet', function () {
        var timeSheetId = sessionStorage.getItem('timeSheetIdInvoiceAdmin');
        var bonus = $(this).closest('.row').find('.bonus').val();
        var description = $(this).closest('.row').find('.description').val();
        $.ajax({
            url: '/Admin/ApproveTimesheet',
            method: 'POST',
            data: { timeSheetId: timeSheetId, bonus: bonus, description: description },
            success: function (response) {
                if (response) {
                    $('.backtoinvoice').click();
                    showToast('Invoice Approved');
                } else {
                    showToastDanger('Error in Approving invoice');
                }
            },
            error: function (xhr, status, error) {
                if (xhr.status === 400) {
                    window.location.href = '/Home/patientsite';

                }
            }
        });
    });


    $('#invoiceData').on('click', '.approveTimeSheetPage', function () {
        var timeSheetId = $(this).closest('tr').attr('value');
        InvoiceSheetAdmin(timeSheetId);
    });

    //----------------------------------  back to invoice ------------------------------------
    $('#invoiceData').on('click', '.backtoinvoice', function () {
        sessionStorage.removeItem('pageNameInvoice');
        reload();
    });

    //----------------------------------  Add receipt view  ------------------------------------
    $('#invoiceData').on('click', '.addReceipt', function () {
        if ($('#invoiceReceiptData').children().length == 0) {
            var timeSheetId = sessionStorage.getItem('timeSheetIdInvoiceAdmin');
            InvoiceReceiptAdmin(timeSheetId);
        } else {
            $('#invoiceReceiptData').empty();
        }
    });

    $('#invoiceData').on('change', '#sheetDateSelect', function () {
        var firstDate = $('#sheetDateSelect').find(':selected').attr('data-firstDate');
        var lastDate = $('#sheetDateSelect').find(':selected').attr('data-lastDate');
        sessionStorage.setItem('firstDateInvoice', firstDate);
        sessionStorage.setItem('lastDateInvoice', lastDate);
        sessionStorage.setItem('selectedPeriodInvoice', $('#sheetDateSelect').val());
        var providerId = sessionStorage.getItem('providerIdAdminInvoice');
        if (firstDate == null || lastDate == null || firstDate == undefined || lastDate == undefined || !providerId > 0) {
            return;
        }
        InvoiceAdmin(providerId, firstDate, lastDate);
    });

    $('#invoiceData').on('change', '#physicianSelect', function () {
        var providerId = $(this).val();
        sessionStorage.setItem('providerIdAdminInvoice', providerId);
        var firstDate = sessionStorage.getItem('firstDateInvoice');
        var lastDate = sessionStorage.getItem('lastDateInvoice');
        if (firstDate == null || lastDate == null || !providerId > 0) {
            return;
        }
        InvoiceAdmin(providerId, firstDate, lastDate);
    });


    //--------------------------------------------------------- update invoice sheet data --------------------------
    $('#invoiceData').on('click', '.updateInvoiceSheetData', function () {
        var data = GetTableData();
        var sheetData = JSON.stringify(data);
        $.ajax({
            url: '/Admin/UpdateInvoiceSheetDataAdmin',
            method: 'POST',
            data: sheetData,
            contentType: 'application/json',
            success: function (response) {
                if (response) {
                    var timeSheetId = sessionStorage.getItem('timeSheetIdInvoiceAdmin');
                    InvoiceSheetDataAdmin(timeSheetId);

                } else {

                }
            },
            error: function (xhr, status, error) {
                if (xhr.status === 400) {
                    window.location.href = '/Home/patientsite';

                }
            }
        });

    });





});

function reload() {
    var pageName = sessionStorage.getItem("pageNameInvoice");
    var firstDate = sessionStorage.getItem('firstDateInvoice');
    var lastDate = sessionStorage.getItem('lastDateInvoice');
    var providerId = sessionStorage.getItem('providerIdAdminInvoice');

    switch (pageName) {
        case 'InvoiceSheetAdmin':
            var timeSheetId = sessionStorage.getItem('timeSheetIdInvoiceAdmin');
            InvoiceSheetAdmin(timeSheetId);
            break;
        default:
            InvoiceAdmin(providerId, firstDate, lastDate);
            break;
    }
}


function InvoiceAdmin(providerId, firstDate, lastDate) {

    $.ajax({
        url: '/Admin/InvoicePartialView',
        method: 'POST',
        data: { providerId: providerId, firstDate: firstDate, lastDate: lastDate },
        success: function (response) {
            $('#invoiceData').html(response);
            var periodValue = sessionStorage.getItem('selectedPeriodInvoice');
            if (periodValue == null) periodValue = 0;
            $('#sheetDateSelect').val(periodValue);

            var providerId = sessionStorage.getItem('providerIdAdminInvoice');
            if (providerId == null) providerId = 0;
            $('#physicianSelect').val(providerId);

        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
                window.location.href = '/Home/patientsite';

            }
        }
    });
}

function InvoiceSheetAdmin(timeSheetId) {

    $.ajax({
        url: '/Admin/InvoiceSheet',
        method: 'POST',
        success: function (response) {
            $('#invoiceData').html(response);

            InvoiceSheetDataAdmin(timeSheetId);
            sessionStorage.setItem('pageNameInvoice', 'InvoiceSheetAdmin');
            sessionStorage.setItem('timeSheetIdInvoiceAdmin', timeSheetId);
        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
                window.location.href = '/Home/patientsite';

            }
        }
    });
}

function InvoiceSheetDataAdmin(timeSheetId) {
    $.ajax({
        url: '/Admin/InvoiceSheetDataAdmin',
        method: 'POST',
        data: { timeSheetId: timeSheetId },
        success: function (response) {
            $('#invoiceSheetData').html(response);
        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
                window.location.href = '/Home/patientsite';
            }
        }
    });
}

function InvoiceReceiptAdmin(timeSheetId) {

    $.ajax({
        url: '/Admin/InvoiceReceiptAdmin',
        method: 'POST',
        data: { timeSheetId: timeSheetId },
        success: function (response) {
            $('#invoiceReceiptData').html(response);
            $('.disInput').prop('disabled', true);

        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
                window.location.href = '/Home/patientsite';
            }
        }
    });
}


function GetTableData() {
    var data = [];
    $('#invoiceSheetTable tbody tr').slice(0, -2).each(function () {
        var rowData = {
            TotalHours: $(this).find('td:eq(2) input:eq(0)').val(),
            TimesheetDetailId: $(this).find('td:eq(2) input:eq(1)').val(),
            IsWeekend: $(this).find('td:eq(3) input').prop('checked'),
            Housecall: $(this).find('td:eq(4) input').val(),
            PhoneConsult: $(this).find('td:eq(5) input').val()
        };

        data.push(rowData);
    });
    return data;
}



