import { useState } from "react";


function Square( {value, fillInSquare}: {value: string, fillInSquare: () => void}) {
  
  
  return <button className="square" onClick={fillInSquare}> {value} </button>
}


function Board() {
  const [squares, setSquares] = useState<string[]>(Array(9).fill(""));

  function onSquareClick(i:number): void {
    const newSqares = squares.slice();
    newSqares[i] = 'X';
    setSquares(newSqares);
  }


  return (
  <div>
    <div className="board-row">
      <Square value={squares[0]} fillInSquare={() => onSquareClick(0)}/>
      <Square value={squares[1]} fillInSquare={() => onSquareClick(1)}/>
      <Square value={squares[2]} fillInSquare={() => onSquareClick(2)}/>
    </div>
    <div className="board-row">    
      <Square value={squares[3]} fillInSquare={() => onSquareClick(3)}/>
      <Square value={squares[4]} fillInSquare={() => onSquareClick(4)}/>
      <Square value={squares[5]} fillInSquare={() => onSquareClick(5)}/>
    </div>
    <div className="board-row">
      <Square value={squares[6]} fillInSquare={() => onSquareClick(6)}/>
      <Square value={squares[7]} fillInSquare={() => onSquareClick(7)}/>
      <Square value={squares[8]} fillInSquare={() => onSquareClick(8)}/>
    </div>
  </div>);
}

export default function App() {
  return (
    <>
      <Board />
    </>
  )
}