$(document).ready(function () {    const toggleButton = document.getElementById("flexSwitchCheckChecked");    // Set the initial checked state (unchecked)    toggleButton.checked = false;    let isRepeatChecked = false;    $(".checkbox-wrapper input").attr("disabled", true)    $("#RepeatSelect").attr("disabled", true)    // Add a click event listener to the toggle button    toggleButton.addEventListener("click", function () {        isRepeatChecked = !isRepeatChecked; // Toggle the checked state [if checked => unchecked else unchecked => checked]        //repeatDiv.style.display = isRepeatChecked ? "block" : "none";        if (toggleButton.checked) {            $(".checkbox-wrapper input").attr("disabled", false);            $("#RepeatSelect").attr("disabled", false)        }        else {            $(".checkbox-wrapper input").attr("disabled", true);            $("#RepeatSelect").attr("disabled", true);        }    });    $('#regionSelector').change(function () {        console.log(this);        let regionId = this.value;        var selectedRegion = this.value;        console.log(selectedRegion);        $.ajax({            type: 'GET',            url: '/Admin/GetPhysicianByRegionId',            data: {                regionId: regionId,            },            success: function (result) {                console.log(result);                let str = ""                for (let index = -1; index < result.length; index++) {                    const value = result[index]; // Extract the string value                    if (index == -1) {                        str += `<option selected class="text-secondary fs-6" value = "Select Physician">Select Physician </option>`;                    }                    else {                        str += `<option value="${value}">${value}</option>`;                    }                }                $("#physicianSelector").html(str);            },            error: function (error) {            }        });    });    $(".checkbox-wrapper input").on('change', function () {        var selectedDays = []; // Clear any previous selections        document.querySelectorAll('input[type="checkbox"]:checked:not(#flexSwitchCheckChecked)')            .forEach(checkbox => {                selectedDays.push(parseInt(checkbox.value));            });        $('#HiddenDays').val(selectedDays.join(','));    });    $('#ShiftDate').change(function () {        console.log("in");        $('#startTime').val("");        $(".startTime-error").text("").hide();        const shiftdate = $('#ShiftDate').val();        var currentDate = new Date();        var year = currentDate.getFullYear();        var month = (currentDate.getMonth() + 1).toString().padStart(2, '0');        var day = currentDate.getDate().toString().padStart(2, '0');        var todaydate = year + '-' + month + '-' + day;        const startTimeInput = $("#StartTime");        console.log(startTimeInput);        const endTimeInput = $("#EndTime");        console.log(endTimeInput);        const endTimeErrorSpan = $(".endTime-error");        console.log(endTimeErrorSpan);        const startTimeErrorSpan = $(".startTime-error");        console.log(startTimeErrorSpan);        if (shiftdate == todaydate) {            console.log("checking iffff");            var hours = currentDate.getHours();            var minutes = currentDate.getMinutes();            hours = ("0" + hours).slice(-2);            minutes = ("0" + minutes).slice(-2);            var minTime = hours + ":" + minutes;            startTimeInput.attr("min", minTime);        }        startTimeInput.change(function () {            console.log("start time input change");            const selectedStartTime = $(this).val();            const shiftdate1 = $('#ShiftDate').val();            if (selectedStartTime) {                if (shiftdate1 == todaydate) {                    if (!isstartTimeValid(selectedStartTime)) {                        startTimeErrorSpan.text("start Time must be after currunt time with at least a 10-minute gap").show();                    } else {                        startTimeErrorSpan.text("").hide();                    }                }                const minEndTime = calculateMinEndTime(selectedStartTime);                endTimeInput.attr("min", minEndTime);                endTimeInput.val("");            } else {                startTimeErrorSpan.text("").hide();                endTimeInput.removeAttr("min");            }        });        endTimeInput.change(function () {            console.log("endtimeinputchabge");            const selectedEndTime = $(this).val();            const selectedStartTime = startTimeInput.val();            if (selectedStartTime && selectedEndTime) {                if (!isEndTimeValid(selectedStartTime, selectedEndTime)) {                    $(this).val("");                    endTimeErrorSpan.text("End Time must be after Start Time with at least a 30-minute gap").show();                } else {                    endTimeErrorSpan.text("").hide();                }            } else {                endTimeErrorSpan.text("").hide();            }        });        function calculateMinEndTime(startTime) {            const timeParts = startTime.split(":");            const hour = parseInt(timeParts[0]);            const minute = parseInt(timeParts[1]);            let newMinute = minute + 30;            let newHour = hour;            if (newMinute >= 60) {                newMinute -= 60;                newHour++;            }            console.log(`${newHour.toString().padStart(2, "0")}:${newMinute.toString().padStart(2, "0")}`);            return `${newHour.toString().padStart(2, "0")}:${newMinute.toString().padStart(2, "0")}`;        }        function isEndTimeValid(startTime, endTime) {            console.log("calledisendtimefunction");            const startTimeParts = startTime.split(":");            const endTimeParts = endTime.split(":");            const startHour = parseInt(startTimeParts[0]);            const startMinute = parseInt(startTimeParts[1]);            const endHour = parseInt(endTimeParts[0]);            const endMinute = parseInt(endTimeParts[1]);            if (endHour < startHour || (endHour === startHour && endMinute <= startMinute)) {                return false;            }            const timeDiff = (endHour - startHour) * 60 + (endMinute - startMinute);            return timeDiff >= 30;        }        function isstartTimeValid(startTime) {            console.log("calledisstarttimefunction");            console.log(shiftdate)            var hours = currentDate.getHours();            var minutes = currentDate.getMinutes();            hours = ("0" + hours).slice(-2);            minutes = ("0" + minutes).slice(-2);            const startTimeParts = startTime.split(":");            const startHour = parseInt(startTimeParts[0]);            const startMinute = parseInt(startTimeParts[1]);            if (startHour < hours || (startHour === hours && startMinute <= minutes)) {                return false;            }            const timeDiff = (startHour - hours) * 60 + (startMinute - minutes);            return timeDiff >= 10;        }    });})