import React from "react";
import "./GoalsComponent.css";
import "./EmployeeProfile";
import EmployeeProfile from "./EmployeeProfile";

function GoalsComponent() {
  return (
    <>
    <div className="rightSide">
      <div className="selectYear">
        <label htmlFor="reviewYear"> Select Review Year: </label>
        <select id="year" name="year">
          <option value="pick">Select</option>
          <option value="2024">2024</option>
          <option value="2023">2023</option>
          <option value="2022">2022</option>
      </select>
    </div>

    <button className="submitButton" type="submit">
      Submit
    </button>
  </div>

<div className="employeeYearContainer">

      <div className="header">
        <h1>Goals</h1>
      </div>
      <div className="profile">
        <EmployeeProfile />
      </div>
      </div>

</>
  );
}

export default GoalsComponent;
