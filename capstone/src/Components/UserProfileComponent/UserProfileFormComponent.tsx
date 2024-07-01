import React, { useContext } from 'react';
import { formatFullDateForInput } from '../../Utils/dates';
import { UserContext } from '../../context/UserContext';

export function UserProfileFormComponent(props: {user: any}) {
    const loggedInUser = useContext(UserContext);
    const user = props.user;

    const [firstName, setFirstName] = React.useState(user?.firstName);           // only admin can edit
    const [lastName, setLastName] = React.useState(user?.lastName);             //only admin can edit
    const [isManager, setIsManager] = React.useState(user?.isManager);          //only admin can edit
    const [isAdmin, setIsAdmin] = React.useState(user?.isAdmin);                //only admin can edit
    const [hireDate, setHireDate] = React.useState(formatFullDateForInput(user?.hireDate));   //only admin can edit
    const [birthday, setBirthday] = React.useState(formatFullDateForInput(user?.birthday));   //only admin can edit
    const [email, setEmail] = React.useState(user?.email);                      //employee and manager can edit
    const [phoneNumber, setPhoneNumber] = React.useState(user?.phoneNumber);    //employee and manager can edit
    const [addressLine1, setAddressLine1] = React.useState(user?.addressLine1); //employee and manager can edit
    const [city, setCity] = React.useState(user?.city);                         //employee and manager can edit
    const [state, setState] = React.useState(user?.state);                      //employee and manager can edit
    const [zipCode, setZipCode] = React.useState(user?.zipCode);                //employee and manager can edit

    const onSaveProfile = async () => {
        let response = await fetch(`http://localhost:5074/Employee/${user.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: user.id,
                managerId: user.managerId,
                firstName,
                lastName, 
                isManager,
                isAdmin,
                hireDate, 
                birthday,
                email,
                phoneNumber,
                addressLine1, 
                city, 
                state, 
                zipCode, 
                ptoLeaveHours: user.ptoLeaveHours,
                reqPtoLeaveHours: user.reqPtoLeaveHours, 
                floatingHolidayHours: user, 
                reqFloatingHolidayHours: user.reqFloatingHolidayHours,
            })
        });

        const data = response.json();
    };



    return (
        <div style={{ display: 'flex', flexDirection: 'column', gap: '16px', padding: '32px' }}>
            <div style={{ display: 'flex', gap: '32px' }}>
                <label htmlFor="firstName">First Name</label>
                <input id="firstName" type="text" value={firstName} disabled={!loggedInUser?.isAdmin} onChange={(e) => setFirstName(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px' }}>
                <label htmlFor="lastName">Last Name</label>
                <input id="lastName" type="text" value={lastName} disabled={!loggedInUser?.isAdmin} onChange={(e) => setLastName(e.target.value)} />
            </div>
            {loggedInUser?.isAdmin && (
                <>
                    <div style={{ display: 'flex', gap: '32px'}}>
                        <label htmlFor="isManager">Manager</label>
                        <input id="isManager" type="checkbox" checked={isManager} disabled={!loggedInUser?.isAdmin} onChange={(e) => setIsManager(e.target.checked)} />
                    </div>

                    <div style={{ display: 'flex', gap: '32px'}}>
                        <label htmlFor="isAdmin">Admin</label>
                        <input id="isAdmin" type="checkbox" checked={isAdmin} disabled={!loggedInUser?.isAdmin} onChange={(e) => setIsAdmin(e.target.checked)} />
                    </div>
                </>
            )}

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="hireDate">Hire Date</label>
                <input id="hireDate" type="date" value={hireDate} disabled={!loggedInUser?.isAdmin} onChange={(e) => setHireDate(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="birthday">Birthday</label>
                <input id="birthday" type="date" value={birthday} disabled={!loggedInUser?.isAdmin} onChange={(e) => setBirthday(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="email">Email</label>
                <input id="email" type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="phone">Phone Number</label>
                <input id="phone" type="tel" value={phoneNumber} onChange={(e) => setPhoneNumber(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="address">Address</label>
                <input id="address" type="text" value={addressLine1} onChange={(e) => setAddressLine1(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="city">City</label>
                <input id="city" type="text" value={city} onChange={(e) => setCity(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="state">State</label>
                <input id="state" type="text" value={state} onChange={(e) => setState(e.target.value)} />
            </div>

            <div style={{ display: 'flex', gap: '32px'}}>
                <label htmlFor="zip">Zip Code</label>
                <input id="zip" type="text" value={zipCode} onChange={(e) => setZipCode(e.target.value)} />
            </div>

            <button className="save-button" type="submit" onClick={onSaveProfile}>Save</button>

        </div>
    );
}