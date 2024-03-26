$("[name=relationshipType]").on("change", function () {
    debugger;
    var RequestType = (this.value === 'Family/Friend' ? "Family" : this.value);

    var status = "1";
    var state = $(".page-item")[0].id.split("-")[1];

    var patientName = $("#searchInput").val();
    //var region = $("searchRegion").value;
    var page = "1";
    var url = "/Admin/RenderNewPartialView";
    var statusId = 1;

    var maxPages = $(`#nextPage-${state}`).attr("data-totalpages");

    if (state == 'activeState' || state == 'tocloseState') {
        switch (state) {
            case 'activeState':
                $.ajax({
                    method: "get",
                    url: "/Admin/RenderActivePartialView",
                    data: {
                        Status1: 4,
                        Status2: 5,
                        Page: page,
                        PatientName: patientName,
                        //RegionName: region,
                        requestType: RequestType
                    },
                    success: function (result) {

                        $("#tableContent").html(result);
                        $(".pagination li").removeClass('active');
                        $(`#1-${state}`).addClass("active");
                        if (page == 1) {
                            $(`#previousPage-${state}`).addClass("d-none");
                        }
                        else if (page != 1) {
                            $(`#previousPage-${state}`).removeClass("d-none");
                        }
                        if (page == maxPages) {
                            $(`#nextPage-${state}`).addClass("d-none");
                        }
                        else if (page != maxPages) {
                            $(`#nextPage-${state}`).removeClass("d-none");
                        }
                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
                break;
            case 'tocloseState':
                $.ajax({
                    method: "get",
                    url: "/Admin/RenderToClosePartialView",
                    data: {
                        Status1: 3,
                        Status2: 7,
                        Status3: 8,
                        Page: page,
                        PatientName: patientName,
                        //RegionName: region,
                        requestType: RequestType
                    },
                    success: function (result) {
                        $("tableContent").html(result);
                        $(".pagination li").removeClass('active');
                        $(`#1-${state}`).addClass("active");
                        if (page == 1) {
                            $(`#previousPage-${state}`).addClass("d-none");
                        }
                        else if (page != 1) {
                            $(`#previousPage-${state}`).removeClass("d-none");
                        }

                        if (page == maxPages) {
                            $(`#nextPage-${state}`).addClass("d-none");
                        }
                        else if (page != maxPages) {
                            $(`#nextPage-${state}`).removeClass("d-none");
                        }
                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
                break;
        }
    }
    else {
        switch (state) {
            case 'newState':
                url = "/Admin/RenderNewPartialView"
                statusId = 1;
                break;
            case 'pendingState':
                url = "/Admin/RenderPendingPartialView"
                statusId = 2;
                break;
            case 'concludeState':
                url = "/Admin/RenderConcludePartialView"
                statusId = 6;
                break;
            case 'unpaidState':
                url = "/Admin/RenderUnpaidPartialView"
                statusId = 9;
                break;
            default:
                console.log("something unwanted happened!!");
        }

        $.ajax({
            method: "get",
            url: url,
            data: {
                status: statusId,
                Page: page,
                PatientName: patientName,
                //RegionName: region,
                requestType: RequestType
            },
            success: function (result) {
                $("#tableContent").html(result);
                $(".pagination li").removeClass('active');
                $(`#1-${state}`).addClass("active");
                if (page == 1) {
                    $(`#previousPage-${state}`).addClass("d-none");
                }
                else if (page != 1) {
                    $(`#previousPage-${state}`).removeClass("d-none");
                }

                if (page == maxPages) {
                    $(`#nextPage-${state}`).addClass("d-none");
                }
                else if (page != maxPages) {
                    $(`#nextPage-${state}`).removeClass("d-none");
                }
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
});