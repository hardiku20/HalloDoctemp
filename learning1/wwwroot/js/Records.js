$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/admin/RendorPatientHistoryPartialView",
        data: {

        },

        success: function (result) {
            console.log(result);
            $("#PatientHistory_table").html(result);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    })
 
})


$("#SearchPatientHistory").click(function () {
    var firstname = $("#firstName").val();
    var lastname = $("#lastName").val();
    var email = $("#Email").val();
    var phonenumber = $("#phoneNumber").val();
    $.ajax({
        type: "GET",
        url: "/admin/RendorPatientHistoryPartialView",
        data: {
            firstname: firstname,
            lastname: lastname,
            email: email,
            phonenumber: phonenumber,
        },
        success: function (result) {
            console.log(result);
            $("#PatientHistory_table").html(result);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }

    })

})

$("#clear_btn").click(function () {
    $.ajax({
        type: "GET",
        url: "/admin/RendorPatientHistoryPartialView",
        data: {
            
        },
        success: function (result) {
            console.log(result);
            $("#PatientHistory_table").html(result);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }

    })

})