import React, { useEffect, useState } from 'react'
import EmployeeComponent from '../EmployeeComponent/EmployeeComponent';
import AnniversaryComponent from '../EmployeeComponent/AnniversaryComponent';
import EmployeeBirthdaysComponent from '../EmployeeComponent/EmployeeBirthdaysComponent';
// import axios from 'axios';

function LandingPageComponent() {

  /*
      1. Non static banner - Upcoming Events:
      2. function to get all current month's birthdays and work anniversaries (set up displays)
      3. function and displays for current user Happy Birthday or Happy Anniversary (extra-nice to have)
  */

  //  Set variables to get our current Month//       
  const today = new Date();
  let month = today.getMonth();
  const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
  let monthname = months[month]

  //This is for getting the current month Birthdays from the DB//

  let [employees, setEmployees] = useState<any[] | undefined>(undefined);
  const employeesWithBirthdaysInMonth = employees?.filter(employee => new Date(employee.birthday).getMonth() === month);
  const employeesWithAnniversariesInMonth = employees?.filter(employee => new Date(employee.hireDate).getMonth() === month);

  useEffect(() => {
    async function getEmployees() {
      // try{
      let response = await fetch('http://localhost:5074/Employee');
      let data = await response.json();
      setEmployees(data);
      console.log(data);
      // }catch(error){
      //     console.error(error);
      // }    
    }
    getEmployees();
  }, []);

  console.log(employees);

  return (
    <>
      <div id="EventHeader">
        <h1>Upcoming Events...</h1>
      </div>

      <div style={{ display: 'flex', justifyContent: 'space-between', gap: '50px', marginTop: '150px'}}>
        <div id="Birthdays" style={{ flexGrow: '1'}}>
          <h2 style={{ textAlign: 'center' }}>{monthname} Birthdays</h2>
          <div>
            <EmployeeBirthdaysComponent employees={employeesWithBirthdaysInMonth || []}/>
          </div>


        </div>
        <div id="Anniversaries" style={{ flexGrow: '1'}}>
          <h2 style={{ textAlign: 'center'}}>{monthname} Anniversaries</h2>
          <div>
           <AnniversaryComponent employees={employeesWithAnniversariesInMonth || []} />
          </div>
        </div>
      </div>

    </>
  )
}

export default LandingPageComponent