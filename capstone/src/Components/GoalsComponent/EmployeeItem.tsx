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
        <h2>Employee: {firstName} {lastName}</h2>
        <h4>Employee ID: {id}</h4>
        <h4>Title: {title}</h4>
        <h4>Department: {department}</h4>
        <h4>Manager: {manager}</h4>

    </div>
  )
}

export default EmployeeItem