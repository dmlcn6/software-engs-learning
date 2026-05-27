import { generateRandomColor, generateRandomNumber } from "./board.js";

const slotOptions = document.querySelectorAll(".slot");
const categoryOptions = document.querySelectorAll(".category-Option");
const chipContainer = document.querySelectorAll(".chip-Pieces-Container")
const _1to12slots = document.querySelectorAll("._1to12Slots");
const _13to24slots = document.querySelectorAll("._13to24Slots");
const _25to36slots = document.querySelectorAll("._25to36Slots");
const playerWallet = document.querySelector("#walletValue");


let moneyAvailable = 5000;
playerWallet.textContent = [`$${moneyAvailable}`];
let PlyrChoices = { turn: 0, amount0: "0", optiontype0: "Empty", option0: "Empty", }




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


    choiceUpdater(originObj, e.target)

    // add the chip value to the chip slot

    //
}
function clearHandler(e) {
    location.reload(true);
}

//----------------------------------------------------------



//----------------------------------------------------------

function winGenerator() {
    let luckyNum = Math.floor(Math.random() * 37);
    //let luckyNum = 9


    for (let i = 1; i <= PlyrChoices.turn; i++) {
        let amount = PlyrChoices[`amount${i}`];
        let optiontype = PlyrChoices[`optiontype${i}`];
        let option = PlyrChoices[`option${i}`];

        switch (optiontype) {
            case "slot":
                if (luckyNum == parseInt(option)) {
                    outcomeCalculator("won", amount)
                }
                else if (luckyNum != option) {
                    outcomeCalculator("lost", amount)
                }
                else {
                    console.log("something went wrong1")
                }
                break;

            default:
                console.log("something went wrong2")
                break;
        }
    }

    PlyrChoices = { turn: 0, amount0: "0", optiontype0: "Empty", option0: "Empty", };
    historyUpdater(luckyNum);

}
function outcomeCalculator(status, amount) {
    if (status == "won") {
        moneyAvailable += amount;
    }
    else {
        moneyAvailable -= amount;
    }
}

//----------------------------------------------------------



//----------------------------------------------------------

function choiceUpdater(choiceChip, choiceLocation) {
    PlyrChoices.turn++;
    PlyrChoices = { ...PlyrChoices, [`amount${PlyrChoices.turn}`]: parseInt(choiceChip.classList[0].replace(/_/g, "")), [`optiontype${PlyrChoices.turn}`]: choiceLocation.classList[0], [`option${PlyrChoices.turn}`]: choiceLocation.textContent };

    informationUpdater(PlyrChoices.turn)
}
function historyUpdater(winNum) {

    const history = document.querySelector(".history-Container")
    let newAddition = document.createElement("div");

    newAddition.textContent = winNum.toString();
    if (winNum == 1 || 3 || 5 || 7 || 9 || 12 || 14 || 16 || 18 || 19 || 21 || 23 || 25 || 27 || 30 || 32 || 36 || 34) {
        newAddition.style.color = "red"
    }

    history.appendChild(newAddition);

}
function informationUpdater(locator) {
    const betCount = document.querySelector("#bet-Count");
    let betAmount = 0

    moneyAvailable -= PlyrChoices[`amount${locator}`];
    playerWallet.textContent = [`$${moneyAvailable}`];


    for (let i = 1; i <= PlyrChoices.turn; i++) {
        betAmount += PlyrChoices[`amount${i}`]
    }
    betCount.textContent = [`bet ct: $${betAmount}`]

}

//----------------------------------------------------------



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

const spinButton = document.querySelector("#feelingLucky");
const clearButton = document.querySelector("#feelingDoubtful")
spinButton.addEventListener("click", winGenerator);
clearButton.addEventListener("click", clearHandler)

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

