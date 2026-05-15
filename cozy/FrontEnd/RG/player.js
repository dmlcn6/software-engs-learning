

export let wallet = 1000;
export let bets = [];

//determine the data to grab
export function dragstartHandler(e) {
    e.dataTransfer.setData("text", e.target.className);

    // allows copy operation, instead of replace
    e.dataTransfer.effectAllowed = 'copy';
}

//prevents the default behavior of an element. Allows element to be placed onto another
export function dragoverHandler(e) {
    e.preventDefault();

    //copies on drop
    e.dataTransfer.dropEffect = 'copy';
}

// placing a chip on a bet spot
export function dropHandler(e) {
    e.preventDefault();
    const data = e.dataTransfer.getData("text");
    e.target.appendChild(document.getElementById(data));
}

