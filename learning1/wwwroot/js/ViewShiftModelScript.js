jQuery(function () {
    var isDateExist = $('input[type="date"]').length;
    if (isDateExist != 0) {
        var today = new Date().toISOString().split('T')[0];
        $('input[type="date"]').attr('min', today);
    }
});

function disablePastTimesVS() {
    if ($("#ShiftDateVS").val() == new Date().toISOString().split('T')[0]) {
        var timeInput = document.getElementById('StartTimeVS');
        var now = new Date().toTimeString().slice(0, 5);
        if (timeInput.value < now) {
            timeInput.value = now
            console.log(now);
        }
    }
}
$("#EditViewShift").on("click", function () {
    console.log("Edit")
    $(this).addClass("d-none");
    $("#SaveViewShift").removeClass("d-none");
    $("#EditViewShiftField").removeAttr("disabled");
})
$("#ReturnViewShift").on("click", function () {
    var ShiftDetailId = $("#ShiftDetailId").val();
    $.ajax({
        url: `/Admin/ReturnViewShift`,
        method: "GET",
        data: { ShiftDetailId },
        success: function (data) {
            if (data) {
                Swal.fire({
                    title: "Shift Status!",
                    text: "Your Shift Status has been Changed.",
                    icon: "success"
                });
                $("#ViewShiftModal").modal("hide");
                loadShifts();
            }
            else {
                alert("Error While Return Shift");
                console.log("error");
            }
        },
        error: function () {
            alert("Error While Return Account");
            console.log("error");
        }
    })
})
$("#DeleteViewShift").on("click", function () {
    var ShiftDetailId = $("#ShiftDetailId").val();

    Swal.fire({
        title: "Are you sure?",
        text: "You want to Delete Shift!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, Delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.LoadingOverlay("show", {
                background: "rgba(58, 58, 58, 0.5)"
            });
            $.ajax({
                method: "GET",
                url: "/Admin/DeleteViewShift",
                data: { ShiftDetailId },
                success: function (data) {
                    if (data) {
                        Swal.fire({
                            title: "Delete Shift!",
                            text: "Your Shift has been Deleted.",
                            icon: "success"
                        });
                        $("#ViewShiftModal").modal("hide");
                        loadShifts();
                    }
                    else {
                        alert("Error While Delete Shift");
                        console.log("error");
                    }
                },
                error: function () {
                    alert("Error While Delete Account");
                    console.log("error");
                },
                complete: function () {
                    $.LoadingOverlay("hide");
                }
            });
        }
    });
})
$("#ViewShiftForm").on("submit", function (e) {
    console.log("Submit")
    e.preventDefault();
    var actionurl = e.currentTarget.action;
    $(this).validate();
    if ($(this).valid()) {
        $.ajax({
            url: actionurl,
            type: 'POST',
            data: $(this).serialize(),
            success: function (data) {
                if (data) {
                    alert("Shift Edited Successfully");
                    $("#ViewShiftModal").modal("hide");
                    loadShifts();
                } else {
                    alert("Error While Editing Shift Information");
                }
            },
            error: function (data) {
                alert("Error While Editing Shift Information");
            }
        });
    }
})
