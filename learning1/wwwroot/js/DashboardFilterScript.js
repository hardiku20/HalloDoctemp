var timeoutId = null;$("#searchInput").on('keyup', function () {    /* */    clearTimeout(timeoutId);    timeoutId = setTimeout(function () {        var state = $(".page-item")[0].id.split("-")[1];        //var page = $(".page-item")[0].id.split("-")[0];        ////var state = $(".page-item")[0].id.split("-")[1];        //var btnId = $(".page-item")[0].id;        var region = $("#searchRegion").val();        var patientName = $("#searchInput").val();        //var maxPages = $(`#nextPage-${state}`).attr("data-totalpages");        //if (page == 'previousPage') {        //    page = parseInt($(".page-item.active")[0].id.split("-")[0]) - 1;        //}        //else if (page == 'nextPage') {        //    page = parseInt($(".page-item.active")[0].id.split("-")[0]) + 1;        //}        var url = "/Admin/RenderNewPartialView";        var statusId = 1;        if (state == 'activeState' || state == 'tocloseState') {            switch (state) {                case 'activeState':                    $.ajax({                        method: "get",                        url: "/Admin/RenderActivePartialView",                        data: {                            Status1: 4,                            Status2: 5,                            //Page: page,                            //PageSize: 4,                            PatientName: patientName,                        },                        success: function (result) {                            $("#admin-table-wrapper").html(result);                            //$(".pagination li").removeClass('active');                            //$(`#${page}-${state}`).addClass("active");                            //if (page == 1) {                            //    $(`#previousPage-${state}`).addClass("d-none");                            //}                            //else if (page != 1) {                            //    $(`#previousPage-${state}`).removeClass("d-none");                            //}                            //if (page == maxPages) {                            //    $(`#nextPage-${state}`).addClass("d-none");                            //}                            //else if (page != maxPages) {                            //    $(`#nextPage-${state}`).removeClass("d-none");                            //}                        },                        error: function (error) {                            console.log(error);                        }                    });                    break;                case 'tocloseState':                    $.ajax({                        method: "get",                        url: "/Admin/RenderToClosePartialView",                        data: {                            Status1: 3,                            Status2: 7,                            Status3: 8,                            //Page: page,                            PatientName: patientName,                        },                        success: function (result) {                            $("#admin-table-wrapper").html(result);                            //$(".pagination li").removeClass('active');                            //$(`#${page}-${state}`).addClass("active");                        },                        error: function (error) {                            console.log(error);                        }                    });                    break;            }        }        else {            switch (state) {                case 'newState':                    url = "/Admin/RenderNewPartialView"                    statusId = 1;                    break;                case 'pendingState':                    url = "/Admin/RenderPendingPartialView"                    statusId = 2;                    break;                case 'concludeState':                    url = "/Admin/RenderConcludePartialView"                    statusId = 6;                    break;                case 'unpaidState':                    url = "/Admin/RenderUnpaidPartialView"                    statusId = 9;                    break;                default:                    console.log("something unwanted happened!!");            }            console.log(statusId);            $.ajax({                method: "get",                url: url,                data: {                    Status: statusId,                    //Page: page,                    //PageSize: 4,                    PatientName: patientName,                },                success: function (result) {                    $("#admin-table-wrapper").html(result);                    $(".pagination li").removeClass('active');                    //$(`#${page}-${state}`).addClass("active");                    //if (page == 1) {                    //    $(`#previousPage-${state}`).addClass("d-none");                    //}                    //else if (page != 1) {                    //    $(`#previousPage-${state}`).removeClass("d-none");                    //}                    //if (page == maxPages) {                    //    $(`#nextPage-${state}`).addClass("d-none");                    //}                    //else if (page != maxPages) {                    //    $(`#nextPage-${state}`).removeClass("d-none");                    //}                },                error: function (error) {                    console.log(error);                }            });        }    }, 400);});$("[name=relationshipType]").on("change", function () {        var RequestType = (this.value === 'Family/Friend' ? "Family" : this.value);    var status = "1";    var state = $(".page-item")[0].id.split("-")[1];    var patientName = $("#searchInput").val();    //var region = $("searchRegion").value;    var page = "1";    var url = "/Admin/RenderNewPartialView";    var statusId = 1;    var maxPages = $(`#nextPage-${state}`).attr("data-totalpages");    if (state == 'activeState' || state == 'tocloseState') {        switch (state) {            case 'activeState':                $.ajax({                    method: "get",                    url: "/Admin/RenderActivePartialView",                    data: {                        Status1: 4,                        Status2: 5,                        Page: page,                        PatientName: patientName,                        //RegionName: region,                        requestType: RequestType                    },                    success: function (result) {                        $("#admin-table-wrapper").html(result);                        $(".pagination li").removeClass('active');                        $(`#1-${state}`).addClass("active");                        if (page == 1) {                            $(`#previousPage-${state}`).addClass("d-none");                        }                        else if (page != 1) {                            $(`#previousPage-${state}`).removeClass("d-none");                        }                        if (page == maxPages) {                            $(`#nextPage-${state}`).addClass("d-none");                        }                        else if (page != maxPages) {                            $(`#nextPage-${state}`).removeClass("d-none");                        }                    },                    error: function (error) {                        console.log(error);                    }                });                break;            case 'tocloseState':                $.ajax({                    method: "get",                    url: "/Admin/RenderToClosePartialView",                    data: {                        Status1: 3,                        Status2: 7,                        Status3: 8,                        Page: page,                        PatientName: patientName,                        //RegionName: region,                        requestType: RequestType                    },                    success: function (result) {                        $("#admin-table-wrapper").html(result);                        $(".pagination li").removeClass('active');                        $(`#1-${state}`).addClass("active");                        if (page == 1) {                            $(`#previousPage-${state}`).addClass("d-none");                        }                        else if (page != 1) {                            $(`#previousPage-${state}`).removeClass("d-none");                        }                        if (page == maxPages) {                            $(`#nextPage-${state}`).addClass("d-none");                        }                        else if (page != maxPages) {                            $(`#nextPage-${state}`).removeClass("d-none");                        }                    },                    error: function (error) {                        console.log(error);                    }                });                break;        }    }    else {        switch (state) {            case 'newState':                url = "/Admin/RenderNewPartialView"                statusId = 1;                break;            case 'pendingState':                url = "/Admin/RenderPendingPartialView"                statusId = 2;                break;            case 'concludeState':                url = "/Admin/RenderConcludePartialView"                statusId = 6;                break;            case 'unpaidState':                url = "/Admin/RenderUnpaidPartialView"                statusId = 9;                break;            default:                console.log("something unwanted happened!!");        }        $.ajax({            method: "get",            url: url,            data: {                status: statusId,                Page: page,                PatientName: patientName,                //RegionName: region,                requestType: RequestType            },            success: function (result) {                $("#admin-table-wrapper").html(result);                $(".pagination li").removeClass('active');                $(`#1-${state}`).addClass("active");                if (page == 1) {                    $(`#previousPage-${state}`).addClass("d-none");                }                else if (page != 1) {                    $(`#previousPage-${state}`).removeClass("d-none");                }                if (page == maxPages) {                    $(`#nextPage-${state}`).addClass("d-none");                }                else if (page != maxPages) {                    $(`#nextPage-${state}`).removeClass("d-none");                }            },            error: function (error) {                console.log(error);            }        });    }});$("#searchRegion").on("change", function () {    var RequestType = (this.value === 'Family/Friend' ? "Family" : this.value);    var status = "1";    var state = $(".page-item")[0].id.split("-")[1];    var patientName = $("#searchInput").val();    var region = $("#searchRegion").val();    var page = "1";    var url = "/Admin/RenderNewPartialView";    var statusId = 1;    var maxPages = $(`#nextPage-${state}`).attr("data-totalpages");    if (state == 'activeState' || state == 'tocloseState') {        switch (state) {            case 'activeState':                $.ajax({                    method: "get",                    url: "/Admin/RenderActivePartialView",                    data: {                        Status1: 4,                        Status2: 5,                        Page: page,                        PatientName: patientName,                        RegionName: region,                        requestType: RequestType                    },                    success: function (result) {                        $("#admin-table-wrapper").html(result);                        $(".pagination li").removeClass('active');                        $(`#1-${state}`).addClass("active");                        if (page == 1) {                            $(`#previousPage-${state}`).addClass("d-none");                        }                        else if (page != 1) {                            $(`#previousPage-${state}`).removeClass("d-none");                        }                        if (page == maxPages) {                            $(`#nextPage-${state}`).addClass("d-none");                        }                        else if (page != maxPages) {                            $(`#nextPage-${state}`).removeClass("d-none");                        }                    },                    error: function (error) {                        console.log(error);                    }                });                break;            case 'tocloseState':                $.ajax({                    method: "get",                    url: "/Admin/RenderToClosePartialView",                    data: {                        Status1: 3,                        Status2: 7,                        Status3: 8,                        Page: page,                        PatientName: patientName,                        RegionName: region,                        requestType: RequestType                    },                    success: function (result) {                        $("#admin-table-wrapper").html(result);                        $(".pagination li").removeClass('active');                        $(`#1-${state}`).addClass("active");                        if (page == 1) {                            $(`#previousPage-${state}`).addClass("d-none");                        }                        else if (page != 1) {                            $(`#previousPage-${state}`).removeClass("d-none");                        }                        if (page == maxPages) {                            $(`#nextPage-${state}`).addClass("d-none");                        }                        else if (page != maxPages) {                            $(`#nextPage-${state}`).removeClass("d-none");                        }                    },                    error: function (error) {                        console.log(error);                    }                });                break;        }    }    else {        switch (state) {            case 'newState':                url = "/Admin/RenderNewPartialView"                statusId = 1;                break;            case 'pendingState':                url = "/Admin/RenderPendingPartialView"                statusId = 2;                break;            case 'concludeState':                url = "/Admin/RenderConcludePartialView"                statusId = 6;                break;            case 'unpaidState':                url = "/Admin/RenderUnpaidPartialView"                statusId = 9;                break;            default:                console.log("something unwanted happened!!");        }        $.ajax({            method: "get",            url: url,            data: {                status: statusId,                Page: page,                PatientName: patientName,                RegionName: region,                requestType: RequestType            },            success: function (result) {                $("#admin-table-wrapper").html(result);                $(".pagination li").removeClass('active');                $(`#1-${state}`).addClass("active");                if (page == 1) {                    $(`#previousPage-${state}`).addClass("d-none");                }                else if (page != 1) {                    $(`#previousPage-${state}`).removeClass("d-none");                }                if (page == maxPages) {                    $(`#nextPage-${state}`).addClass("d-none");                }                else if (page != maxPages) {                    $(`#nextPage-${state}`).removeClass("d-none");                }            },            error: function (error) {                console.log(error);            }        });    }});