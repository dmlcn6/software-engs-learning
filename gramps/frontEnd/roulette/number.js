export function generateRandomNumber() {
    return Math.floor(Math.random() * 37);
}

export function generateRandomColor() {
    let color = Math.floor(Math.random() * 2);
    return color === 0 ? "red" : "black";
}