import React from 'react'
import './GoalsComponent.css'

function GoalsComponent() {
  return (
    <><div className="grid-container">
      <div className='header'>
        <h1>Goals</h1>
        </div>
      <div className="left">
        <h3>Employee:</h3>
        <h5>Title:</h5>
        <h5>Department:</h5>
        <h5>Manager:</h5>
      </div>
      <div className="right">
      <div className="selectYear">
          <label htmlFor="reviewYear"> Select Review Year:  </label>
          <select id="year" name="year">
            <option value="pick">Select</option>
            <option value="2024">2024</option>
            <option value="2023">2023</option>
            <option value="2022">2022</option>
          </select>
        </div>

          <button className='submitButton' type="submit">Submit</button>
        </div>
      </div>
   
    </>
  )
}

export default GoalsComponent