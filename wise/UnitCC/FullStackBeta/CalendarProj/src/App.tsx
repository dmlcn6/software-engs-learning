import { useState } from 'react'
import './App.css'

// 1. break apart into components
// 2. visuallize states for each component
// 3. how does the data flow through the components

function square({value, onSquareClick}: {value:string, onSquareClick: () => void}) {
  function handleClick() {
    onSquareClick();
  }

  return (
    <button className="square" onClick={handleClick}> {value} </button>
  )
}





function CalendarGrid() {
  const [squares, setSquares] = useState(Array(30).fill("_"));


  function handleClick(value: number) {
    console.log(squares[0])
  }


  function App() {
    const [username, setUsername] = useState('')

    return (
      <>
        <div className="TopBarSection">
          <h1>Welcome to my Calendar</h1>
        </div>
        <div className="MainSection">
          <body>test</body>
        </div>
      </>
    )
  }
  
}

export default square();
