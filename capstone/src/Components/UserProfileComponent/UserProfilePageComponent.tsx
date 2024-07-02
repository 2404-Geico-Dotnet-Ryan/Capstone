import React, { useContext, useEffect, useState } from 'react'
import { UserContext } from '../../context/UserContext'
import { UserProfileFormComponent } from './UserProfileFormComponent'
import './UserProfilePageComponent.css'
import { formatDrDate } from '../../Utils/dates'
import { Employee } from '../AdminComponent/UpdateProfileComponent'

function UserProfilePageComponent() {
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
        email: 'BLogan@Capstone.com',
        phoneNumber: '123-555-6666',
        addressLine1: '123 ForEach Loop',
        city: 'Kitty City',
        state: 'VA',
        zipCode: '32101',
        ptoLeaveHours: '180',
        reqPtoLeaveHours: '24',
        floatingHolidayHours: '16',
        reqFloatingHolidayHours: '16',
    }


    //7/1
    let [employees, setEmployees] = useState<Employee[] | undefined>(undefined);  //7/1
    let [managers, setManagers] = useState<Employee[] | undefined>(undefined);  //7/1

    useEffect(() => {
        async function getEmployees() {

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
    const myDirectReports = employees?.filter(employee => employee.managerId === matchingManager?.managerId);  //will work once login is working with a little tweak



    return (
        <div className="profile">
            <table className='table'>
                <div className="profile-header">{user.isAdmin ? '(Admin) ' : ''}{user.firstName} {user.lastName} - {user.isManager ? 'Manager' : 'Associate'} - ID {user.id}</div>
                <UserProfileFormComponent user={user} />
            </table>
            <br />
            <br />
            <br />
            <br />


            <div className="directreports">
                <table className="table" style={{ width: 'fit-content' }}>
                    <thead>
                        <h2>Direct Reports</h2>
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
                        {myDirectReports?.map((employee, index) => {
                            const birthday = new Date(employee.birthday);
                            const today = new Date();
                            const hireDate = new Date(employee.hireDate);


                            return (<tr key={index}>
                                <td>{employee.firstName} {employee.lastName}</td>
                                <td>{formatDrDate(hireDate)}</td>
                                <td>{formatDrDate(birthday)}</td>
                                <td>{employee.email}</td>
                                <td>{employee.phoneNumber}</td>
                                <td>{employee.addressLine1}, {employee.city}, {employee.state} {employee.zipCode}</td>
                            </tr>)
                        })}
                    </tbody>
                </table>
            </div>
        </div>

    )
}


export default UserProfilePageComponent;