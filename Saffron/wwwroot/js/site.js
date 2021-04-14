
// Card
Array.prototype.forEach.call(document.querySelectorAll('.mdl-card__media'), function (el) {
    var link = el.querySelector('a');
    if (!link) {
        return;
    }
    var target = link.getAttribute('href');
    if (!target) {
        return;
    }
    el.addEventListener('click', function () {
        location.href = target;
    });
});


// Go to top
var gotToTopBtn = document.getElementById("go-to-top");
window.onscroll = function () { scrollFunction() };
function scrollFunction() {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        gotToTopBtn.style.display = "block";
    } else {
        gotToTopBtn.style.display = "none";
    }
}
function goToTopFunction() {
    window.scroll({ top: 0, behavior: "smooth" });
}

