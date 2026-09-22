import { useReducer, useState } from "react";

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
 --local storage api - save a user session once they have inputted the form 
 (even if the user has closed out and reopened the webpage)
*/

const months = ['January','February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
const monthsDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
const weekDays = ['Sun', 'Mon', 'Tues', 'Weds', 'Thurs', 'Fri', 'Sat']

type CalendarState = { monthIndex: number };

type CalendarAction =
  | { type: 'NEXT_MONTH' }
  | { type: 'PREV_MONTH' };

function calendarReducer(state: CalendarState, action: CalendarAction): CalendarState {
  switch (action.type) {
    case 'NEXT_MONTH':
      return { monthIndex: state.monthIndex === 11 ? 0 : state.monthIndex + 1 };
    case 'PREV_MONTH':
      return { monthIndex: state.monthIndex === 0 ? 11 : state.monthIndex - 1 };
    default:
      return state;
  }
}
 

function UsernameInput() {

  function handleSubmitForm(e: React.SubmitEvent<HTMLFormElement>): void {
    e.preventDefault();
    const inputElement = e.target.elements.namedItem('uname');
    let value = '';
    
    if (inputElement instanceof HTMLInputElement) {
      value = inputElement.value;
    }
    localStorage.setItem('uname', value )
  }
  return (
    <form onSubmit={(e) => handleSubmitForm(e)}>
      <input name='uname'></input>
    </form>
  )
}

function MonthSelector({direction, dispatch}: {direction: number, dispatch: React.Dispatch<CalendarAction>}) {
  
  function handleClick() {
    dispatch({ type: direction ? 'NEXT_MONTH' : 'PREV_MONTH' });
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

function Month({monthName, year, dispatch}: {monthName: string, year: number, dispatch: React.Dispatch<CalendarAction>}) {
  return (
    <div>
      <h1 className='month-component'>{monthName} {year}</h1>
      <MonthSelector direction={0} dispatch={dispatch}></MonthSelector>
      <MonthSelector direction={1} dispatch={dispatch}></MonthSelector>
      <UsernameInput></UsernameInput>
    </div>
  )
}

function Calendar() {

  const [state, dispatch] = useReducer(calendarReducer, { monthIndex: 7 });
  const { monthIndex } = state;
  const [year] = useState(2026);
  const monthName = months[monthIndex];
  const days = monthsDays[monthIndex];
  const dayComponentsList = [];

  for (let index = 0; index < days; index++) {
    const dayComponent = <Day weekDay='' dayNumber={index + 1}></Day>;
    dayComponentsList.push(dayComponent);
    }

  return (
    <>
      <Month monthName={monthName} year={year} dispatch={dispatch}></Month>
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