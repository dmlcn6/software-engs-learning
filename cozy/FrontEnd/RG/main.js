import { generateRandomColor, generateRandomNumber } from "./board.js";

function highlightSquares(e) {
    let target = e.target;

    let idName = target.id;

    const searchQuery = `.${idName}`

    const highlightedTags = document.querySelectorAll(searchQuery);
    highlightedTags.forEach((item) => {
        item.style.backgroundColor = 'yellow'
    });
}

function unhighlightSquares(e) {
    let target = e.target;

    let idName = target.id;
    const searchQuery = `.${idName}`

    const unhighlightedTags = document.querySelectorAll(searchQuery);
    unhighlightedTags.forEach((item) => {
        item.style.backgroundColor = '';
    });
}

const highlights = document.querySelectorAll(".bet");
highlights.forEach((item) => {
    item.addEventListener("mouseenter", function (e) {
        highlightSquares(e);
    });

    item.addEventListener("mouseleave", function (e) {
        unhighlightSquares(e);
    });
});

// grab all chip html elements
const chips = document.querySelectorAll(".roulette-chips-container img");





let color = generateRandomColor();
let number = generateRandomNumber();
