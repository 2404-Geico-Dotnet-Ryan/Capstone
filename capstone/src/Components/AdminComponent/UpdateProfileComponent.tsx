import React, { useContext } from 'react'
import { UserContext } from '../../context/UserContext';
import { EmployeeContext } from '../../context/EmployeeContext';

export interface Employee {
  id: number,
  managerId: number,
  firstName: string,
  lastName: string,
  isManager: string,
  isAdmin: boolean,
  hireDate: Date,
  birthday: Date,
  email: string,
  phoneNumber: string,
  addressLine1: string,
  city: string,
  state: string,
  zipCode: string,
  ptoLeaveHours: number,
  reqPtoLeaveHours: number,
  floatingHolidayHours: number,
  reqFloatingHolidayHours: number
}

function UpdateProfileComponent() {

  const loggedInUser = useContext(UserContext);
  const user: Employee | undefined = useContext(EmployeeContext)


  const [firstName, setFirstName] = React.useState(user?.firstName);           // only admin can edit
  const [lastName, setLastName] = React.useState(user?.lastName);             //only admin can edit
  const [isManager, setIsManager] = React.useState(user?.isManager);          //only admin can edit
  const [isAdmin, setIsAdmin] = React.useState(user?.isAdmin);                //only admin can edit
  const [hireDate, setHireDate] = React.useState((user?.hireDate));   //only admin can edit
  const [birthday, setBirthday] = React.useState((user?.birthday));   //only admin can edit
  const [email, setEmail] = React.useState(user?.email);                      //employee and manager can edit
  const [phoneNumber, setPhoneNumber] = React.useState(user?.phoneNumber);    //employee and manager can edit
  const [addressLine1, setAddressLine1] = React.useState(user?.addressLine1); //employee and manager can edit
  const [city, setCity] = React.useState(user?.city);                         //employee and manager can edit
  const [state, setState] = React.useState(user?.state);                      //employee and manager can edit
  const [zipCode, setZipCode] = React.useState(user?.zipCode);                //employee and manager can edit



  return (
    <div style={{ display: 'flex', flexDirection: 'column', gap: '16px', padding: '32px' }}>
      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="firstName">First Name</label>
        <input id="firstName" type="text" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="lastName">Last Name</label>
        <input id="lastName" type="text" />
      </div>
      {loggedInUser?.isAdmin && (
        <>
          <div style={{ display: 'flex', gap: '32px' }}>
            <label htmlFor="isManager">Manager</label>
            <input id="isManager" type="checkbox" />
          </div>

          <div style={{ display: 'flex', gap: '32px' }}>
            <label htmlFor="isAdmin">Admin</label>
            <input id="isAdmin" type="checkbox" />
          </div>
        </>
      )}

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="hireDate">Hire Date</label>
        <input id="hireDate" type="date" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="birthday">Birthday</label>
        <input id="birthday" type="date" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="email">Email</label>
        <input id="email" type="email" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="phone">Phone Number</label>
        <input id="phone" type="tel" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="address">Address</label>
        <input id="address" type="text" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="city">City</label>
        <input id="city" type="text" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="state">State</label>
        <input id="state" type="text" />
      </div>

      <div style={{ display: 'flex', gap: '32px' }}>
        <label htmlFor="zip">Zip Code</label>
        <input id="zip" type="text" />
      </div>

      <button className="save-button" type="submit" >Save</button>

    </div>
  )
}

export default UpdateProfileComponent