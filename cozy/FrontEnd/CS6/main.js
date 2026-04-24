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