$("#AccountType").on("change", function () {
    var AccountType = this.value;

    $.ajax({
        method: "get",
        url: "GetMenuByAccount",
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


