import React, { useContext, useEffect, useState } from 'react'
import { UserContext } from '../../context/UserContext'
import { UserProfileFormComponent } from './UserProfileFormComponent'
import './UserProfilePageComponent.css'

function UserProfilePageComponent() {
    /*
        With context, we can now reference any value that is related to the context anywhere the context is provided.
    */


    /*
        1. We need to get data from the userContext to return values for the profile
            a. Ability to edit standard employee edits
        2. We need to get data for managers to display all direct reports
            a. display short description of direct reports, if else if possible to manage this
    */
   //const user = useContext(UserContext);   //uncomment code after login is matching DTO and working
   const user = { //delete this hardcoded user after login is matching DTO and working
        id: 5,
        firstName: 'Beth',
        lastName: 'Logan',
        isManager: true,
        isAdmin: false,
        hireDate: new Date('2024-02-14'),
        birthday: new Date('1993-10-02'),
        email: 'Blogann@Capstone.com',
        phoneNumber: '123-555-6666',
        addressLine1: '123 ForEach Loop',
        city: 'Kitty City',
        state: 'VA',
        zipCode: '32101',
        ptoLeaveHours:'180',
        reqPtoLeaveHours: '24',
        floatingHolidayHours: '16',
        reqFloatingHolidayHours: '16',
   }


    //7/1
    let [employees, setEmployees] = useState<any[] | undefined>(undefined);  //7/1
    let [managers, setManagers] = useState<any[] | undefined>(undefined);  //7/1

    useEffect(() => {
        async function getEmployees(){

            let response = await fetch('http://localhost:5074/Employee');
            let data = await response.json();
            setEmployees(data);
            console.log(data);
        
            

        }
        getEmployees();
    }, []);

    useEffect(() => {
        async function getManagers() {

            let response = await fetch('http://localhost:5074/Manager');
            let data = await response.json();
            setManagers(data);
            console.log(data);



        }
        getManagers();
    }, []);

    const matchingManager = managers?.find(manager => manager.email === user.email && user.isManager === true);  //will work once login is working with a little tweak
    const myDirectReports = employees?.filter(employee => employee.managerId === matchingManager?.manager.Id);  //will work once login is working with a little tweak
  






    return (
        <div className="profile">
            <div className="profile-header">{user.isAdmin ? '(Admin) ' : ''}{user.firstName} {user.lastName} - {user.isManager ? 'Manager' : 'Associate'} - ID {user.id}</div>
            <UserProfileFormComponent user={user}/>
          


        

            
            <div>
        <table className="table" style={{width: 'fit-content'}}>
          <thead>
            <tr>
              <th>Employee Name</th>
              <th>Hire Date</th>
              <th>Birthday</th>
              <th>Email</th>
              <th>Phone Number</th>
              <th>Address</th>
         
            </tr>
          </thead>
          <tbody>
            {employees?.map((employee, index) => {
              const birthday = new Date(employee.birthday);
              const today = new Date();
              
              return ( <tr key={index}>
                <td>{employee.firstName} {employee.lastName}</td>
                <td>{employee.hireDate}</td>
                <td>{employee.birthday}</td>
                <td>{employee.email}</td>
                <td>{employee.phoneNumber}</td>
                <td>{employee.addressLine1}, {employee.city}, {employee.state} {employee.zipCode}</td>
           
                
                
            </tr>)
            })}
          </tbody>
        </table>
      </div>






            


                 {/* {user.isManager && (
                    <div>
                        <h2>Direct Reports</h2>
                        <ul>
                            {myDirectReports?.map(report => (
                                <li key={report.email}>{report.firstName} {report.lastName} - ID {report.email}</li>
                            ))}
                        </ul>
                    </div>
                )}  */}
            </div>





    )
}


export default UserProfilePageComponent;