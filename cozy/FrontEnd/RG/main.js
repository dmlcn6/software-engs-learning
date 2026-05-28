import { dragoverHandler, dragstartHandler, dropHandler, wallet, bets, spin } from "./player.js";
import { generateRandomNumber } from "./board.js";

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
chips.forEach((item) => {
    item.addEventListener("dragstart", dragstartHandler);
});

// grab and drop ability to all the spots for a chip to be placed
const allBetableSpots = document.querySelectorAll(".number,.bet,.left-side-bets");
allBetableSpots.forEach((betSpot) => {
    betSpot.addEventListener("dragover", dragoverHandler);
    betSpot.addEventListener("drop", dropHandler);
});

const spinButton = document.querySelector(`#spin-button`);
spinButton.addEventListener("click", spin);
