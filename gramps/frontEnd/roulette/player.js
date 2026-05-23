import { generateRandomNumber } from "./number.js";
export let wallet = 1000;
export const bets = new Map();

// {key: value} - > {_1st12: [1,1], _1: [1,1,1,]}
export const colors = new Map(); 


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
  let data = ev.dataTransfer.getData("text");

  // queries the element from teh dragged data(className)
  const ogElement = document.querySelector(`.${data}`);
  
  // clones the element and appends to target 
  const copyElement = ogElement.cloneNode(true);
  ev.target.appendChild(copyElement);

  data = data.replace("_", "");
  data = Number(data);

  let targetId = ev.target.id;
  // going to add the bet to the dict of bets, using key
  // before setting new key, check if key exists
  
  if (bets.has(targetId)) {
    // the user has placed a bet on this target
    // so lets grab the previous bets and append
    let targetBets = bets.get(targetId);
    targetBets.push(data);
    // check if its a bet on a single  numbner
    // remove underscore
    // this is the chip amount
    

    // if (+data)
    // if (Number(data))
    // thesse try to parse data as an integer and return NaN (not a num, if not)

    /*
    if (Number(data)){

      let number = Number(data);
      
      targetBets.push(number);
      return;
    }
    else if(data === "red" || data === "black"){

      targetBets.push(data);

      return;
    }else {

      targetBets.push(data); 

      return;
    }
    */
  }
  else {
    bets.set(targetId, [data]);
  }

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


function compareGroupings(color, number) {

  [is1st12, is2nd12, is3rd12, is1to18, is19to36, isEven, isOdd] = findNumberHits(number);
  [isBlack, isRed] = findColorHits(color);

  // compare groupings of bets to winning groups
  bets.forEach((value, playerBet) => {
    let penalty = 0;
    let winning = 0;
    let stakeAmount = value.reduce((sum, current) => sum + current, 0);

    if (playerBet.contains("odd")) {
      if(isOdd){
        winning += stakeAmount * 1;
      }
    }

    if (playerBet.contains("even")) {
      if(isEven){
        winning += stakeAmount * 1;
      }
    }

    // find grouping for key
    if (playerBet === 'red') {
      if (isRed === true) {  
        winning += stakeAmount * 1;
      }
    }

    // find grouping for key
    if (playerBet === 'black') {
      if (isBlack) {  
        winning += stakeAmount * 1;
      }
    }

    if (playerBet.contains("1st12")) {
      if (is1st12) {
        winning += stakeAmount * 2;
      }
    }

    if (playerBet.contains("2nd12")) {
      if (is2nd12) {
        winning += stakeAmount * 2;
      }
    }

    if (playerBet.contains("3rd12")) {
      if (is3rd12) {
        winning += stakeAmount * 2;
      }
    }

    if (playerBet instanceof Number) {
      if (playerBet === number) {
        // straight up is 35:1 
        winning += stakeAmount * 35;
      }
    }
    
    if (playerBet.contains("1to18")) {
      if (is1to18) {
        winning += stakeAmount * 3;
      }
    }

    if (playerBet.contains("19to36")) {
      if (is19to36) {
        winning += stakeAmount * 3;
      }
    }
    
    // check if grouping is marked as true in winning set
    // if true, grab value from key (list), sum of elements 
    // multply sum of bets * multiplier -> winnnigns
    // add original bet
    return winning;
  });

}


function findNumberHits(number) {
  let is1st12 = false;
  let is2nd12 = false;
  let is3rd12 = false;
  let is1to18 = false;
  let is19to36 = false;
  let isEven = false;
  let isOdd = false;

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
  }

  return (is1st12, is2nd12, is3rd12, is1to18, is19to36, isEven, isOdd);
  
};


function findColorHits(color) {
  
  let isRed = false;
  let isBlack = false;

  if (color === "red"){
    isRed = true;
  }
  else {
    isBlack = true;
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
  }

  return (is1st12, is2nd12, is3rd12, is1to18, is19to36, isEven, isOdd, isRed, isBlack);
  
};


export function spin(ev) {
  // let winner = getNumber(); same as below
  let [color, number, numberTag] = getWinningNumber();
  
  addWinningNumberToHistory(numberTag);

  let fullStakeAmount = 0;
  bets.forEach((value, key) => {
    // find grouping for key
    fullStakeAmount += value.reduce((sum, current) => sum + current, 0)
  });


  wallet -= fullStakeAmount;
  wallet += compareGroupings(color, number);
  
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