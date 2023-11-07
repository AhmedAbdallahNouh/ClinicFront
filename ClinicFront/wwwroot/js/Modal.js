function closeModal() {
    $('#exampleModal').modal('hide'); // Assuming 'exampleModal' is the ID of your modal
}
function OpenConfirmModel() {
    $(document).ready(function () {
        $('#ConfirmModal').modal('show');
    });
}
//window.deletePopover = function () {
//    var deleteBtn = document.getElementById("delete-category-btn");
//    var isDisabled = deleteBtn.getAttribute('disabled');
//    if (isDisabled === 'true' || isDisabled === '') {
//        $('.pop-delete-btn').popover({
//            trigger: 'hover', // or 'click' or other event
//            placement: 'top', // adjust as needed
//            content: 'يجب اختيار فئة لحذفها',
//        });
//    };
//}

window.initPopover = function () {
    const popoverTriggerList = document.querySelectorAll('[data-bs-toggle="popover"]');
    const popoverList = [...popoverTriggerList].map(popoverTriggerEl => new bootstrap.Popover(popoverTriggerEl));
};

window.successErorrModal = function () {
    var overlay = document.getElementById("overlay");
    var popupContainer = document.getElementById("popup-container");
    var success_popup = document.getElementById("success");
    var error_popup = document.getElementById("error");
    var s_close = document.getElementById("s_button");
    var e_close = document.getElementById("e_button");
    var s_btn = document.getElementById("success_trigger");
    var e_btn = document.getElementById("error_trigger");

    s_btn.onclick = function () {
        overlay.style.display = "block";
        popupContainer.style.display = "block";
        success_popup.style.display = "block";
    }

    e_btn.onclick = function () {
        overlay.style.display = "block";
        popupContainer.style.display = "block";
        error_popup.style.display = "block";
    }

    s_close.onclick = function () {
        overlay.style.display = "none";
        popupContainer.style.display = "none";
        success_popup.style.display = "none";
    }

    e_close.onclick = function () {
        overlay.style.display = "none";
        popupContainer.style.display = "none";
        error_popup.style.display = "none";
    }
};

window.showSuccessModal = function () {
    var success_popup = document.getElementById("success");
    success_popup.style.display = "block";
}
window.successErorrModalTwo = function () {
    
    var buttons = document.querySelectorAll(".modal_btns button");
    var close_btns = document.querySelectorAll(".close_btn");
    var modal_wrapper = document.querySelector(".modal_wrapper");
    var s_modal = document.querySelector(".s_modal");
    var e_modal = document.querySelector(".e_modal");

    buttons.forEach(function (btn) {
        btn.addEventListener("click", function () {
            modal_wrapper.classList.add("active");
            if (btn.classList.contains("success_btn")) {
                s_modal.classList.add("active");
                e_modal.classList.remove("active");
            }
            else if (btn.classList.contains("error_btn")) {
                s_modal.classList.remove("active");
                e_modal.classList.add("active");
            }
        });
    });

    close_btns.forEach(function (close) {
        close.addEventListener("click", function () {
            modal_wrapper.classList.remove("active");
            s_modal.classList.remove("active");
            e_modal.classList.remove("active");
        });
    });
};


