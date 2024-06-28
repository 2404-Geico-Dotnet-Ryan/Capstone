import React, { useContext } from 'react'


function AnniversaryComponent({employee, key}: {employee: any, key: number}) {
  
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

  return (
    <div key={key}>
        <p>{employee.firstName} {employee.lastName} {employee.hireDate} </p>       
    </div>
  )
}

export default AnniversaryComponent
