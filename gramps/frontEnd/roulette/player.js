import { generateRandomColor, generateRandomNumber } from "./number.js";

export let wallet = 1000;
export const bets = new Map();

export function placeBet() {
    let allBetableSpots = document.querySelectorAll(".number,.bet");
}

export function dragstartHandler(ev) {
  // sets the data that is being dragged
  ev.dataTransfer.setData("text", ev.target.className);

  // allows copy operation, instead of replace
  ev.dataTransfer.effectAllowed = 'copy';
}

export function dragoverHandler(ev) {
  // prevents default behavior of an element disabling another element to be dragged in it
  ev.preventDefault();

  // allows copy on drop
  ev.dataTransfer.dropEffect = 'copy';
}

// placing a chip on a bet spot
export function dropHandler(ev) {
  ev.preventDefault();

  // grabs the dragged data, the chip to bet
  const data = ev.dataTransfer.getData("text");

  // queries the element from teh dragged data(className)
  const ogElement = document.querySelector(`.${data}`);
  
  // clones the element and appends to target 
  const copyElement = ogElement.cloneNode(true);
  ev.target.appendChild(copyElement);

  let targetId = ev.target.id;
  // going to add the bet to the dict of bets, using key
  // before setting new key, check if key exists
  if (targetId in bets) {
    // the user has placed a bet on this target
    // so lets grab the previous bets and append
    let targetBets = bets.targetId;
    targetBets.push(data); 
    return;
  }
  
  bets.set(targetId, [data]);

  // once a bet has been placed, enable the spin button
  const spinButtonSelector = `#spin-button`
  let spinButton = document.querySelector(spinButtonSelector);
  spinButton.disabled = false;
}

function getNumber() {
    // now generate the winning number
    let number = generateRandomNumber();
    let query = `#_${number}`;
    let numberHTMLTag = document.querySelector(query);
    let copyOfNumberTag = numberHTMLTag.cloneNode();
    let color = 'black';
    if (numberHTMLTag.classList.contains("red")) {
        color = 'red'
    }

    return [color, number, copyOfNumberTag];
}

export function spin(ev) {
  let winner = getNumber();
  
  // add winner to history
  let historyTagSelector = `.roulette-history-container`;
  let historyTag = document.querySelector(historyTagSelector);
  historyTag.appendChild(winner[2]);

}