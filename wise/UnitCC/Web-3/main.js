const listItems = document.querySelectorAll("div");

let previousClassName = "";

function toggleDone(e) {
    console.log("the previous class name was" + previousClassName);
    if (e.target.className != "done") {
        e.target.className = "done";
    } else {
        e.target.className = previousClassName;
    }
}

listItems.forEach((item) => {
    previousClassName = item.className;
    item.addEventListener("click", toggleDone);
});