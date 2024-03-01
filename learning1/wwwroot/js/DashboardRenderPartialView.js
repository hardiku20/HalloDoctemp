$(document).ready(function () {
    $.ajax({
        type: "get",
        url: "/admin/RenderNewPartialView",
        data: {
            Status: 1
        },
        success: function (result) {
            console.log(result);
            $("#admin-table-wrapper").html(result);
            $("#newbtn").addClass("newState-active");
            $("#newState").addClass("d-none");
            $("#newState").removeClass("d-md-block");
            $("#newState-active").addClass("d-md-block");
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    })


    $(".states-btn").click(function () {
        switch (this.id) {
            case "newbtn":
                $.ajax({
                    type: "get",
                    url: "/admin/RenderNewPartialView",
                    data: {
                        Status: 1
                    },
                    success: function (result) {
                        console.log(result);
                        $("#admin-table-wrapper").html(result);
                        $("#activebtn").removeClass("activeState-active");
                        $("#concludebtn").removeClass("concludeState-active");
                        $("#toclosebtn").removeClass("tocloseState-active");
                        $("#unpaidbtn").removeClass("unpaidState-active");
                        $("#pendingbtn").removeClass('pendingState-active');
                        $("#newbtn").addClass('newState-active');



                        $("#newState-active").addClass('d-md-block');
                        $("#pendingState").addClass('d-md-block');
                        $("#tocloseState").addClass('d-md-block');
                        $("#activeState").addClass('d-md-block');
                        $("#concludeState").addClass('d-md-block');
                        $("#unpaidState").addClass('d-md-block');
                        $("#newState").removeClass('d-md-block');
                        $("#pendingState-active").removeClass('d-md-block')
                        $("#activeState-active").removeClass('d-md-block')
                        $("#concludeState-active").removeClass('d-md-block')
                        $("#tocloseState-active").removeClass('d-md-block')
                        $("#unpaidState-active").removeClass('d-md-block')

                        $("#newState-img").addClass('d-md-block')
                        $("#pendingState-img").removeClass('d-md-block')
                        $("#activeState-img").removeClass('d-md-block')
                        $("#concludeState-img").removeClass('d-md-block')
                        $("#tocloseState-img").removeClass('d-md-block')
                        $("#unpaidState-img").removeClass('d-md-block')
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                })
                break;
            case "pendingbtn":
                $.ajax({
                    type: "get",
                    url: "/admin/RenderPendingPartialView",
                    data: {
                        Status: 2
                    },
                    success: function (result) {
                        console.log(result);
                        $("#admin-table-wrapper").html(result);
                        $("#newbtn").removeClass("newState-active");
                        $("#activebtn").removeClass("activeState-active");
                        $("#concludebtn").removeClass("concludeState-active");
                        $("#toclosebtn").removeClass("tocloseState-active");
                        $("#unpaidbtn").removeClass("unpaidState-active");
                        $("#pendingbtn").addClass('pendingState-active');

                        $("#newState").addClass('d-md-block');
                        $("#pendingState").removeClass('d-md-block');
                        $("#tocloseState").addClass('d-md-block');
                        $("#activeState").addClass('d-md-block');
                        $("#concludeState").addClass('d-md-block');
                        $("#unpaidState").addClass('d-md-block');
                        $("#newState-active").removeClass('d-md-block');
                        $("#pendingState-active").addClass('d-md-block')
                        $("#activeState-active").removeClass('d-md-block')
                        $("#concludeState-active").removeClass('d-md-block')
                        $("#tocloseState-active").removeClass('d-md-block')
                        $("#unpaidState-active").removeClass('d-md-block')

                        $("#newState-img").removeClass('d-md-block')
                        $("#pendingState-img").addClass('d-md-block')
                        $("#activeState-img").removeClass('d-md-block')
                        $("#concludeState-img").removeClass('d-md-block')
                        $("#tocloseState-img").removeClass('d-md-block')
                        $("#unpaidState-img").removeClass('d-md-block')
                        
                        
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                })
                break;
            case "activebtn":
                $.ajax({
                    type: "get",
                    url: "/admin/RenderActivePartialView",
                    data: {
                        Status: 3
                        
                    },
                    success: function (result) {
                        console.log(result);
                        $("#admin-table-wrapper").html(result);
                        $("#newbtn").removeClass("newState-active");
                        $("#concludebtn").removeClass("concludeState-active");
                        $("#toclosebtn").removeClass("tocloseState-active");
                        $("#unpaidbtn").removeClass("unpaidState-active");
                        $("#pendingbtn").removeClass('pendingState-active');
                        $("#activebtn").addClass('activeState-active');


                        $("#newState").addClass('d-md-block');
                        $("#pendingState").addClass('d-md-block');
                        $("#tocloseState").addClass('d-md-block');
                        $("#activeState").removeClass('d-md-block');
                        $("#concludeState").addClass('d-md-block');
                        $("#unpaidState").addClass('d-md-block');
                        $("#newState-active").removeClass('d-md-block');
                        $("#pendingState-active").removeClass('d-md-block')
                        $("#activeState-active").addClass('d-md-block')
                        $("#concludeState-active").removeClass('d-md-block')
                        $("#tocloseState-active").removeClass('d-md-block')
                        $("#unpaidState-active").removeClass('d-md-block')

                        $("#newState-img").removeClass('d-md-block')
                        $("#pendingState-img").removeClass('d-md-block')
                        $("#activeState-img").addClass('d-md-block')
                        $("#concludeState-img").removeClass('d-md-block')
                        $("#tocloseState-img").removeClass('d-md-block')
                        $("#unpaidState-img").removeClass('d-md-block')
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                })
                break;

            case "concludebtn":
                $.ajax({
                    type: "get",
                    url: "/admin/RenderConcludePartialView",
                    data: {
                        Status: 6
                    },
                    success: function (result) {
                        console.log(result);
                        $("#admin-table-wrapper").html(result);
                        $("#newbtn").removeClass("newState-active");
                        $("#activebtn").removeClass("activeState-active");
                        $("#toclosebtn").removeClass("tocloseState-active");
                        $("#unpaidbtn").removeClass("unpaidState-active");
                        $("#pendingbtn").removeClass('pendingState-active');
                        $("#concludebtn").addClass('concludeState-active');


                        $("#newState").addClass('d-md-block');
                        $("#pendingState").addClass('d-md-block');
                        $("#tocloseState").addClass('d-md-block');
                        $("#activeState").addClass('d-md-block');
                        $("#concludeState").removeClass('d-md-block');
                        $("#unpaidState").addClass('d-md-block');
                        $("#newState-active").removeClass('d-md-block');
                        $("#pendingState-active").removeClass('d-md-block')
                        $("#activeState-active").removeClass('d-md-block')
                        $("#concludeState-active").addClass('d-md-block')
                        $("#tocloseState-active").removeClass('d-md-block')
                        $("#unpaidState-active").removeClass('d-md-block')

                        $("#newState-img").removeClass('d-md-block')
                        $("#pendingState-img").removeClass('d-md-block')
                        $("#activeState-img").removeClass('d-md-block')
                        $("#concludeState-img").addClass('d-md-block')
                        $("#tocloseState-img").removeClass('d-md-block')
                        $("#unpaidState-img").removeClass('d-md-block')
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                })
                break;

            case "toclosebtn":
                $.ajax({
                    type: "get",
                    url: "/admin/RenderToClosePartialView",
                    data: {
                        Status: 7
                    },
                    success: function (result) {
                        console.log(result);
                        $("#admin-table-wrapper").html(result);
                        $("#newbtn").removeClass("newState-active");
                        $("#activebtn").removeClass("activeState-active");
                        $("#concludebtn").removeClass("concludeState-active");
                        $("#unpaidbtn").removeClass("unpaidState-active");
                        $("#pendingbtn").removeClass('pendingState-active');
                        $("#toclosebtn").addClass('tocloseState-active');


                        $("#newState").addClass('d-md-block');
                        $("#pendingState").addClass('d-md-block');
                        $("#tocloseState").removeClass('d-md-block');
                        $("#activeState").addClass('d-md-block');
                        $("#concludeState").addClass('d-md-block');
                        $("#unpaidState").addClass('d-md-block');
                        $("#newState-active").removeClass('d-md-block');
                        $("#pendingState-active").removeClass('d-md-block')
                        $("#activeState-active").removeClass('d-md-block')
                        $("#concludeState-active").removeClass('d-md-block')
                        $("#tocloseState-active").addClass('d-md-block')
                        $("#unpaidState-active").removeClass('d-md-block')

                        $("#newState-img").removeClass('d-md-block')
                        $("#pendingState-img").removeClass('d-md-block')
                        $("#activeState-img").removeClass('d-md-block')
                        $("#concludeState-img").removeClass('d-md-block')
                        $("#tocloseState-img").addClass('d-md-block')
                        $("#unpaidState-img").removeClass('d-md-block')
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                })
                break;

            case "unpaidbtn":
                $.ajax({
                    type: "get",
                    url: "/admin/RenderUnpaidPartialView",
                    data: {
                        Status: 8
                    },
                    success: function (result) {
                        console.log(result);
                        $("#admin-table-wrapper").html(result);
                        $("#newbtn").removeClass("newState-active");
                        $("#activebtn").removeClass("activeState-active");
                        $("#concludebtn").removeClass("concludeState-active");
                        $("#toclosebtn").removeClass("tocloseState-active");
                        $("#pendingbtn").removeClass('pendingState-active');
                        $("#unpaidbtn").addClass('unpaidState-active');


                        $("#newState").addClass('d-md-block');
                        $("#pendingState").addClass('d-md-block');
                        $("#tocloseState").addClass('d-md-block');
                        $("#activeState").addClass('d-md-block');
                        $("#concludeState").addClass('d-md-block');
                        $("#unpaidState").removeClass('d-md-block');
                        $("#newState-active").removeClass('d-md-block');
                        $("#pendingState-active").removeClass('d-md-block')
                        $("#activeState-active").removeClass('d-md-block')
                        $("#concludeState-active").removeClass('d-md-block')
                        $("#tocloseState-active").removeClass('d-md-block')
                        $("#unpaidState-active").addClass('d-md-block')



                        $("#newState-img").removeClass('d-md-block')
                        $("#pendingState-img").removeClass('d-md-block')
                        $("#activeState-img").removeClass('d-md-block')
                        $("#concludeState-img").removeClass('d-md-block')
                        $("#tocloseState-img").removeClass('d-md-block')
                        $("#unpaidState-img").addClass('d-md-block')
                    },
                    error: function (xhr, status, error) {
                        console.log(error);
                    }
                })
                break;
        }
    })

})
