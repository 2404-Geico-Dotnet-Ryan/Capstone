import React from 'react'
import { PerformanceEmployeeList } from '../../Helpers/PerformanceEmployeeList';

interface EmployeeItemProps {
  id: number;
  firstName: string;
  lastName: string;
  title: string;
  department: string;
  manager: string;
}

function EmployeeItem({ firstName, lastName, id, title, department, manager }: EmployeeItemProps) {
  return (
    <div className='employeeProfile'>
        <h5>Employee: {firstName} {lastName}</h5>
        <p>Employee ID: {id}</p>
        <p>Title: {title}</p>
        <p>Department: {department}</p>
        <p>Manager: {manager}</p>
    </div>
  )
}

export default EmployeeItem