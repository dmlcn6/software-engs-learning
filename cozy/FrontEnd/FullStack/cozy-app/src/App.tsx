import { useState } from "react";

//1. identify your components
//2. identify your behaviours/states
//3. identify your data flow between componenets
// ^^^^^^^^ THATS ALL MOCK UP ^^^^^^^
//4. build simple static version with mock data.  do not use state yet, only component props when needed
//5. identify your minimal state data (minimal set of changing data that your app needs to remember)
//6. identify where your state lives


/* AC
 --Use components
 --use arrays / list / objects
 --parent child nesting
 --use state and reducer / context
 --input form to take in a username
 local storage api - save a user session once they have inputted the form 
 (even if the user has closed out and reopened the webpage)
*/

const months = ['January','February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
const monthsDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
const weekDays = ['Sun', 'Mon', 'Tues', 'Weds', 'Thurs', 'Fri', 'Sat']
 

function UsernameInput() {

  function handleSubmitForm(e: React.SubmitEvent<HTMLFormElement>): void {
    e.preventDefault();
    const inputElement = e.target.elements.namedItem('uname')
    console.log(inputElement.value)
  }
  return (
    <form onSubmit={(e) => handleSubmitForm(e)}>
      <input name='uname'></input>
    </form>
  )
}

function MonthSelector({i, direction, updateMonthIndex}: {i: number, direction: number, updateMonthIndex: (x:number) => void}) {
  
  function handleClick() {
    if (direction) {
      if (i == 11) {
        updateMonthIndex(0)
      } else {
        // increment month index
        updateMonthIndex(i+1)
      }
    } else {
      if (i==0) {
        updateMonthIndex(11)
      } else {
        // decrement month index
        updateMonthIndex(i-1)
      }
    }
  }
  
  
  
  const arrow = direction == 0 ? '<' : '>';
  return (
    <div className='month-selector-component'>
      <h3 onClick={() => handleClick()}> {arrow} </h3>
    </div>
  )
}

function Day ({weekDay, dayNumber}: {weekDay: string, dayNumber: number}) {
  return (
    <h3 className='day-component'> {weekDay} {dayNumber}</h3>
  )
}

function Weekdays() {
  return (
    <div className='week-component'>
      {weekDays.map((day: string) => {
        return (<p> {day} </p>)
      })}
    </div>
  )
}

function Month({i, monthName, year, updateMonthIndex}: {i:number, monthName: string, year: number, updateMonthIndex: (x:number) => void}) {
  return (
    <div>
      <h1 className='month-component'>{monthName} {year}</h1>
      <MonthSelector i={i} direction={0} updateMonthIndex={updateMonthIndex}></MonthSelector>
      <MonthSelector i={i} direction={1} updateMonthIndex={updateMonthIndex}></MonthSelector>
      <UsernameInput></UsernameInput>
    </div>
  )
}

function Calendar() {

  const [monthIndex, setMonthIndex] = useState(7);
  const monthName = months[monthIndex];
  const days = monthsDays[monthIndex];
  const year = 2026
  const dayComponentsList = [];

  for (let index = 0; index < days; index++) {
    const dayComponent = <Day weekDay='' dayNumber={index + 1}></Day>;
    dayComponentsList.push(dayComponent);
    }

  return (
    <>
      <Month i={monthIndex} monthName={monthName} year={year} updateMonthIndex={setMonthIndex}></Month>
      <Weekdays></Weekdays>
      <div id='day-grid'>{dayComponentsList}</div>
    </>
  )
}

export default function App() {
  return (
    <>
      <Calendar></Calendar>
    </>
  )

}