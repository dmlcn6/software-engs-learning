const myImages = document.querySelectorAll(".blog-media-content img");

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