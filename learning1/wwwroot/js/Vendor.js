$(document).ready(function () {
        let SelectedProfessionId = $("#SelectedProfession").val();
        var SearchValue = $("#SearchVendorName").val();

    $.ajax({
        type: "GET",
        url: "/admin/RenderVendorTable",
        data: {

        },

        success: function (result) {
            console.log(result);
            $("#Vendors_table").html(result);
            $(`#1`).addClass("active");
        },
        error: function (xhr, status, error) {
            console.log(error);
        }

    })


    $("#SelectedProfession").on("change", function () {
        SelectedProfessionId = $("#SelectedProfession").val();
        SearchValue = $("#SearchVendorName").val();
        $.ajax({
            method: "get",
            url: "/Admin/RenderVendorTable",
            data: {
                VendorName: SearchValue,
                ProfessionId: SelectedProfessionId
            },
            success: function (result) {
                $("#Vendors_table").html(result);
            },
            error: function (error) {
                alert("error occured while loading profession data");
            }
        });
    })



    $("#SearchVendorName").on("keyup", function () {
        SelectedProfessionId = $("#SelectedProfession").val();
        SearchValue = $("#SearchVendorName").val();
        $.ajax({
            method: "get",
            url: "/Admin/RenderVendorTable",
            data: {
                VendorName: SearchValue,
                ProfessionId: SelectedProfessionId
            },
            success: function (result) {
                $("#Vendors_table").html(result);
            },
            error: function (error) {
                alert("error occured while loading search data");
            }
        });
    })





})