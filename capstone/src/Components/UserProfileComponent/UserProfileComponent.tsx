import React, { useContext } from 'react'
import { UserContext } from '../../context/UserContext'

function UserProfileComponent() {
    /*
        With context, we can now reference any value that is related to the context anywhere where the context is provided.
    */

const user = useContext(UserContext);

  return (
    <div>
        {user?.firstName}
    </div>
  )
}

export default UserProfileComponent