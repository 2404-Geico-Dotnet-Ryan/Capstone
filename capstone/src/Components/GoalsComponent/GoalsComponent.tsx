import React from "react";
import "./GoalsComponent.css";
import "../../Helpers/EmployeeProfile";
import EmployeeProfile from "../../Helpers/EmployeeProfile";

function GoalsComponent() {
  return (
    <>
      <div className="grid-container">
        <header className="header">
          <h5>Goals</h5>
        </header>
        <div className="employeeContainer">
        <div className="goalProfile">
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
    </>
  );
}

export default GoalsComponent;
