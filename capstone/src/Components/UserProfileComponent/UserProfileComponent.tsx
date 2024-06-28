import React, { useContext } from 'react'
import { UserContext } from '../../context/UserContext'

function UserProfileComponent() {
    /*
        With context, we can now reference any value that is related to the context anywhere where the context is provided.
    */


        /*
        1. We need to get data from the userContext to return values for the profile 
          a. Ability to edit standard employee edits
        2. We need to get data for managers to display all direct reports
          a. display short description of direct reports, if else if possible to manage this
        */
    const user = useContext(UserContext);
  return (
    <div>
        {user?.firstName}
    </div>
  )
}

export default UserProfileComponent