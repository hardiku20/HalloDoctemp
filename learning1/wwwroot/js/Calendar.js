
//var calendar;
//GetCalendar(0);
//function GetCalendar(RegionId) {

//    var calendarEl = document.getElementById('calendar');
//    calendar = new FullCalendar.Calendar(calendarEl, {
//        height: 'auto',
//        schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
//        themeSystem: 'bootstrap5',
//        headerToolbar: false,
//        initialView: 'resourceTimeline',
//        eventDisplay: 'block',
//        //using dataset we set data inside html tags in view
//        datesSet: function (info) {
//            console.log(info);
//            var title = info.view.title;
//            document.getElementById("calendarTitle").innerHTML = title;
//        },
//        eventClick: function (info, jsEvent, view) {
//            ViewShift(info.event.id);
//        },
//        views: {
//            resourceTimelineWeek: {

//                slotDuration: { days: 1 },
//                slotLabelFormat: { weekday: 'short', day: 'numeric', week: 'long' }
//            }
//        },
//        //resourceLabelDidMount: function (resourceObj) {
//        //    const img = document.createElement('img');
//        //    img.src = resourceObj.resource.extendedProps.imageUrl || "/images/doc-ico.png";
//        //    img.style.maxHeight = '40px';
//        //    img.style.margin = '2px';
//        //    resourceObj.el.querySelector('.fc-datagrid-cell-main').appendChild(img);
//        //},
//        resources: "/Admin/GetProviderDetailsForSchedule?RegionId=" + RegionId,
//        events: "/admin/getscheduledata",
//    });
//    calendar.render();
//}
//let calendarNext = () => calendar.next();
//let calendarPrev = () => calendar.prev();
//let calendarToday = () => calendar.today();
//let changeView = (type) => calendar.changeView(type);



////$.ajax({
////    url: `/Admin/CreateShift`,
////    type: "GET",
////    success: function (data) {
////        $("#CreateShift").html(data);
////    }
////})


//var region = "<option value=\"0\" selected>All Regions</option>";
//$.ajax({
//    url: `/Admin/GetRegions`,
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

//document.getElementById("regionSelector").addEventListener("change", function () {
//    var RegionId = this.value;
//    GetCalendar(RegionId);

//});











//$("#regionSelector").change(function () {
//    /**/
//    console.log(this);
//    var region = this.value;
//    var selectedRegion = this.value;
//    $.ajax({
//        method: 'GET',
//        url: '/Admin/GetPhysicianByRegionName',
//        data: {
//            regionName: region,
//        },
//        success: function (result) {
//            let str = ""
//            for (let index = 0; index < result.length; index++) {
//                const value = result[index]; // Extract the string value
//                str += `<option value="${value}">${value}</option>`;
//            }
//            $("#physicianSelector").html(str);
//        },

//        error: function (xhr, status, error) {
//            console.log(error);

//        }
//    })

//})

//$(".checkbox-wrapper input").on('change', function () {
//    var selectedDays = []; // Clear any previous selections
//    document.querySelectorAll('input[type="checkbox"]:checked:not(#flexSwitchCheckChecked)')
//        .forEach(checkbox => {
//            selectedDays.push(parseInt(checkbox.value));
//        });

//    $('#HiddenDays').val(selectedDays.join(','));
//});


//toggleButton.checked = false;
//let isRepeatChecked = false;
//$(".checkbox-wrapper input").attr("disabled", true)

//toggleButton.addEventListener("click", function () {
//    isRepeatChecked = !isRepeatChecked; // Toggle the checked state [if checked => unchecked else unchecked => checked]
//    //repeatDiv.style.display = isRepeatChecked ? "block" : "none";
//    if (toggleButton.checked) {
//        $(".checkbox-wrapper input").attr("disabled", false)
//    }
//    else $(".checkbox-wrapper input").attr("disabled", true)
//});
































//----------------------------------------



