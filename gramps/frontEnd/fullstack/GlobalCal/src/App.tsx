import { useContext, useState } from 'react';
import './App.css'
import CalendarContext from './CalendarContext';


//1. identify your components
//2. identify your behaviours/states
//3. identify your data flow between componenets
// ^^^^^^^^ THATS ALL MOCK UP ^^^^^^^
//4. build simple static version with mock data.  do not use state yet, only component props when needed
//5. identify your minimal state data (minimal set of changing data that your app needs to remember)
  //- month
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

function Selector({i, direction, updateMonthIndex}: {i: number, direction: number, updateMonthIndex: (x:number) =>  void}) {
  function handleClick() {
    if (direction) {
      if (i == 11) {
        updateMonthIndex(0)
      
      }else {
        // increment month index
        updateMonthIndex(i+1)
      }
      
    }
    else {
      if (i == 0) {
        updateMonthIndex(11)
      }
      else {
      // decrement month index
      updateMonthIndex(i-1)
      }

    }
  }
  
  const arrow = direction == 0 ? '<' : '>';
  
  return (
    <h2 onClick={() => handleClick()}> {arrow} </h2>  
  )
}


function Day({dayOfWeek, dayNumber}: {dayOfWeek: string, dayNumber:number}) {
  return (
    <h3 className='day-comp'>{dayOfWeek} {dayNumber}</h3>
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
  
  return (
    <div id='week-grid'>
      {daysOfWeek.map((day:string) => {
        return (<p className='week-comp'>{day}</p>)
      })}
    </div>
  )
}

function UsernameInput() {

  function handleSubmitForm(e: React.SubmitEvent<HTMLFormElement>): void {
    e.preventDefault();
    const inputElement = e.target.elements.namedItem('uname') ?? null ;
    let value = '';

    if (inputElement) {
      value = inputElement.value;
    }
    localStorage.setItem('uname', value);
  }

  // use context for username
  const uname = useContext(CalendarContext);

  return (
    <form onSubmit={(e) => handleSubmitForm(e)}>
      {uname}
      <input name='uname'></input>
    </form>
  )
}

function Month({i, monthName, year, updateMonthIndex}: {i:number, monthName:string, year:number, updateMonthIndex: (x:number) => void}) {

  return (
    <div id='month-grid'>
      <h1 className='month-comp'> {monthName} {year} </h1>
      <Selector i={i} direction={0} updateMonthIndex={updateMonthIndex}></Selector>
      <Selector i={i} direction={1} updateMonthIndex={updateMonthIndex}></Selector>
      <UsernameInput></UsernameInput>
    </div>
  )
}

function Calendar() {
    const [monthIndex, setMonthIndex] = useState(7);
    // duplicative - const [numberOfDays, setNumOfDays] = useState(7);

    //change static data that will flow between comps into state

    //const monthIndex = 7
    const monthName = months[monthIndex];
    const days = monthsDays[monthIndex];
    const year = 2026;


    return (
      <>
        <Month i={monthIndex} monthName={monthName} year={year} updateMonthIndex={setMonthIndex}></Month>

        <DaysOfWeek></DaysOfWeek>

        <Days numDays={days}></Days>
      </>
    )
}

function App() {
  //first load in localstorage username
  const uname = localStorage.getItem('uname') ?? 'testing12';
  
  
  return (
    // store it in the context
    <CalendarContext value={uname}>
      <Calendar></Calendar>
    </CalendarContext>
  )
}

export default App
