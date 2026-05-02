function highlightSquares(e){
    let target = e.target;

    let idNameName = target.id;
    const searchQuery = `.${idNameName}`

    const allHTMLTagsToHighlight = document.querySelectorAll(searchQuery);
    allHTMLTagsToHighlight.forEach((item) => { 
        item.style.backgroundColor = 'blue';
    });
}

const button_1st12 = document.querySelector("#_1st12");
button_1st12.addEventListener("mouseenter", function(e) {
    highlightSquares(e);
});