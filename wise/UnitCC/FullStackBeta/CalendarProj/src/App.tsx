import { useState } from 'react'
import './App.css'

function App() {
  const [username, setUsername] = useState('')

  return (
    <>
      <div className="TopBar">
        <h1>Welcome to my Calendar</h1>
      </div>
    </>
  )
}

export default App
