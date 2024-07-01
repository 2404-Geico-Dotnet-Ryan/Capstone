import React, { useContext } from 'react'
import { formatDate } from '../../Utils/dates';


function EmployeeComponent({employee, key}: {employee: any, key: number}) {
  
  const birthday = new Date(employee.birthday);
  

  
  return (
    <div key={key}>
        <p>{employee.firstName} {employee.lastName} {formatDate(birthday)} </p>       
    </div>
  )
}

export default EmployeeComponent
