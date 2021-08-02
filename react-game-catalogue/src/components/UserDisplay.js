import React from 'react'
import {Link} from 'react-router-dom'
const UserDisplay = ({user, chooseUser}) => {

    const fetchUser = async (id) => {
        const res = await fetch(`https://localhost:44305/User/${id}`)
    
        const data = await res.json();
        chooseUser(data);
      }


    return (
        <div>
            
            <Link onClick={() => fetchUser(user.id)} to="/home">{user.username}</Link>
            
        </div>
    )
}

export default UserDisplay
