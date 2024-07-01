import React, { useState } from 'react'
import "../LoginComponent/LoginFormComponent/LoginFormComponent.css";
import { UserLoginInput } from '../LoginComponent/LoginComponent';

function ForgotPasswordComponent(props: any) {
    /*
        Since we are expecting to get the user input for the login, we need to store the input somewhere.

        We could use a state variable, however, this would mean that whenever that variable changes it will trigger a re-render for the component.

        This is unecessary to the functioning of the component, and so instead, we use a object with an interface type of UserLoginInput that defines the shape to have a username and password field.
    */
    // const userInput : UserLoginInput = {username: "", password: ""};
    const [userInput, setUserInput] = useState<UserLoginInput>({userName: "", userPassword: ""});
    /*
        In order to get the input from the text boxes, we need to attach event handlers to the elements. This is done by attaching a function to the events on the elements themselves.

        Text input handlers need the event object as a parameter, in order to get the value from the input box.
        You do not need to add event to the click handler (you can do if you want) as we do not need the value of the click event.
    */
    function usernameInputChangeHandler(event: any){
        // console.log(event.target.value);
        // userInput.username = event.target.value;
        setUserInput({...userInput, userName: event.target.value});
    }

    function passwordInputChangeHandler(event: any){
        // console.log(event.target.value);
        // userInput.password = event.target.value;
        setUserInput({...userInput, userPassword: event.target.value});
    }

    function submitClickHandler(){
        // console.log("Submit button clicked");
        console.log(userInput);
        props.setLoginInput(userInput);
    }

  return (
    <div className='LoginForm'> {/*Leaving as 'LoginForm' as this is the base css for the login/forgot/reset containers*/}
        <h3>Forgot Password:</h3>
        <input className='username' onChange={usernameInputChangeHandler} type="text" placeholder='username'></input>
        <br/>
        <input className='password' onChange={passwordInputChangeHandler} type="email" placeholder='email'></input>
        <br/>
        <input className='submit_btn' onClick={submitClickHandler} type="button" value="Submit"></input>
        <p><a className='forgot_password' href="resetpassword">Reset Password?</a></p>
    </div>
  )
}

export default ForgotPasswordComponent

/* thoughts

username
email

if username == db && email = db
	then send email/message w/code  (assume email would have link to a seperate page to take in username and new password?)
else
	"username or email does nto match"
	
*/