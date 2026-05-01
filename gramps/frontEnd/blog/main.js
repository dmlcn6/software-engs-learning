
function setUserName() {
  const myName = prompt("Please enter your name.");
  if (!myName) {
    setUserName();
  }
  else {
    localStorage.setItem("name", myName);
  
    myHeading.textContent = `Mozilla is cool, ${myName}`;
  }
}

const myImages = document.querySelectorAll(".blog-media-content img");
let myButton = document.querySelector("button");
let myHeading = document.querySelector("#main-blog-title");

if (!localStorage.getItem("name")) {
  setUserName();
} else {
  const storedName = localStorage.getItem("name");
  myHeading.textContent = `Mozilla is cool, ${storedName}`;
}


myButton.addEventListener("click", () => {
  setUserName();
});

myImages.forEach((image) => {
  image.addEventListener("click", () => {
    const mySrc = image.getAttribute("src");

    if (mySrc === '../blog/images/greek-island.jpg') {
      image.setAttribute("src", '../blog/images/beehive.jpg')
    }
    else {
      image.setAttribute("src", '../blog/images/greek-island.jpg');
    }
  });
});
