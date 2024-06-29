import React, { useContext } from 'react'
import { formatDate} from '../../Utils/dates'


function AnniversaryComponent({employees}: {employees: any[]}) {

  return (
    <div>
      <table className="table" style={{width: 'fit-content'}}>
        <thead>
          <tr>
            <th>Employee Name</th>
            <th>Hire Date</th>
            <th>Years Employed</th>
          </tr>
        </thead>
        <tbody>
          {employees?.map((employee, index) => {
            const hireDate = new Date(employee.hireDate);
            const today = new Date();
            const yearsEmployed = today.getFullYear() - hireDate.getFullYear();
            return ( <tr key={index}>
              <td>{employee.firstName} {employee.lastName}</td>
              <td>{formatDate(hireDate)}</td>
              <td>{yearsEmployed} years</td>
            </tr>)
          })}
        </tbody>
      </table>
    </div>)
  
  // const birthday = employee.birthday;
  // let month = birthday.getMonth();

  /* 
  Possible function to format dates
  */

  // function formatDate(date: Date): string {
  //   const day = date.getDate().toString().padStart(2, '0');
  //   const month = (date.getMonth() + 1).toString().padStart(2, '0');
  //   const year = date.getFullYear();
  //   return `${day}-${month}-${year}`;
  //   }
    
  //   const today = new Date();
  //   console.log(formatDate(today));



  /*
  return (
    <div key={key}>
        <p>{employee.firstName} {employee.lastName} {employee.hireDate} </p>       
    </div>
  )*/
}

export default AnniversaryComponent
