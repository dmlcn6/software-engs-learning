import { generateRandomColor, generateRandomNumber } from "./board.js";

const slotOptions = document.querySelectorAll(".slot");
const categoryOptions = document.querySelectorAll(".category-Option");

slotOptions.forEach((item) => {
    item.addEventListener("mouseenter", selectionFeedbackSlot);
    item.addEventListener("mouseleave", selectionResetSlot);
});
categoryOptions.forEach((item) => {
    item.addEventListener("mouseenter", selectionFeedbackCategory);
    item.addEventListener("mouseleave", selectionResetCategory);
});

function selectionFeedbackSlot(e) {
    e.target.setAttribute('style', 'background-color: #ffff21;');
};
function selectionResetSlot(e) {
    e.target.setAttribute('style', '');
};


function selectionFeedbackCategory(e) {
    const categorySelection = e.target.classList[0];
    if (item.classList.contains(categorySelection)) {
        item.setAttribute('style', 'background-color: #ffff21;');
    }

}
function selectionResetCategory(e) {

}

let color = generateRandomColor();
let number = generateRandomNumber();
