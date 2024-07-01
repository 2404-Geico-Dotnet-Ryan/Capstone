import React, { useEffect, useState } from 'react'

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
      <table className="table" style={{ width: "fit-content" }} >
        <thead>
          <tr>
            <th>Annual Performance Review</th>

          </tr>
        </thead>
        <tbody>
          <td>Employee:</td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td>Review Year:</td>
          <select className="form-select" >
            <option selected> Select </option>
            <option value="1">2024</option>
            <option value="2">2023</option>
            <option value="3">2022</option>
          </select>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
          <td>
            <button type="button" className="btn" style={{ background: "lightblue" }}>Submit</button>

          </td>
        </tbody>
      </table>
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