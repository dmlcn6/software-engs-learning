const slotOptions = document.querySelectorAll(".slot");
const categoryOptions = document.querySelectorAll(".category-Option");

slotOptions.forEach((item) => {
    item.addEventListener("mouseenter", selectionFeedback);
    item.addEventListener("mouseleave", selectionreset)
});

function selectionFeedback(e) {
    e.target.setAttribute('style', 'background-color: #a1a13e;');
};

function selectionreset(e) {
    e.target.setAttribute('style', '');
};