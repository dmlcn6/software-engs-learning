const listItems = document.querySelectorAll("div");

let previousClassName = ""

function toggleDone(e) {
    if (!e.target.className) {
        e.target.className = "done";
    } else {
        e.target.className = previousClassName;
    }
}

listItems.forEach((item) => {
    previousClassName = item.className;
    item.addEventListener("click", toggleDone);
});