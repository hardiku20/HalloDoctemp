
var calendar;
var ProviderId = $("#HiddenProviderId").val();
GetCalendar(0, ProviderId);
function GetCalendar(RegionId, ProviderId) {
    var calendarEl = document.getElementById('calendar');
    calendar = new FullCalendar.Calendar(calendarEl, {
        height: 'auto',
        schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
        themeSystem: 'bootstrap5',
        headerToolbar: false,
        initialView: 'dayGridMonth',
        eventDisplay: 'block',
        //using datesSet we set data inside html tags in view
        datesSet: function (info) {

            var title = info.view.title;
            document.getElementById("calendarTitle").innerHTML = "Schedule for: " + title;

            //var view = info.view;
            //var title = view.title;

            //// Extract start and end dates for the current view
            //var startDate = view.intervalStart;
            //var endDate = view.intervalEnd;

            //// Format dates using a library or custom function (ensures consistent format)
            //var formattedStartDate = formatDate(startDate);
            //var formattedEndDate = formatDate(endDate);

            //// Construct the desired title string
            //var newTitle = "Schedule for: " + formattedStartDate + " - " + formattedEndDate;

            //// Update the calendar title element
            //document.getElementById("calendarTitle").innerHTML = newTitle;
        },
        eventTimeFormat: {
            hour: 'numeric',
            minute: '2-digit',
            meridiem: 'short'
        },
        eventClick: function (info, jsEvent, view) {
            ViewShift(info.event.id);
        },

        events: "/Provider/GetScheduleData?ProviderId=" + ProviderId + "&RegionId=" + RegionId,
    });
    calendar.render();
}
let calendarNext = () => calendar.next();
let calendarPrev = () => calendar.prev();
let calendarToday = () => calendar.today();




//var region = "<option value=\"0\" selected>All Regions</option>";
//$.ajax({
//    url: `/Admin/GetRegion`,
//    type: "GET",
//    success: function (data) {
//        $.each(data, function (i, obj) {
//            region += "<option value=\"" + obj.regionId + "\">" + obj.name + "</option>";
//        })
//        $("#Region").html(region);
//    }
//})
// $("#Region").on("change", function () {
//     var RegionId = $(this).val();
//     GetCalendar(RegionId);
//    console.log("onchange func of region")
// })

//document.getElementById("#SelectedRegion").addEventListener("change", function () {
//    var RegionId = this.value;
//    var PhysicianId = //get attribute value

//    GetCalendar(RegionId, ProviderId);

//});









