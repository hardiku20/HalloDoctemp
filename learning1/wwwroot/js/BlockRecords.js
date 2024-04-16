$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/admin/RendorBlockHistoryPartialView",
        data: {

        },

        success: function (result) {
            console.log(result);
            $("#Blockrecord_table").html(result);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    })
})

$("#SearchRecords").click(function () {
    var name = $("#Name").val();
    var date = $("#Date").val();
    var email = $("#Email").val();
    var phonenumber = $("#PhoneNumber").val();
    $.ajax({
        type: "GET",
        url: "/admin/RendorBlockHistoryPartialView",
        data: {
            name: name,
            date: date,
            email: email,
            phonenumber: phonenumber,

        },
        success: function (result) {
            console.log(result);
            $("#Blockrecord_table").html(result);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }

    })

})

$("#clear_btn").click(function () {
    $.ajax({
        type: "GET",
        url: "/admin/RendorBlockHistoryPartialView",
        data: {

        },
        success: function (result) {
            console.log(result);
            $("#Blockrecord_table").html(result);
        },
        error: function (xhr, status, error) {
            console.log(error);
        }

    })

})
