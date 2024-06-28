import React, { useEffect, useState } from 'react'
import EmployeeComponent from '../EmployeeComponent/EmployeeComponent';
// import axios from 'axios';

function LandingPageComponent() {

    /*
        1. Non static banner - Upcoming Events:
        2. function to get all current month's birthdays and work anniversaries (set up displays)
        3. function and displays for current user Happy Birthday or Happy Anniversary (extra-nice to have)
    */

//  Set variables to get our current Month//       
const today = new Date();
let month =today.getMonth();
const months = ["January","February","March","April","May","June","July","August","September","October","November","December"];
let monthname = months[month]

//This is for getting the current month Birthdays from the DB//

let [employees, setEmployees] = useState<any[] | undefined>(undefined);

useEffect(() => {
  async function getEmployees(){
      // try{
          let response = await fetch('http://localhost:5074/Employee');
          let data = await response.json();
          setEmployees(data.employees);
          console.log(data);
      // }catch(error){
      //     console.error(error);
  // }    
  }
  getEmployees();
}, []);



  return (
    <>
    <div id="EventHeader">
    <h1>Upcoming Events...</h1>
    </div>

    <div>
      <div id="Birthdays">
        <h2>{monthname} Birthdays</h2>
        <div>
        {
            employees?.map((obj, index) => {
                return (
                    <EmployeeComponent employee={obj} key={index}/>
                );
            })
        }
        </div>
        

      </div>
      <div id="Anniversaries">
        <h2>{monthname} Anniversaries</h2>

      </div>
    </div>
    
    </>
  )
}

export default LandingPageComponent