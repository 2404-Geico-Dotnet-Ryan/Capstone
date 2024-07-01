import React, { useContext } from 'react'
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
        id: 6,
        firstName: 'Clark',
        lastName: 'Garrison',
        isManager: false,
        isAdmin: false,
        hireDate: new Date('2024-02-14'),
        birthday: new Date('1993-10-02'),
        email: 'CGarrison@Capstone.com',
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



    return (
        <div className="profile">
            <div className="profile-header">{user.isAdmin ? '(Admin) ' : ''}{user.firstName} {user.lastName} - {user.isManager ? 'Manager' : 'Associate'} - ID {user.id}</div>
            <UserProfileFormComponent user={user}/>
        </div>
    )
}

export default UserProfilePageComponent;
