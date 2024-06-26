import React, { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import LoginComponent, { User } from './Components/LoginComponent/LoginComponent';
import UserProfileComponent from './Components/UserProfileComponent/UserProfileComponent';
import { UserContext } from './context/UserContext';
import NavBar from './Components/NavBar/NavBar';
import LeaveComponent from './Components/LeaveComponent/LeaveComponent';
import GoalsComponent from './Components/GoalsComponent/GoalsComponent';
import PerformanceComponent from './Components/PerformanceComponent/PerformanceComponent';
import LandingPageComponent from './Components/LandingPageComponent/LandingPageComponent';
import ForgotPassword from './Components/ForgotPassword/ForgotPassword';
import PasswordReset from './Components/PasswordReset/PasswordReset';
import UserProfilePageComponent from './Components/UserProfileComponent/UserProfilePageComponent';
import CreateProfileComponent from './Components/AdminComponent/CreateProfileComponent';
import DeleteProfileComponent from './Components/AdminComponent/DeleteProfileComponent';
import UpdateProfileComponent from './Components/AdminComponent/UpdateProfileComponent';

function App() {
  /*
    By using UserContext.Provider, anything inside of it can reference the user with useContext anywhere without having to provide it with props

  */
  const [user, setUser] = useState<User | undefined>(undefined);

  return (
    <div className="App">
      <UserContext.Provider value={user}>
        <UserProfileComponent/>
        <NavBar/>
        <Routes>
          <Route path="/" element={<LoginComponent setUser={setUser}/>}/>
          <Route path="/forgotpassword" element={<ForgotPassword/>}></Route>
          <Route path="/resetpassword" element={<PasswordReset/>}></Route>
          <Route path="/leave" element={<LeaveComponent/>}/>
          <Route path="/performance" element={<PerformanceComponent/>}></Route> 
          <Route path="/goals" element={<GoalsComponent/>}></Route>
          <Route path="/LandingPage" element={<LandingPageComponent/>}/>
          <Route path="/user" element={<UserProfilePageComponent/>}/>
          <Route path="/createProfile" element={<CreateProfileComponent/>}/>
          <Route path="/deleteProfile" element={<DeleteProfileComponent/>}/>
          <Route path="/updateProfile" element={<UpdateProfileComponent/>}/>

        </Routes>
      </UserContext.Provider>
    </div>
  );
}

export default App;
