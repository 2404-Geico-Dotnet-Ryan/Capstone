import React from 'react'
import { Link } from 'react-router-dom';
import logo from "../../Images/logo2.png";
import "./Nav.css";

/*
Is it possible to display a welcome <User> message in the navbar???
*/

function NavBar() {
  const [useState] = React.useState(false);
  return (
  <>
  <div id="header">
    <Link id="login-link" to={useState ? "/WelcomeLoggedInUser" : "/LandingPage"}>
      <img src={logo} alt="Logo" id="header-logo" />
    </Link>

    <div id="nav-container">
      <ul id="nav">
        <li className="dropdown">
          {" "}
          Profile{" "}
          <ul className="dropdown-content">
            <li>
              {" "}
              <Link to="user">
                {" "}
                 View Profile{" "}
              </Link>
            </li>

            <li>
              <Link to="resetpassword">
                Password
                Reset
              </Link>
            </li>

            <li>
              <Link to="/">
                {" "}
                Logout
              </Link>
            </li>
          </ul>
        </li>

        
        <li className="dropdown">
          {" "}
          Leave{" "}
          <ul className="dropdown-content">
            <li>
              <Link to="leave">
               {" "}
                Leave Requests{" "}
              </Link>{" "}
            </li>
          </ul>
        </li>

        <li className="dropdown">
          {" "}
          Performance{" "}
          <ul className="dropdown-content">
            <li>
              <Link to="Goals">
                 Goals{" "}
              </Link>{" "}
            </li>
            <li>
              <Link to="Performance">
                 Performance Review{" "}
              </Link>{" "}
            </li>
          </ul>
        </li>

        <li className="dropdown">
          {" "}
          Administrative{" "}
          <ul className="dropdown-content">
            <li>
              <Link to="createProfile">
                Create
                Profile{" "}
              </Link>{" "}
            </li>
            <li>
              <Link to="deleteProfile">
             {" "}
                Delete
                Profile{" "}
              </Link>{" "}
            </li>
            <li>
              <Link to="updateProfile">
                Update
                Profile{" "}
              </Link>{" "}
            </li>
          </ul>
        </li>

      </ul>
    </div>
  </div>
</>
  );
}
 
export default NavBar;