function setUserName() {
    const myName = prompt("Please enter your name.");
    if (!myName) {
        setUserName();
    } else {
        localStorage.setItem("name", myName);
        myHeading.textContent = `COZY BLOG is cool, ${myName}`;
    }
}

const myImage = document.querySelector("img");

myImage.addEventListener("mouseenter", () => {
    const mySrc = myImage.getAttribute("src");
    if (mySrc === "../CS6/BlogImages/DropoutBear.png") {
        myImage.setAttribute("src", "../CS6/BlogImages/DropoutBearBW.png")
    } else {
        myImage.setAttribute("src", "../CS6/BlogImages/DropoutBear.png");
    }
})

myImage.addEventListener("mouseleave", () => {
    const mySrc = myImage.getAttribute("src");
    if (mySrc === "../CS6/BlogImages/DropoutBearBW.png") {
        myImage.setAttribute("src", "../CS6/BlogImages/DropoutBear.png")
    } else {
        myImage.setAttribute("src", "../CS6/BlogImages/DropoutBearBW.png")
    }
})
let myButton = document.querySelector("button");
let myHeading = document.querySelector("#title");

if (!localStorage.getItem("name")) {
    setUserName();
} else {
    const storedName = localStorage.getItem("name");
    myHeading.textContent = `COZY BLOG is cool, ${storedName}`;
}

myButton.addEventListener("click", () => {
    setUserName();
});
