import { placeBet, dragstartHandler, dragoverHandler, dropHandler } from "../roulette/player.js";

function highlightSquares(e){
    let target = e.target;

    let idNameName = target.id;
    const searchQuery = `.${idNameName}`

    const allHTMLTagsToHighlight = document.querySelectorAll(searchQuery);
    allHTMLTagsToHighlight.forEach((item) => { 
        item.style.backgroundColor = 'blue';
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



const highlightButtons = document.querySelectorAll(".bet");
highlightButtons.forEach((item) => {
    item.addEventListener("mouseenter", function(e) {
        highlightSquares(e);
    });

    item.addEventListener("mouseleave", function(e) {
        unhighlightSquares(e);
    });
});

// grab all chip html elements
const chips = document.querySelectorAll(".roulette-chips-container img");
// add drag start event to them
chips.forEach((item) => {
    item.addEventListener("dragstart", dragstartHandler);
});


// grab all the spots for a chip to be placed
const allBetableSpots = document.querySelectorAll(".number,.bet");
allBetableSpots.forEach( (betSpot) => {
    betSpot.addEventListener("dragover", dragoverHandler);
    betSpot.addEventListener("drop", dropHandler);
} );



placeBet();

