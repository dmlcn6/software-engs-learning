import { generateRandomColor, generateRandomNumber } from "./board.js";

const slotOptions = document.querySelectorAll(".slot");
const categoryOptions = document.querySelectorAll(".category-Option");
const _1to12slots = document.querySelectorAll("._1to12Slots");
const _13to24slots = document.querySelectorAll("._13to24Slots");
const _25to36slots = document.querySelectorAll("._25to36Slots");



slotOptions.forEach((item) => {
    item.addEventListener("mouseenter", HoverFeedbackSlot);
    item.addEventListener("mouseleave", HoverResetSlot);
});
categoryOptions.forEach((item) => {
    item.addEventListener("mouseenter", HoverFeedbackCategory);
    item.addEventListener("mouseleave", HoverResetCategory);
});

function HoverFeedbackSlot(e) {
    e.target.setAttribute('style', 'background-color: #ffff21;');
};
function HoverResetSlot(e) {
    e.target.setAttribute('style', '');
};


function HoverFeedbackCategory(e) {
    let objID = e.target.id;
    const objSeeker = `.${objID}`

    const objSeekerResults = document.querySelectorAll(objSeeker);
    objSeekerResults.forEach((item) => {
        item.setAttribute('style', 'background-color: #ffff21;');
    })
}

function HoverResetCategory(e) {
    objSeekerResults.forEach((item) => {
        item.setAttribute('style', '');
    })
}

let color = generateRandomColor();
let number = generateRandomNumber();
