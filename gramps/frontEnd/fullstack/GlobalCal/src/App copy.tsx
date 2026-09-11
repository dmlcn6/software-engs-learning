import { useState } from 'react';
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

function Selector({direction}: {direction:string}) {
  
  const arrow = direction === 'prev' ? '<' : '>';

  return (
    <>
    <h4>{arrow}</h4>
    </>
  )
}

function Days({numDays}: {numDays:number}) {
  //const totalNumDays = monthsDays[7];
  const allDays = [];

  for (let i = 0; i < numDays; i++) {
    const dayElement = <h3>{i+1}</h3>;
    allDays.push(dayElement);
  }
  
  return (
    <div id='day-grid'>
      {allDays}
    </div>
  )
}

function DaysOfWeek() {

  const days = daysOfWeek.map((day:string) => {
    return (<h3>{day}</h3>)
  })
  return (
    <>
      {days}
    </>
  )
}

function Month({month,year}: {month:string, year:number}) {
  return (
    <>
      <h3> {month} {year} </h3>
      <Selector direction='prev'></Selector>
      <Selector direction='next'></Selector>
    </>
  )
}

function Calendar() {
    const [monthIndex, setMonthIndex] = useState(7);
    // duplicative - const [numberOfDays, setNumOfDays] = useState(7);

    //const monthIndex = 7;
    const year = 2026;
    const monthName = months[monthIndex];
    const numDays = monthsDays[monthIndex];

  return (
    <CalendarContext value={monthIndex}>
      <Month month={monthName} year={year}></Month>
      <DaysOfWeek></DaysOfWeek>
      <Days numDays={numDays}></Days>
    </CalendarContext>
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
