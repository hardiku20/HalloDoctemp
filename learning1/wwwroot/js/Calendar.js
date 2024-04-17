
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
        //    img.style.margin = '2px';
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
    url: `/Admin/GetRegions`,
    type: "GET",
    success: function (data) {
        $.each(data, function (i, obj) {
            region += "<option value=\"" + obj.regionId + "\">" + obj.name + "</option>";
        })
        $("#Region").html(region);
    }
})


 $("#Region").on("change", function () {
     var RegionId = $(this).val();
     GetCalendar(RegionId);
    console.log("onchange func of region")
 })

document.getElementById("regionSelector").addEventListener("change", function () {
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







//$('#regionSelector').change(function () {

//    let regionName = this.value;

//    var selectedRegion = this.value;
//    console.log(selectedRegion);

//        $.ajax({
//            type: 'GET',
//            url: "/Admin/GetPhysicianByRegionName",
//            data: {
//                region: regionName,

//            },
//            success: function (result) {
//                console.log(result);
//                let str = ""
//                for (let index = -1; index < result.length; index++) {
//                    const value = result[index]; // Extract the string value
//                    if (index == -1) {
//                        str += `<option selected class="text-secondary fs-6" value = "Select Physician">Select Physician </option>`;
//                    }
//                    else {
//                        str += `<option value="${value}">${value}</option>`;
//                    }

//                }
//                $("#physicianSelector").html(str);
//            },
//            error: function (error) {

//            },

//        });
//    }

//});


$("#regionSelector").change(function () {
    /**/
    console.log(this);
    var region = this.value;
    var selectedRegion = this.value;
    $.ajax({
        method: 'GET',
        url: '/Admin/GetPhysicianByRegionName',
        data: {
            regionName: region,
        },
        success: function (result) {
            let str = ""
            for (let index = 0; index < result.length; index++) {
                const value = result[index]; // Extract the string value
                str += `<option value="${value}">${value}</option>`;
            }
            $("#physicianSelector").html(str);
        },

        error: function (xhr, status, error) {
            console.log(error);

        }
    })

})

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