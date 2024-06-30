import React from "react";
import EmployeeItem from "./EmployeeItem";
import { PerformanceEmployeeList } from "../../Helpers/PerformanceEmployeeList";
import "./GoalsComponent.css";

function EmployeeProfile() {
  return (
      <div className="employeeProfile">
        {PerformanceEmployeeList.map((employee, key) => {
          return (
            <EmployeeItem
              key={key}
              id={employee.id}
              firstName={employee.firstName}
              lastName={employee.lastName}
              title={employee.title}
              department={employee.department}
              manager={employee.manager}
            />
          );
        })}
      </div>
  );
}

export default EmployeeProfile;
