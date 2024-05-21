$(document).ready(function () {

    $(".pagination li").on("click", function () {
        debugger
        var page = this.id;
        var pageSize = $("#pageSize").val();
        var maxPages = $(`#nextPage`).attr("data-totalpages");
        if (page == 'previousPage') {
            page = parseInt($("li.active")[0].id) - 1;
        }
        else if (page == 'nextPage') {
            page = parseInt($("li.active")[0].id) + 1;
        }

        $.ajax({
            method: "get",
            url: "/admin/RenderVendorTable",
            data: {
                Page: page,
                PageSize: pageSize,
            },

            success: function (result) {
                $("#Vendors_table").html(result);
                $(".pagination li").removeClass('active');
                $(`#${page}`).addClass("active");
                if (page == 1) {
                    $(`#previousPage`).addClass("d-none");
                }
                else if (page != 1) {
                    $(`#previousPage`).removeClass("d-none");
                }

                if (page == maxPages) {
                    $(`#nextPage`).addClass("d-none");
                }
                else if (page != maxPages) {
                    $(`#nextPage`).removeClass("d-none");
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    });

    //let SelectedProfessionId = $("#SelectedProfession").val();
    //var SearchValue = $("#SearchVendorName").val();

    //$.ajax({
    //    type: "GET",
    //    url: "/admin/RenderVendorTable",
    //    data: {

    //    },

    //    success: function (result) {
    //        console.log(result);
    //        $("#Vendors_table").html(result);
    //    },
    //    error: function (xhr, status, error) {
    //        console.log(error);
    //    }

    //})

})


//$("#pageSize").on("change", function () {
//    var page = 1;
//    var pageSize = $("#pageSize").val();
//    var maxPages = $(`#nextPage`).attr("data-totalpages");
//    $.ajax({
//        method: "get",
//        url: "/admin/RenderVendorTable",
//        data: {
//            Page: 1,
//            PageSize: pageSize,
//        },

//        success: function (result) {
//            $("#Vendors_table").html(result);
//            $(".pagination li").removeClass('active');
//            $("#pageSize").val(pageSize);
//            $(`#${page}`).addClass("active");
//            if (page == 1) {
//                $(`#previousPage`).addClass("d-none");
//            }
//            else if (page != 1) {
//                $(`#previousPage`).removeClass("d-none");
//            }

//            if (page == maxPages) {
//                $(`#nextPage`).addClass("d-none");
//            }
//            else if (page != maxPages) {
//                $(`#nextPage`).removeClass("d-none");
//            }
//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });
//})