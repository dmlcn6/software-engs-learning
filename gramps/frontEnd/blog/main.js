const listItems = document.querySelectorAll("div");
let previousClassName = "";

function toggleDone(e) {
  if (e.target.className != "done") {
    previousClassName = e.target.className;
    e.target.className = "done";
  } else {
    console.log("previous class name = " + previousClassName);
    e.target.className = previousClassName;
  }
}

listItems.forEach((item) => {
  item.addEventListener("mouseenter", toggleDone);
});