import React from 'react'
import {useState, useEffect} from 'react'
import UserDisplay from './UserDisplay'
import AddUser from './AddUser'

const SignIn = ({users, chooseUser , addUser}) => {

    const [showAdd, setShowAdd] = useState(false)

    const toggleShowAdd = () => {
        setShowAdd(!showAdd);
    }

    

    return (
        <>
           <br></br>
           <br></br>
            <br></br>
           {!showAdd ? <button onClick={toggleShowAdd}>Create new User</button> : ''}
           {showAdd ? <AddUser addUser = {addUser} toggleShowAdd = {toggleShowAdd}/> : ''}
           <br></br>
           <br></br>
           
           {users.map(user=> <UserDisplay chooseUser = {chooseUser} key = {user.id} user = {user}/>)}
            
        </>
    )
}

export default SignIn
