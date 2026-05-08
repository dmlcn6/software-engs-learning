let wallet = 1000;
let bets = [];

export function placeBet() {
    let allBetableSpots = document.querySelectorAll(".number,.bet");
}

export function dragstartHandler(ev) {
  ev.dataTransfer.setData("text", ev.target.id);
  ev.dataTransfer.effectAllowed = 'copy';
}

export function dragoverHandler(ev) {
  ev.preventDefault();
  ev.dataTransfer.dropEffect = 'copy';
}

export function dropHandler(ev) {
  ev.preventDefault();
  const data = ev.dataTransfer.getData("text");
  const ogElement = document.querySelector(`#${data}`);
  const copyElement = ogElement.cloneNode(true);
  ev.target.appendChild(copyElement);
}