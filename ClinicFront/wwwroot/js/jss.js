function sidebar() {
    document.getElementById('side')?.classList.toggle('show-side');
}
function UserSideBar() {
    document.getElementById('UserSideBar')?.classList.toggle('show-side');
}
function scrollinto(id) {
    document.getElementById(id).scrollIntoView({ behavior: 'smooth' });
}
function checkEndOfContainer() {
    //const container = document.getElementById("main_container");
    const container = document.getElementById("main_container");
    container.addEventListener("scroll", function () {
        if (container.scrollHeight - container.scrollTop === container.clientHeight) {
            // Scrolled to the end of the container, trigger a callback to load more data
            DotNet.invokeMethodAsync("ClinicFront.Pages.User.Doctor", "GetPostPagination");
        }
    });
}
//window.checkEndOfContainer = () => {
//    const container = document.getElementById("main_container");
//    container.addEventListener("scroll", function () {
//        if (container.scrollHeight - container.scrollTop === container.clientHeight) {
//            // Scrolled to the end of the container, trigger a callback to load more data
//            DotNet.invokeMethodAsync("ClinicFront.Pages.User.Doctor", "GetPostPagination");
//        }
//    });
//};
