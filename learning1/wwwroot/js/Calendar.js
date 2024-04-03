
var calendar;
GetCalendar(0);
function GetCalendar(RegionId) {

    var calendarEl = document.getElementById('calendar');
    calendar = new FullCalendar.Calendar(calendarEl, {
        height: 'auto',
        schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
        themeSystem: 'bootstrap5',
        headerToolbar: false,
        initialView: 'resourceTimeline',
        eventDisplay: 'block',
        //using dataset we set data inside html tags in view
        datesSet: function (info) {
            console.log(info);
            var title = info.view.title;
            document.getElementById("calendarTitle").innerHTML = title;
        },
        eventClick: function (info, jsEvent, view) {
            ViewShift(info.event.id);
        },
        views: {
            resourceTimelineWeek: {

                slotDuration: { days: 1 },
                slotLabelFormat: { weekday: 'short', day: 'numeric', week: 'long' }
            }
        },
        //resourceLabelDidMount: function (resourceObj) {
        //    const img = document.createElement('img');
        //    img.src = resourceObj.resource.extendedProps.imageUrl || "/images/doc-ico.png";
        //    img.style.maxHeight = '40px';
        //    resourceObj.el.querySelector('.fc-datagrid-cell-main').appendChild(img);
        //},
        resources: "/Admin/GetProviderDetailsForSchedule?RegionId=" + RegionId,
        events: "/admin/getscheduledata",
    });
    calendar.render();
}
let calendarNext = () => calendar.next();
let calendarPrev = () => calendar.prev();
let calendarToday = () => calendar.today();
let changeView = (type) => calendar.changeView(type);



//$.ajax({
//    url: `/Admin/CreateShift`,
//    type: "GET",
//    success: function (data) {
//        $("#CreateShift").html(data);
//    }
//})


var region = "<option value=\"0\" selected>All Regions</option>";
$.ajax({
    url: `/Admin/GetRegion`,
    type: "GET",
    success: function (data) {
        $.each(data, function (i, obj) {
            region += "<option value=\"" + obj.regionId + "\">" + obj.name + "</option>";
        })
        $("#Region").html(region);
    }
})
// $("#Region").on("change", function () {
//     var RegionId = $(this).val();
//     GetCalendar(RegionId);
//    console.log("onchange func of region")
// })

document.getElementById("SelectedRegion").addEventListener("change", function () {
    var RegionId = this.value;
    GetCalendar(RegionId);

});


function ViewShift(ShiftDetailId) {
    $.ajax({
        type: "GET",
        url: "/Admin/ViewShift",
        data: { ShiftDetailId },
        success: function (data) {
            data.
                $("#ViewShift").html(data);
            $("#ViewShiftModal").modal("show");
        },
        error: function (data) {
            alert("Cannot Fetch Shift Details");
        }
    })

}
