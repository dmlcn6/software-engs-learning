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

const months = ['January','February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December' ];
const monthsDays = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ];
const weekDays = ['Sun', 'Mon', 'Tues', 'Weds', 'Thurs', 'Fri', 'Sat']

function Day ({weekDay, dayNumber}: {weekDay: string, dayNumber: number}) {
  return (
    <h3> {weekDay} {dayNumber}</h3>
  )
}

function Weekdays() {
  return (
    <div className='daysOfWeek'>
      {weekDays.map((day: string) => {
        return (<p> {day} </p>)
      })}
    </div>
  )
}

function Month({monthName, year}: {monthName: string, year: number}) {
  return (
    <h1>{monthName} {year}</h1>
  )
}

function Calendar() {

  const monthIndex = 7;
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
      <Month monthName={monthName} year={year}></Month>
      <Weekdays></Weekdays>
      {dayComponentsList}
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