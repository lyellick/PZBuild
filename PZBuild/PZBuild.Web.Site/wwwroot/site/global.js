function message(message) { document.querySelector("#alert div span").innerText = message, document.getElementById("alert").classList.remove("close"), document.getElementById("alert").classList.add("open"), setTimeout(() => { document.getElementById("alert").classList.remove("open"), document.getElementById("alert").classList.add("close") }, 3500) }

var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
});