import React from "react";
import "./GoalsComponent.css";
import "../../Helpers/EmployeeProfile";
import EmployeeProfile from "../../Helpers/EmployeeProfile";
import GoalsTableComponent from "./GoalsTableComponent/GoalsTableComponent";

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
          <label
            htmlFor="reviewYear"
            style={{ padding: "10px", margin: "10px" }}
          >
            {" "}
            Select Review Year:{" "}
          </label>
          <select
            id="year"
            name="year"
            style={{ padding: "10px", margin: "1px" }}
          >
            <option value="pick">Select</option>
            <option value="2024">2024</option>
            <option value="2023">2023</option>
            <option value="2022">2022</option>
          </select>
          <button type="button" className="submitButton">
            Submit
          </button>
        </div>
        {/* attempting add goals */}
        <div className="addGoals">
          {/* <header className="header">
            <h5 >Employee Goals</h5>
            
          </header> */}
          
          <label htmlFor="addGoal" style={{ padding: "10px" }}> Goal Type: </label>
          <input type="text" className="form-control" placeholder="Enter Goal Type" aria-label="Enter Goal Type"></input>
          <label htmlFor="addGoal" style={{ padding: "10px" }}> Goal Description: </label>
          <input type="text" className="form-control" placeholder="Enter Goal Description" aria-label="Enter Goal Description"></input>
          <label htmlFor="addGoal" style={{ padding: "10px" }}> Goal Weight: </label>
          <input type="text" className="form-control" placeholder="Enter Goal Weight" aria-label="Enter Goal Weight"></input>
          <label htmlFor="addGoal" style={{ padding: "10px" }}> Expected Completion Date: </label>
          <input type="date" className="form-control"  placeholder="07/01/2024" aria-label="Expected Completion Date"></input>
          <button type="button" className="submitButton">Add New Goal</button>
        </div>
        <div className="displayGoals">
        {/* <header className="header"></header> */}
        <label htmlFor="displayGoals" style={{ padding: "10px" }}> Added Goal: </label>
          placeholder text for added goal
        </div>
      </div>
      <br/>
      <br/>
      <div className="table-wrapper">
        <table className="table">
          <GoalsTableComponent />
        </table>
      </div>
 
    </>
  );
}

export default GoalsComponent;
