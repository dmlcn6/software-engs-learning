import "./App.css";
import { useState } from 'react';
// "npm run" engine

function Square({value, onSquareClick}: {value:string, onSquareClick: () => void}) {
    
    function handleClick() {
        onSquareClick();
    }

    return (
        <button className="square" onClick={handleClick}> {value} </button>
    )
}

function Board() {

    const [squares, setSquares] = useState(Array(9).fill("_"));
    const [xIsNext, setXIsNext] = useState(true);

    const won = winningScenerio();
    let gamestate;
    if (won) {
        gamestate = "Winner: " + won;
    } else {
        gamestate = "Next Player: " + (xIsNext ? "X" : "O");
    }

    function winningScenerio() {
        const lines = [
            [0, 1, 2],
            [3, 4, 5],
            [6, 7, 8],
            [0, 3, 6],
            [1, 4, 7],
            [2, 5, 8],
            [0, 4, 8],
            [2, 4, 6]
        ];
        for (let i = 0; i < lines.length; i++) {
            const [a, b, c] = lines[i];
            if (squares[a] !== "_" && squares[a] === squares[b] && squares[a] === squares[c]) {
                return squares[a];
            }
        }
        return null;
    }

    function handleClick(value: number) {
        console.log(squares[0])

        if (squares[value] !== "_" || winningScenerio()) {
            return null;
        }
        console.log("we've made it wave 1")
        const nextSquares = squares.slice();
        if (xIsNext) {
            nextSquares[value] = "X";
        } else {
            nextSquares[value] = "O";
        }
        setSquares(nextSquares);
        setXIsNext(!xIsNext);
        console.log("we've made it wave 2")

        return null;
    }

    return (
        <>
            <div className="status">{gamestate}</div>
            <div className="board-row">
                <Square value={squares[0]} onSquareClick={() => handleClick(0)} />
                <Square value={squares[1]} onSquareClick={() => handleClick(1)} />
                <Square value={squares[2]} onSquareClick={() => handleClick(2)} />
            </div>
            <div className="board-row">
                <Square value={squares[3]} onSquareClick={() => handleClick(3)} />
                <Square value={squares[4]} onSquareClick={() => handleClick(4)} />
                <Square value={squares[5]} onSquareClick={() => handleClick(5)} />
            </div>
            <div className="board-row">
                <Square value={squares[6]} onSquareClick={() => handleClick(6)} />
                <Square value={squares[7]} onSquareClick={() => handleClick(7)} />
                <Square value={squares[8]} onSquareClick={() => handleClick(8)} />
            </div>
    </>
        
    )
}



export default function App() {
    return(
    <>
    <Board></Board>
        </>
    )
}