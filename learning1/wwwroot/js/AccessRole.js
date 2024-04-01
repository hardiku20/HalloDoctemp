$("#AccountType").on("change", function () {
    var AccountType = this.value;

    $.ajax({
        method: "get",
        url: "GetMenuByAccount",
        data: {
            AccountType: AccountType,
        },
        success: function (result) {
            //let str = ""
            //for (let index = 0; index < result.length; index++) {
            //    const value = result[index]; // Extract the string value
            //    str += `<div class="form-check" >
            //        <input class="form-check-input" type="checkbox" name="SelectedMenus" value="${value}" id="flexCheckChecked" asp-for="SelectedMenus">
            //            <label class="form-check-label text-secondary" for="flexCheckChecked">
            //                ${value}
            //            </label>
            //    </div>`;
            //}
            $("#MenuList").html(result);
        },
        error: function (error) {
            console.log(error);
        }

    });
}); 

