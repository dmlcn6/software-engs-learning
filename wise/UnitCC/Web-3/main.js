const PostImages = document.querySelectorAll(".post-image");

PostImages.forEach((image) => {
    image.addEventListener("mouseenter", changeImage);
});

function changeImage(e) {
    const mySrc = e.target.getAttribute("src");
    if (mySrc === "../Media/Images/PlaceHolderImage1.jpg") {
        e.target.setAttribute("src", "../Media/Images/PlaceHolderImage2.jpg");
    } else if (mySrc === "../Media/Images/PlaceHolderImage2.jpg") {
        e.target.setAttribute("src", "../Media/Images/PlaceHolderImage3.jpg");
    } else {
        e.target.setAttribute("src", "../Media/Images/PlaceHolderImage1.jpg");
    }
};