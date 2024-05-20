$(document).ready(function () {


    //-------------------- initial data ---------------------------------

    reload();

    //----------------------------------------- view file ---------------------------------------------            
    $('#invoiceReceiptData,#invoiceData').on('click', '.receiptView', function () {
        var fileName = $(this).attr('value');
        var url = "/Provider/GetInvoiceByName?fileName=" + fileName;
        window.open(url, "_blank");
    });

    //----------------------------------------- finalize invoice ---------------------------------------------            
    $('#invoiceData').on('click', '.finalizeInvoice', function () {
        var firstDate = sessionStorage.getItem('firstDateInvoice');
        var lastDate = sessionStorage.getItem('lastDateInvoice');
        console.log(firstDate);
        console.log(lastDate);
        $.ajax({
            url: '/Provider/FinalizeInvoice',
            method: 'POST',
            data: { firstDate: firstDate, lastDate: lastDate },
            success: function (response) {
                if (response) {
                    $('.backtoinvoice').click();

                }
            },
            error: function (xhr, status, error) {
                if (xhr.status === 400) {
                    window.location.href = '/Home/patientsite';

                }
            }
        });
    });

    $('#invoiceData').on('click', '.invoiceFinalize', function () {
        var firstDate = $('#sheetDateSelect').find(':selected').attr('data-firstDate');
        var lastDate = $('#sheetDateSelect').find(':selected').attr('data-lastDate');
        InvoiceSheet(firstDate, lastDate);
    });

    //----------------------------------  back to invoice ------------------------------------
    $('#invoiceData').on('click', '.backtoinvoice', function () {
        sessionStorage.removeItem('pageNameInvoice');
        reload();
    });

    //----------------------------------  Add receipt view  ------------------------------------
    $('#invoiceData').on('click', '.addReceipt', function () {
        if ($('#invoiceReceiptData').children().length == 0) {
            var firstDate = sessionStorage.getItem('firstDateInvoice');
            var lastDate = sessionStorage.getItem('lastDateInvoice');
            InvoiceReceipt(firstDate, lastDate);
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

        Invoice(firstDate, lastDate);
    });


    //--------------------------------------------------------- update invoice sheet data --------------------------
    $('#invoiceData').on('click', '.updateInvoiceSheetData', function () {
        var data = GetTableData();
        var sheetData = JSON.stringify(data);
        $.ajax({
            url: '/Provider/UpdateInvoiceSheetData',
            method: 'POST',
            data: sheetData,
            contentType: 'application/json',
            success: function (response) {
                if (response) {
                    var firstDate = sessionStorage.getItem('firstDateInvoice');
                    var lastDate = sessionStorage.getItem('lastDateInvoice');
                    InvoiceSheetData(firstDate, lastDate);

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
    switch (pageName) {
        case 'InvoiceSheet':
            InvoiceSheet(firstDate, lastDate);
            break;
        default:
            Invoice(firstDate, lastDate);
            break;
    }
}


function Invoice(firstDate, lastDate) {

    $.ajax({
        url: '/Provider/InvoicePartialView',
        method: 'POST',
        data: { firstDate: firstDate, lastDate: lastDate },
        success: function (response) {
            $('#invoiceData').html(response);
            var periodValue = sessionStorage.getItem('selectedPeriodInvoice');
            if (periodValue == null) periodValue = 0;
            $('#sheetDateSelect').val(periodValue);

        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
                window.location.href = '/Home/patientsite';

            }
        }
    });
}

function InvoiceSheet(firstDate, lastDate) {

    $.ajax({
        url: '/Provider/InvoiceSheet',
        method: 'POST',
        success: function (response) {
            $('#invoiceData').html(response);
            InvoiceSheetData(firstDate, lastDate);
            sessionStorage.setItem('pageNameInvoice', 'InvoiceSheet');
        },
        error: function (xhr, status, error) {
            if (xhr.status === 400) {
                window.location.href = '/Home/patientsite';

            }
        }
    });
}

function InvoiceSheetData(firstDate, lastDate) {
    $.ajax({
        url: '/Provider/InvoiceSheetData',
        method: 'POST',
        data: { firstDate: firstDate, lastDate: lastDate },
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

function InvoiceReceipt(firstDate, lastDate) {

    $.ajax({
        url: '/Provider/InvoiceReceipt',
        method: 'POST',
        data: { firstDate: firstDate, lastDate: lastDate },
        success: function (response) {
            console.log(response);
            $('#invoiceReceiptData').html(response);
            $('.disInput').prop('disabled', true);
            $('.submitFileBtn').hide();

            $('.receiptEdit').click(function () {
                $(this).closest('tr').find('.disInput').prop('disabled', false);
                $(this).siblings('.receiptView,.receiptDelete').prop('hidden', true);
                $(this).siblings('.receiptSave,.receiptCancel').prop('hidden', false);
                $(this).prop('hidden', true);
            });

            $('.receiptCancel').click(function () {
                var firstDate = sessionStorage.getItem('firstDateInvoice');
                var lastDate = sessionStorage.getItem('lastDateInvoice');
                InvoiceReceipt(firstDate, lastDate);
            });

            $('.uploadFileBtn').click(function () {
                var item = $(this).closest('tr').find('td:eq(1) input').val();
                var amount = $(this).closest('tr').find('td:eq(2) input').val();
                if (item == '' || amount <= 0) {
                    alert('please enter item and amount first');
                    return;
                }
                $(this).closest('td').find('.real-file').click();
            });



            $('.real-file').change(function () {

                var file = $(this)[0].files[0];

                $(this).closest('td').find('.custom-text').val(file.name);

                if ($(this)[0].files.length > 0) {
                    $(this).closest('td').find('.uploadFileBtn').hide();
                    $(this).closest('td').find('.submitFileBtn').show();
                }
            });

            $('.submitFileBtn,.receiptSave').click(function () {

                var timeSheetId = $(this).closest('tr').attr('value');
                var file = $(this).closest('tr').find('.real-file')[0].files[0];
                //if (files.length == 0 ) {
                //    showToastDanger("Please upload file");
                //    return;
                //}
                var formData = new FormData();
                formData.append('ReceiptDoc', file);
                formData.append('TimesheetId', timeSheetId);

                var item = $(this).closest('tr').find('td:eq(1) input').val();
                var amount = $(this).closest('tr').find('td:eq(2) input').val();
                var ShiftDate = $(this).closest('tr').find('td:eq(0)').text();
                formData.append('Item', item);
                formData.append('Amount', amount);
                formData.append('ShiftDate', ShiftDate);

                $.ajax({
                    url: '/Provider/UploadReceipt',
                    type: 'POST',
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function (response) {
                        if (response) {
                            var firstDate = sessionStorage.getItem('firstDateInvoice');
                            var lastDate = sessionStorage.getItem('lastDateInvoice');
                            InvoiceReceipt(firstDate, lastDate);

                        }
                    },
                    error: function (xhr, status, error) {
                        if (xhr.status === 400) {
                            window.location.href = '/Home/patientsite';

                        }
                    }
                });

            });


            //---------------------------------- delete file -----------------------------------------------------
            $('.receiptDelete').click(function () {

                var timeSheetId = $(this).closest('tr').attr('value');
                var shiftDate = $(this).closest('tr').find('td:eq(0)').text();

                $.ajax({
                    url: '/Provider/DeleteReceipt',
                    type: 'POST',
                    data: { timeSheetId: timeSheetId, shiftDate: shiftDate },
                    success: function (response) {
                        if (response) {
                            var firstDate = sessionStorage.getItem('firstDateInvoice');
                            var lastDate = sessionStorage.getItem('lastDateInvoice');
                            InvoiceReceipt(firstDate, lastDate);

                        }
                    },
                    error: function (xhr, status, error) {
                        if (xhr.status === 400) {
                            window.location.href = '/Home/patientsite';

                        }
                    }
                });

            });


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
    $('#invoiceSheetTable tbody tr').each(function () {
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




