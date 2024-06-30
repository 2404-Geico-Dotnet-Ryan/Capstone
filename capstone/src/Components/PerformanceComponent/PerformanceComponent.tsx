import React from 'react'

function PerformanceComponent() {
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
    <br/> 
    <br/>
    <br/>
    <br/>
{/* code for employee to select review year */}
    <table className="table" style={{width: "fit-content"}} >
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
              <button type="button" className="btn" style={{background: "lightblue"}}>Submit</button>
            </td>
          </tbody>
        </table>
  </div>
  

       
  
  )
}

export default PerformanceComponent