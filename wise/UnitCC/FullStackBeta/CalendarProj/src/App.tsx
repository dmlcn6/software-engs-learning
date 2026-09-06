import { useState } from 'react'
import './App.css'
import CalendarContext from './CalendarContext.ts'

//1. identify your components
//2. identify your behaviours/states
//3. identify your data flow between componenets
// ^^^^^^^^ THATS ALL MOCK UP ^^^^^^^
//4. build simple static version with mock data.  do not use state yet, only component props when needed
//5. identify your minimal state data (minimal set of changing data that your app needs to remember)
//6. identify where your state lives 


/* AC
 Use components
 use arrays / list / objects
 parent child nesting
 use state and reducer / context
 input form to take in a username
 local storage api - save a user session once they have inputted the form 
 (even if the user has closed out and reopened the webpage)
*/

// we want to start small, display one month
const months = ['January','February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
const monthsDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
const daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thur', 'Fri', 'Sat'];

function Selector({direction, currentMonth, updateMonth}: {direction: string, currentMonth: number, updateMonth: (x:number) => void}) {
  
  const arrow = direction === 'west' ? '<' : '>';

  function clickHandler() {
    if (direction == "west")
    {
      //decrement month state
      updateMonth(currentMonth - 1);
    } else {
      //increment month state
      updateMonth(currentMonth + 1);
    }
  }


  return (
    <>
      <h6 onClick={ () => clickHandler() }>{arrow}</h6>
    </>
  )
}

function Days({ numDays }: { numDays: number }) {
  
  const allDays = []

  for (let i = 0; i < numDays; i++) {
    const dayElement = <h4>{i + 1}</h4>
    allDays.push(dayElement)
    
  }
  return (
    <div id='day-grid'>
    {allDays}
    </div>
)
}

function DaysOfWeek() {
  const days = daysOfWeek.map((day: string) => {return <h5>{ day }</h5>})
  return (
    <div id='dayOfWeek-grid'>
      {days}
    </div>
  )
}

function Month({ monthIndex, year, updateMonth }: {monthIndex: number, year: number, updateMonth: (x:number) => void } ) {
  
  const monthName = months[monthIndex]
  
  return (
    <div id='mainContext'>
      <h3>{monthName} {year}</h3>
      <div id='sideContext'>
        <Selector direction='west' currentMonth={monthIndex} updateMonth={updateMonth}></Selector>
        <Selector direction='east' currentMonth={monthIndex} updateMonth={updateMonth}></Selector>
      </div>
    </div>
  )
}

function Calendar() {
  const [monthIndex, setMonthIndex] = useState(1);
  // duplicative - const [numberOfDays, setNumOfDays] = useState(7);

  //const monthIndex = 7 -- (!! THIS IS NO LONGER NEEDED BECAUSE WERE USING STATE !!)
  const year = 2026
  const numDays = monthsDays[monthIndex]

  return (
    <>
      <Month monthIndex={monthIndex} year={year} updateMonth={setMonthIndex}></Month>  
      <DaysOfWeek></DaysOfWeek>
      <Days numDays={numDays}></Days>
    </>
  )
}

function App() {
  return (
    <>
      <Calendar></Calendar>
    </>
  )
}

export default App