var calendar;
GetCalendar(0);
function GetCalendar(RegionId) {
    var view = window.location.search;
    if (view.includes('isMonthView')) view = 'dayGridMonth';
    else if (view.includes('isWeekView')) view = 'resourceTimelineWeek';
    else view = 'resourceTimeline';
    var calendarEl = document.getElementById('calendar');
    calendar = new FullCalendar.Calendar(calendarEl, {
        height: 'auto',
        schedulerLicenseKey: 'GPL-My-Project-Is-Open-Source',
        themeSystem: 'bootstrap5',
        headerToolbar: false,
        initialView: view,
        eventDisplay: 'block',
        //using datesSet we set data inside html tags in view
        datesSet: function (info) {
            console.log(info);
            if (info.view.type === 'resourceTimeline') {
                // Get the date object for the current view
                const date = info.view.calendar.getDate();

                // Format the date (e.g., Monday, 2024-04-08)
                const formattedDate = new Intl.DateTimeFormat('en-US', { weekday: 'long', year: 'numeric', month: 'short', day: 'numeric' }).format(date);

                // Update the calendar title
                document.getElementById("calendarTitle").innerHTML = formattedDate;
                document.querySelector('.fc-datagrid-cell-main').textContent = "STAFF";

            }
            else if (info.view.type === 'resourceTimelineWeek') {
                document.getElementById("calendarTitle").innerHTML = info.view.title;
                document.querySelector('.fc-datagrid-cell-main').textContent = "STAFF"

            }
            else {
                // Handle other view types (optional)
                // For example, you could display a different title for month or week views
                document.getElementById("calendarTitle").innerHTML = info.view.title;
                //document.querySelector('.fc-datagrid-cell-main').textContent = "STAFF"
            }
        },
        eventTimeFormat: {
            hour: 'numeric',
            minute: '2-digit',
            meridiem: 'short'
        },
        eventClick: function (info, jsEvent, view) {
            ViewShift(info.event.id);
        },
        views: {

            resourceTimeline: {
                //    slotLabelContent: function (slotInfo) {
                //        var hours = slotInfo.date.getHours();
                //        var meridiem = hours >= 12 ? 'P' : 'A';
                //        hours = hours % 12 || 12;

                //        return hours + meridiem;
                //    },
                //    width: "100%",
                slotDuration: '01:00:00'
            },
            resourceTimelineWeek: {

                slotDuration: { days: 1 },
                slotLabelFormat: { weekday: 'short', day: 'numeric', week: 'long' }
            },
        },
        resourceLabelDidMount: function (resourceObj) {
            const img = document.createElement('img');
            img.src = resourceObj.resource.extendedProps.imageUrl || "/images/doc-ico.png";
            img.style.maxHeight = '40px';
            img.style.margin = '2px';
            resourceObj.el.querySelector('.fc-datagrid-cell-main').appendChild(img);
        },
        resources: "/Admin/GetProviderDetailsForSchedule?RegionId=" + RegionId,
        events: "/admin/getscheduledata?RegionId=" + RegionId,
    });
    calendar.render();
}
let calendarNext = () => calendar.next();
let calendarPrev = () => calendar.prev();
let calendarToday = () => calendar.today();
let changeView = function (type) {
    calendar.changeView(type);
    switch (type) {
        case 'dayGridMonth':
            var url = new URL(window.location.href);
            url.search = '';
            url.searchParams.set('isMonthView', true);
            window.history.pushState({ path: url.href }, '', url.href);
            break;
        case 'resourceTimelineWeek':
            var url = new URL(window.location.href);
            url.search = '';
            url.searchParams.set('isWeekView', true);
            window.history.pushState({ path: url.href }, '', url.href);
            break;
        case 'resourceTimeline':
            var url = new URL(window.location.href);
            url.search = '';
            url.searchParams.set('isDayView', true);
            window.history.pushState({ path: url.href }, '', url.href);
            break;
    }
}



//$.ajax({
//    url: `/Admin/CreateShift`,
//    type: "GET",
//    success: function (data) {
//        $("#CreateShift").html(data);
//    }
//})


var region = "<option value=\"0\" selected>All Regions</option>";
$.ajax({
    url: `/Admin/GetRegions`,
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
    console.log(RegionId);
    GetCalendar(RegionId);

});


function ViewShift(ShiftDetailId) {
    $.ajax({
        type: "GET",
        url: "/Admin/ViewShift",
        data: { ShiftDetailId },
        success: function (data) {
            $("#ViewShift").html(data);
            $("#ViewShiftModal").modal("show");
        },
        error: function (data) {
            alert("Cannot Fetch Shift Details");
        }
    })

}









function loadShifts() {
    $.ajax({
        url: '/Admin/GetScheduleData',
        data: { RegionId: $("#Region").val() },
        type: 'GET',
        success: function (data) {
            calendar.removeAllEvents();
            data.forEach(function (event) {
                calendar.addEvent(event);
            });
        },
        error: function (xhr, status, error) {
            alert('Error fetching schedule data:', error);
        }
    });
}
