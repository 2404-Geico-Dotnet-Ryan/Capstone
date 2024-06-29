import React, { useContext } from 'react'
import { formatDate } from '../../Utils/dates';

function EmployeeBirthdaysComponent({employees}: {employees: any []}) {

    return (
        <div>
        <table className="table" style={{width: 'fit-content'}}>
          <thead>
            <tr>
              <th>Employee Name</th>
              <th>Birthday</th>
            </tr>
          </thead>
          <tbody>
            {employees?.map((employee, index) => {
              const birthday = new Date(employee.birthday);
              const today = new Date();
              
              return ( <tr key={index}>
                <td>{employee.firstName} {employee.lastName}</td>
                <td>{formatDate(birthday)}</td>
            </tr>)
            })}
          </tbody>
        </table>
      </div>);
}

export default EmployeeBirthdaysComponent;
