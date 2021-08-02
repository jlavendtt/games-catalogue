import React from 'react'
import {useState, useEffect} from 'react'

const AddUser = ({toggleShowAdd, addUser}) => {
    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    

    const onUserSubmit = (e) => {
        e.preventDefault();
        const toAdd = {
            Username : username,
            Email : email,
            
        }
        toggleShowAdd()
        addUser(toAdd)
        setUsername('');
        setEmail('')
        
    }

    return (
        <form className ="add-form"
        onSubmit={onUserSubmit}>
            <div className='form-control'>
                <label>Username</label>
                <input type='text' placeholder='Enter Username'
                value={username} onChange={(e) => setUsername(e.target.value)}></input>
            </div>
            
            <div className='form-control'>
                <label>Email</label>
                <input type='text' placeholder='Enter Email'
                value={email} onChange={(e) => setEmail(e.target.value)}></input>
            </div>
            

            <input className='btn btn-block' type='submit' value='Add User'></input>
        </form>
    )
}

export default AddUser
