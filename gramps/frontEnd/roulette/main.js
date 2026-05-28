import { placeBet, dragstartHandler, dragoverHandler, dropHandler, wallet, bets, spin, clear } from "./player.js";
import { generateRandomNumber } from "./number.js";7

function highlightSquares(e){
    let target = e.target;

    let idNameName = target.id;
    const searchQuery = `.${idNameName}`

    const allHTMLTagsToHighlight = document.querySelectorAll(searchQuery);
    allHTMLTagsToHighlight.forEach((item) => { 
        item.style.backgroundColor = 'yellow';
    });
}

function unhighlightSquares(e){
    let target = e.target;

    let idNameName = target.id;
    const searchQuery = `.${idNameName}`

    const allHTMLTagsToHighlight = document.querySelectorAll(searchQuery);
    allHTMLTagsToHighlight.forEach((item) => { 
        item.style.backgroundColor = '';
    });
}

// grab and add un/highlight events to the side bets
const highlightButtons = document.querySelectorAll(".bet");
highlightButtons.forEach((item) => {
    item.addEventListener("mouseenter", function(e) {
        highlightSquares(e);
    });

    item.addEventListener("mouseleave", function(e) {
        unhighlightSquares(e);
    });
});

// grab and add drag ability to chips
const chips = document.querySelectorAll(".roulette-chips-container img");
chips.forEach((item) => {
    item.addEventListener("dragstart", dragstartHandler);
});

// grab and drop ability to all the spots for a chip to be placed
const allBetableSpots = document.querySelectorAll(".number,.bet");
allBetableSpots.forEach( (betSpot) => {
    betSpot.addEventListener("dragover", dragoverHandler);
    betSpot.addEventListener("drop", dropHandler);
});

const spinButton = document.querySelector("#spin-button");
spinButton.addEventListener("click", spin)

const clearButton = document.querySelector("#clear-button");
clearButton.addEventListener("click", clear)

