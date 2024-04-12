$(".SendAgreement").click(function () {
    
    var reqId = $("#Agreement-RequestId").val();
    $.ajax({
        method: 'GET',
        url: '/Admin/SendAgreementMail',
        data: {
            RequestId: reqId,
        },

        success: function (result) { 
            $("#PatientEmail").val(result.patientemail);
            $("#PatientPhone").val(result.patientphone);
        },

        error: function (xhr, status, error) {
            console.log(error);
        }

    })
})