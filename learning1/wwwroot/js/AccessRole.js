$(document).ready(function () {
    debugger;
    $.ajax({
        method: "get",
        url: "/admin/GetMenuByAccount",
        data: {
            AccountType: 0,
        },
        success: function (result) {
            $("#MenuList").html(result);
        },
        error: function (error) {
            console.log(error);
        }

    })
})

$("#AccountType").on("change", function () {
    var AccountType = this.value;

    $.ajax({
        method: "get",
        url: "/admin/GetMenuByAccount",
        data: {
            AccountType: AccountType,
        },
        success: function (result) {
            $("#MenuList").html(result);
        },
        error: function (error) {
            console.log(error);
        }

    });
}); 