import React, { useEffect, useState } from 'react'
import './PerformanceComponent.css';
import EmployeeProfile from '../../Helpers/EmployeeProfile';

function PerformanceComponent() {
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
      <br />
      <br />
      <br />
      <br />
      {/* code for employee to select review year */}
      <div className="grid-container">
        <header className="header">
          <h5>Annual Performance Review</h5>
        </header>
        <div className="employeeContainer">
        <div className="performanceProfile">
          <EmployeeProfile />
        </div>
      </div>

        <div className="selectYearContainer">
            <label htmlFor="reviewYear" style={{ padding: "10px", margin: "10px"}}> Select Review Year: </label>
            <select id="year" name="year" style={{ padding: "10px", margin: "1px"}}>
              <option value="pick">Select</option>
              <option value="2024">2024</option>
              <option value="2023">2023</option>
              <option value="2022">2022</option>
            </select>
            <button type="button" className="submitButton">Submit
          </button>
          </div>
        </div>
      <br />
      <br />
      {/* starting Employee Comment section here */}
      <table className='table'>
        <thead>
          <tr>
            <th className='header'>Employee Comments </th>

          </tr>
        </thead>
        <tbody>
          <td>
            <textarea
              className="form-control"
              placeholder="Employee Comments- Achievements"
              aria-label="Employee Comments- Achievements"
              rows={10}
              // cols={200}
            ></textarea>
          </td>
          <tr>
            <td>
              <textarea
                className="form-control"
                placeholder="Employee Comments- Areas of Improvement"
                aria-label="Employee Comments- Areas of Improvement"
                rows={10}
                cols={200}

              ></textarea>
            </td>
          </tr>
          <td>
            <button type="button" className="btn" style={{ background: "lightblue" }}>Submit</button>
          </td>
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