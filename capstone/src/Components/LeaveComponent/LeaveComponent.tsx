import React from 'react'
import './TableComponent.css';
import { BsFillTrashFill, BsFillPencilFill } from "react-icons/bs"
import {useNavigate} from 'react-router-dom';


/*
 - Display of two buttons, one to initiate a leave request, and one to edit personal 
 info via navigating to the profile page
 - 2 tables, one with leave requests and one for holidays
 - leave request form to submit to complete a leave request, which will also be rendered
 to edit (employee edit info and manager approve/reject with dynamically displaying 
 checkboxes)

*/

function LeaveComponent() {
  const clickEventApplyLeave = () => {
    console.log("Apply Leave button clicked");
  };
  const navigate = useNavigate();
  const clickEventEditPersonalInfo = () => {
    navigate('/user');
    console.log("Edit Personal Info button clicked");
  };
  return (
    <div>
      <div className="table-wrapper">
      <div className="buttons-container">
        <button onClick={clickEventApplyLeave}>Apply For Leave</button>
        <button onClick= {clickEventEditPersonalInfo}>Edit Personal Info</button>
      </div>
        <table className="table">
          <thead>
            <tr>
              <th className="expand">Employee Name</th>
              <th>Leave Type</th>
              <th>Start Date</th>
              <th>End Date</th>
              <th>Status</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Amanda Ward</td>
              <td>Paid Time Off</td>
              <td>7/10/2024</td>
              <td>7/12/2024</td>
              <td>
                <span className="label label-pending">Pending</span>
              </td>
              <td>
                <span className="actions">
                  <BsFillTrashFill className="delete-btn" />
                  <BsFillPencilFill />
                </span>
              </td>
            </tr>
            <tr>
              <td>Rebecca Chester</td>
              <td>Paid Time Off</td>
              <td>7/22/2024</td>
              <td>7/24/2024</td>
              <td>
                <span className="label label-approved">Approved</span>
              </td>
              <td>
                <span className="actions">
                  <BsFillTrashFill className="delete-btn" />
                  <BsFillPencilFill />
                </span>
              </td>
            </tr>
            <tr>
              <td>Reuben Lewis</td>
              <td>Paid Time Off</td>
              <td>7/29/2024</td>
              <td>7/30/2024</td>
              <td>
                <span className="label label-rejected">Rejected</span>
              </td>
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

export default LeaveComponent;