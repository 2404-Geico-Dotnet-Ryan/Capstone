import React, { useContext } from 'react'


function EmployeeComponent({employee, key}: {employee: any, key: number}) {
    console.log(employee);
  return (
    <div key={key}>
        <h1>{employee.FirstName && employee.LastName}</h1>
        <p>{employee.birthday}</p>
       
    </div>
  )
}

export default EmployeeComponent