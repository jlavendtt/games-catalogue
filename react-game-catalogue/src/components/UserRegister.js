import React from 'react'
import {useState, useEffect} from 'react'
import 'bootstrap/dist/css/bootstrap.css'
import '../SignIn.css'

const UserRegister = ({getToken}) => {


    const [username, setUsername] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const onUserSubmit = (e) => {
        e.preventDefault();
        const toRegister = {
            Username : username,
            Email : email,
            Password : password
        }
        //toggleShowAdd()
       // onSubmit(toAdd)
        setUsername('');
        setEmail('')
        setPassword('');
        registerUser(toRegister)
    }

    const registerUser = async (toRegister) => {
        const res = await fetch('https://localhost:44305/Register' ,{
        method: 'POST',
        headers: {
          'Content-type': 'application/json'
        },
        body: JSON.stringify(toRegister)
        })

        
        //MIGHT not return data
         const data = await res.json();
         window.location.replace("/login");
        // console.log(data);
    
      }


    return (
        
        // <form className ="add-form"
        // onSubmit={onUserSubmit}>
        //     <br></br>
        //     <br></br>
        //     <br></br>
        //     <div className='form-control'>
        //         <label>Username</label>
        //         <input type='text' placeholder='Enter Username'
        //         value={username} onChange={(e) => setUsername(e.target.value)}></input>
        //     </div>
            
        //     <div className='form-control'>
        //         <label>Email</label>
        //         <input type='text' placeholder='Enter Email'
        //         value={email} onChange={(e) => setEmail(e.target.value)}></input>
        //     </div>

        //     <div className='form-control'>
        //         <label>Password</label>
        //         <input type='text' placeholder='Enter Rating'
        //         value={password} onChange={(e) => setPassword(e.target.value)}></input>
        //     </div>
            

            

        //     <input className='btn btn-block' type='submit' value='Register'></input>
        // </form>
        <body className="">
  <div class="main">
    <p class="sign" align="center">Register</p>
    <form class="form1"
    onSubmit={onUserSubmit}>
      <input class="un " type="text" align="center" placeholder="Username"
      value={username} onChange={(e) => setUsername(e.target.value)}/>
      <input class="un " type="text" align="center" placeholder="Email"
      value={email} onChange={(e) => setEmail(e.target.value)}/>
      <input class="pass" type="password" align="center" placeholder="Password"
       value={password} onChange={(e) => setPassword(e.target.value)}/>
        <input style={{marginLeft:"165px"}}  type = 'submit' value ='Register'></input>
     
        </form>
                
    </div>
    </body>
    )
}

export default UserRegister
