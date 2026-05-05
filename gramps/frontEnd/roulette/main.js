function highlightSquares(e){
    let target = e.target;

    let idNameName = target.id;
    const searchQuery = `.${idNameName}`

    const allHTMLTagsToHighlight = document.querySelectorAll(searchQuery);
    allHTMLTagsToHighlight.forEach((item) => { 
        item.style.backgroundColor = 'blue';
    });
}

function unhighlightSquares(e){
    let target = e.target;

    let idNameName = target.id;
    const searchQuery = `.${idNameName}`

    const allHTMLTagsToHighlight = document.querySelectorAll(searchQuery);
    allHTMLTagsToHighlight.forEach((item) => { 
        item.style.backgroundColor = '';
    });
}

const highlightButtons = document.querySelectorAll(".bet");
highlightButtons.forEach((item) => {
    item.addEventListener("mouseenter", function(e) {
        highlightSquares(e);
    });

    item.addEventListener("mouseleave", function(e) {
        unhighlightSquares(e);
    });
});
