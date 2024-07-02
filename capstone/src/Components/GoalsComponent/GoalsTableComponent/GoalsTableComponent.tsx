import React, { useEffect, useState } from 'react'
import "../../LeaveComponent/TableComponent.css";
import { BsFillTrashFill, BsFillPencilFill } from "react-icons/bs";
import { useNavigate } from "react-router-dom";
import axios from 'axios';


const baseUrl = 'http://localhost:5074';


// This interface is based on the backend API

export interface userGoalInput {
  goalId: number;
  performanceId: number;
  goal: string;
  deliverable: string;
  deadline: Date;
  weightage: number;
  goalScore: number;
  managerFeedback: string;
}

// Make sure the fields match the response JSON from the API (use Swagger to check)
export interface Goal {
  goalId: number;
  performanceId: number;
  goal: string;
  deliverable: string;
  deadline: Date;
  weightage: number;
  goalScore: number;
  managerFeedback: string;
}


function GoalsTableComponent() {

  const [goals, setGoals] = useState<any[] | undefined>(undefined);

// below is the API call without axios
  // useEffect(() => {
  //   async function getGoals() {
  //     let response = await fetch('${BASE_URL}/Goals');
  //     let data = await response.json();
  //     setGoals(data);
  //     console.log(data); // Check the console to see the data - now we know it's being returned correctly
  //   }
  //   getGoals();
  // }, []); // This empty array is important - it tells React to only run this once, don't keep re-running it

  //if we use axios to fetch data from the API, we can use the following code - using axios how my fetch all goals is coded
  useEffect(() => {
    async function getGoals() {
      let response = await axios.get(`${baseUrl}/Goals`);
      setGoals(response.data);
      console.log(response.data); // Check the console to see the data - now we know it's being returned correctly
    }
    getGoals();
  }, []); 

 
  return (
    <div>
      <table className="table">
        <thead>
          <tr>                    
            <th>Goal</th>
            <th>Deliverable</th>
            <th>Due Date</th>
            <th>Goal Weight</th>
            <th>Goal Score</th>
            <th>Feedback</th>
          </tr>
        </thead>
        <tbody> 
          {goals?.map((goal) => {
            return (
              <tr key={goal.goalId}>
                <td>{goal.goal}</td>
                <td>{goal.deliverable}</td>
                <td>{goal.deadline}</td>
                <td>{goal.weightage}</td>
                <td>{goal.goalScore}</td>
                <td>{goal.managerFeedback}</td>
                
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );

}

export default GoalsTableComponent