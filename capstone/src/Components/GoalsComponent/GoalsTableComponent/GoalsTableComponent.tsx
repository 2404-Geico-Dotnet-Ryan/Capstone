import React from "react";
import "../../LeaveComponent/TableComponent.css";
import { BsFillTrashFill, BsFillPencilFill } from "react-icons/bs";
import { useNavigate } from "react-router-dom";

function GoalsTableComponent() {
  const clickEventApplyGoal = () => {
    console.log("Apply Goal button clicked");
  };
  const navigate = useNavigate();
  const clickEventEditGoal = () => {
    navigate("/user");
    console.log("Edit Goal button clicked");
  };

  return (
    <div>
      <div className="table-wrapper" >
        {/* <div className="buttons-container">
          <button onClick={clickEventApplyGoal}>Save</button>
          <button onClick={clickEventEditGoal}>Edit</button>
        </div> */}
        <table className="table" style={{margin: "0"}}>
          <thead>
            <tr>
              <th>Goal</th>
              <th className="expand" >Deliverable / Description</th>
              <th>Weight</th>
              <th>Due Date</th>
              <th>Rating</th>
              <th>Comments</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Big Goal</td>
              <td>Paid Time Off</td>
              <td>25%</td>
              <td>7/12/2024</td>
              <td>4</td>
                <td>Great Job!</td>
                <td>
                    <span className="actions">
                    <BsFillTrashFill className="delete-btn" />
                    <BsFillPencilFill />
                    </span> 
                </td>
             </tr>
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default GoalsTableComponent;
