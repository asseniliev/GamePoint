// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggle(elementId) {
    const element = document.getElementById(elementId);
    if (element.style.display === "none") {
        element.style.display = "flex";
    } else {
        element.style.display = "none";
    }
}
