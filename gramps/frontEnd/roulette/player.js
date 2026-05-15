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

    // todo: remove _ and cast as number
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
    let copyOfNumberTag = numberHTMLTag.cloneNode(true);
    let color = 'black';
    if (numberHTMLTag.classList.contains("red")) {
        color = 'red'
    }

    return [color, number, copyOfNumberTag];
}

function findHits(color, number) {
  let is1st12 = false;
  let is2nd12 = false;
  let is3rd12 = false;
  let is1to18 = false;
  let is19to36 = false;
  let isEven = false;
  let isOdd = false;
  let isRed = false;
  let isBlack = false;

  if (color === "red"){
    isRed = true;
  }
  else {
    isBlack = true;
  }

  if (number % 2 === 0) {
    isEven = true;
  }
  else {
    isOdd = true;
  }

  if (number < 19) {
    is1to18 = true;
  }
  else {
    is19to36 = true;
  }

  if ( Math.ceil(number/12) === 1){
    is1st12 = true;
  }
  else if ( Math.ceil(number/12) === 2){
    is2nd12 = true;
  }
  else if ( Math.ceil(number/12) === 3){
    is3rd12 = true;
  }

  for (const [key, value] of bets.entries())  {
    
    let k = key;
    let v = value;


    let betNum = -1;
    try {
      betNum = parseInt(k);
    }
    catch {
      // cant parse
    }

    if (betNum > -1) {
      // its a bet on a number, handle slightly diff

    }
    else {
      // its a side bet
      if(k.contains("1st12") && is1st12) {
        // win
      }
      
      if (k.contains("2nd12") && is2nd12) {
        // win
      }
      
      if (k.contains("3rd12") && is3rd12) {
        //win
      }
      
      if (k.contains("1to18") && is1to18) {
        // win
      } 
      
      if (k.contains("19to36") && is19to36) {
        // win
      }

      if (k.contains("odd") && isOdd) {
        // win
      }
      
      if (k.contains("even") && isEven) {
        // win
      }
      
    }
  };
}

export function spin(ev) {
  let winner = getNumber();
  
  // add winner to history
  let historyTagSelector = `.roulette-history-container`;
  let historyTag = document.querySelector(historyTagSelector);
  let winnerHTMLTag = winner[2];
  if (winnerHTMLTag.childNodes.length > 2)
    winnerHTMLTag.removeChild(winnerHTMLTag.children[1]);
  historyTag.appendChild(winnerHTMLTag);

  findHits(winner[0], winner[1]);

  
  
}

