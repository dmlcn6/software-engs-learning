import { generateRandomNumber } from "./board.js";

export let wallet = 1000;
export const bets = new Map();

//determine the data to grab
export function dragstartHandler(e) {
    e.dataTransfer.setData("text", e.target.className);

    // allows copy operation, instead of replace
    e.dataTransfer.effectAllowed = 'copy';
}

export function dragoverHandler(e) {
    //prevents the default behavior of an element. Allows element to be placed onto another
    e.preventDefault();

    //allows copies on drop
    e.dataTransfer.dropEffect = 'copy';
}

// placing a chip on a bet spot
export function dropHandler(e) {
    e.preventDefault();

    //grabs the data being dragged(the chip we are betting)
    let data = e.dataTransfer.getData("text");

    //quieries the targeted element
    const original = document.querySelector(`.${data}`);

    //clones the targeted element and appends to destination
    const ogCopy = original.cloneNode(true);
    e.target.appendChild(ogCopy);

    data = data.replace("_", "");
    data = Number(data);

    let targetId = e.target.id;
    //adds bet to the dictionary of bets, using key
    // before setting new key, check if key exists

    if (bets.has(targetId)) {
        //grabs users bet on target
        let targetBets = bets.get(targetId);
        targetBets.push(data);
        //checks if bet is a single number

    }
    else {
        bets.set(targetId, [data])
    }

    //spin button enables after bet has been placed
    const spinButtonSelector = `#spin-button`;
    let spinButton = document.querySelector(spinButtonSelector);
    spinButton.disabled = false;

    //once a bet has been placed, clear button can be used to remove all bets
    const clearButtonSelector = `#clear-button`;
    let clearButton = document.querySelector(clearButtonSelector);
    clearButton.disabled = false;
}

function winningNumber() {
    let number = generateRandomNumber();
    let query = `#_${number}`;
    let numberTag = document.querySelector(query);
    // create a clean copy that preserves classes and text but omits child nodes (e.g., chips)
    let copyOfNumberTag = document.createElement(numberTag.tagName);
    copyOfNumberTag.className = numberTag.className;
    copyOfNumberTag.textContent = numberTag.textContent;
    let color = 'black';
    if (numberTag.classList.contains("red")) {
        color = 'red'
    }
    return [color, number, copyOfNumberTag];
}

function numberHistory(numberTag) {
    let historyTagSelector = `.roulette-history-container`;
    let historyTag = document.querySelector(historyTagSelector);

    historyTag.appendChild(numberTag)
}

export function spin(e) {
    let [color, number, numberTag] = winningNumber();

    numberHistory(numberTag);
}

export function clear(e) {
    // remove any chip elements placed on the board (but keep the originals in the chips container)
    const table = document.querySelector('.roulette-table-container');
    if (table) {
        const imgs = table.querySelectorAll('img');
        imgs.forEach(img => {
            if (!img.closest('.roulette-chips-container')) {
                img.remove();
            }
        });
    }

    // clear in-memory bets
    bets.clear();

    // disable spin and clear buttons until new bets are placed
    const spinButton = document.querySelector('#spin-button');
    const clearButton = document.querySelector('#clear-button');
    if (spinButton) spinButton.disabled = true;
    if (clearButton) clearButton.disabled = true;
}