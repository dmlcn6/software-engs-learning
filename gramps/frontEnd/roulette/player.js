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

function getWinningNumber() {
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

function addWinningNumberToHistory(numberTag) {
  // add winner to history
  let historyTagSelector = `.roulette-history-container`;
  let historyTag = document.querySelector(historyTagSelector);
  
  // historyTag.appendChild(winner[2]); same as below
  historyTag.appendChild(numberTag);
}

export function spin(ev) {
  // let winner = getNumber(); same as below
  let (color, number, numberTag) = getWinningNumber();
  
  addWinningNumberToHistory(numberTag);


  
}


//we want to know how much the player has bet
// we need a list of bets from the player
// iterate thru the list and add  up the bets
// total bets\

// once bets placed, player can spin
// player cannot spin, if no bets on table
// once they spin,
  // generate winning color,number
  // generate winning groupings (side-bets)

// gather the bets of the player
// generate player color,number,groups

// compare winning groupings
// compare player groupings

// calculate winning money, if any (still need more psuedocode)