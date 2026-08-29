import { useState } from 'react'
import './App.css'


//1. identify your components
//2. identify your behaviours/states
//3. identify your data flow between componenets


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

function Calendar() {
    const [monthIndex, setMonthIndex] = useState(7);
    // duplicative - const [numberOfDays, setNumOfDays] = useState(7);

    const month = months[monthIndex];
    const days = monthsDays[monthIndex];

    

    return (
      <>
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
