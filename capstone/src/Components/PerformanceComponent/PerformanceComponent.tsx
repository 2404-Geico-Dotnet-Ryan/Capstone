import React, { useEffect, useState } from 'react'
// import './TableComponent.css';
// import './EmployeeComponent/EmployeeComponent.tsx';

function PerformanceComponent()  {
  const BASE_URL = "http://localhost:5074";
  const [employees, SetEmployees] = useState([]);

  useEffect(() => {
    //Fetch data
    fetch(`${BASE_URL}/Employee`)
    .then(response => {
      if (!response.ok) {
        throw new Error('Failed to fetch employees');
      }
      return response.json();
    })
    .then(data => {
      console.log('Fetched employees:', data);
      SetEmployees(data)
    })
    .catch(error => console.error('Error fetching data:', error))
  }, []);
  return (
    <div className='table-wrapper'>
    <table className='table'>
      <thead>
        <tr>
          <th className='expand'>Employee Name</th>
          <th>Title</th>
          <th>Department</th>
          <th>Manager</th>
          <th>Review Status</th>
          <th>Overall Rating</th>
        </tr>
      </thead>
      <tbody>
        <td>Placeholder Employee</td>
          <td>Placeholder Title</td>
          <td>Placeholder Department</td>
          <td>Placeholder Manager</td>
          <td><span className="label label-pending">Placeholder Review Status</span></td>
          <td>Placeholder Overall Rating</td>
        {/* {employees.map(employee => (
        <tr key={employee}>
          <td>{employee}</td>
          

        </tr>
        ))} */}
      </tbody>

    </table>

  </div>
  )
}

export default PerformanceComponent