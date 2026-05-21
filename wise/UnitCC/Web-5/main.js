import { generateRandomColor, generateRandomNumber } from "./board.js";

const slotOptions = document.querySelectorAll(".slot");
const categoryOptions = document.querySelectorAll(".category-Option");
const chipContainer = document.querySelectorAll(".chip-Pieces-Container")
const _1to12slots = document.querySelectorAll("._1to12Slots");
const _13to24slots = document.querySelectorAll("._13to24Slots");
const _25to36slots = document.querySelectorAll("._25to36Slots");
const playerWallet = document.querySelector("#money-Count");

const betAction = new Map();
let moneyAvailable = 1000;




slotOptions.forEach((item) => {
    item.addEventListener("mouseenter", HoverFeedbackSlot);
    item.addEventListener("mouseleave", HoverResetSlot);
});
categoryOptions.forEach((item) => {
    item.addEventListener("mouseenter", HoverFeedbackCategory);
    item.addEventListener("mouseleave", HoverResetCategory);
});

//--------------------------------------------------------



//--------------------------------------------------------

function HoverFeedbackSlot(e) {
    e.target.setAttribute('style', 'background-color: #0051ff;');
};
function HoverResetSlot(e) {
    e.target.setAttribute('style', '');
};



function HoverFeedbackCategory(e) {
    e.target.setAttribute('style', 'background-color: #0051ff;');
    let objID = e.target.id;
    const objSeeker = `.${objID}`

    const objSeekerResults = document.querySelectorAll(objSeeker);
    objSeekerResults.forEach((item) => {
        item.setAttribute('style', 'background-color: #0051ff;');
    })
}
function HoverResetCategory(e) {
    e.target.setAttribute('style', '');
    let objID = e.target.id;
    const objSeeker = `.${objID}`

    const objSeekerResults = document.querySelectorAll(objSeeker)
    objSeekerResults.forEach((item) => {
        item.setAttribute('style', '');
    })
}

function dragBeginHandler(e) {
    // adds the data to the obj being dragged
    e.dataTransfer.setData("text", e.target.className);

    // creates a duplicate so the chip remains even after it's been dragged
    e.dataTransfer.effectAllowed = "copy";
}
function dragDuringHandler(e) {
    // removes the default drag behavior from the obj
    e.preventDefault();

    // "allows copy on drop?" (i need review)
    e.dataTransfer.dropEffect = "copy";
}
function dropHandler(e) {
    e.preventDefault();

    // Takes the dragged obj's data
    const data = e.dataTransfer.getData("text");

    // queries the element from the dragged data (classname) (i need review)
    const originObj = document.querySelector(`.${data}`);

    // duplicates the obj and attaches it to the target
    const dupliObj = originObj.cloneNode(true);
    e.target.appendChild(dupliObj);

    let objID = e.target.id;

    if (objID in betAction) {
        let objbets = betAction.objID;
        objbets.push(data);
        return;
    }

    betAction.set(objID, [data]);
}

//----------------------------------------------------------



//----------------------------------------------------------

let number = generateRandomNumber();

//--------------------------------------------------------



//--------------------------------------------------------

const chips = document.querySelectorAll(".chip-Pieces-Container");
chips.forEach((item) => {
    item.addEventListener("dragstart", dragBeginHandler);
});

const possibleBetSlot = document.querySelectorAll(".slot,.category-Option,.betAction");
possibleBetSlot.forEach((betSlot) => {
    betSlot.addEventListener("dragover", dragDuringHandler);
    betSlot.addEventListener("drop", dropHandler);
});

//--------------------------------------------------------



//--------------------------------------------------------

//how much has the player bet
// what we need
// - chip list from player
// - go through the list and add up the chip
// - get the total chips and equate to currency

// once a chip is on the board the player gains the ability to BET!

// once BET! is selected
// - create a win color AND number
// - create winning groupings (category classes)

// obtain the player chip selections
// obtain the color, number, and groups the player has placed chips on

// compare the wining groupings
// compare the player groupings

// calculate winnings or losings.

