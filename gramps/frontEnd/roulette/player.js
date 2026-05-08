let wallet = 1000;
let bets = [];

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

export function dropHandler(ev) {
  ev.preventDefault();

  // grabs the dragged data
  const data = ev.dataTransfer.getData("text");

  // queries the element from teh dragged data(className)
  const ogElement = document.querySelector(`.${data}`);
  
  // clones the element and appends to target 
  const copyElement = ogElement.cloneNode(true);
  ev.target.appendChild(copyElement);
}