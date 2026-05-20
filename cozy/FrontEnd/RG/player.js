

export let wallet = 1000;
export let bets = [];

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
    const data = e.dataTransfer.getData("text");

    //quieries the targeted element
    const original = document.querySelector(`.${data}`);

    //clones the targeted element and appends to destination
    const ogCopy = original.cloneNode(true);
    e.target.appendChild(ogCopy);
}

