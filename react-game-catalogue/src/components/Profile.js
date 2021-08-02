import React from 'react'
import ProfileView from './ProfileView'
import UserRatings from './UserRatings'
import {useState, useEffect, createContext} from 'react'
import AddRating from './AddRating'
import UserRating from './UserRating'
import { AiFillAlert } from "react-icons/ai";

const fetchUser = async (name) => {
    
    const parsed = JSON.parse(document.cookie);
    
    const res = await fetch(`https://localhost:44305/User/${name}`, {
        headers: {
            'Authorization': `Bearer ${parsed.token}`,
           }
    })

    const data = await res.json();
    return data;
  }

  const fetchStarted = async (name) => {
    
    const parsed = JSON.parse(document.cookie);
    
    const res = await fetch(`https://localhost:44305/UserRating/Started`, {
        headers: {
            'Authorization': `Bearer ${parsed.token}`,
           }
    })

    const data = await res.json();
    return data;
  }

  const fetchNotStarted = async (name) => {
    
    const parsed = JSON.parse(document.cookie);
    
    const res = await fetch(`https://localhost:44305/UserRating/NotStarted`, {
        headers: {
            'Authorization': `Bearer ${parsed.token}`,
           }
    })

    const data = await res.json();
    return data;
  }

  const fetchCompleted = async (name) => {
    
    const parsed = JSON.parse(document.cookie);
    
    const res = await fetch(`https://localhost:44305/UserRating/Completed`, {
        headers: {
            'Authorization': `Bearer ${parsed.token}`,
           }
    })

    const data = await res.json();
    return data;
  }



const Profile = () => {


    const [user, setUser] = useState(null);
    const [started, setStarted] = useState(null)
    const [notStarted, setNotStarted] = useState(null)
    const [completed, setCompleted] = useState(null)
    const [seeStarted, setSeeStarted] = useState(false)
    const [seeNotStarted, setSeeNotStarted] = useState(false)
    const [seeCompleted, setSeeCompleted] = useState(false)

    const toggleStarted = () => {
        setSeeStarted(true);
        setSeeNotStarted(false)
        setSeeCompleted(false);
    }

    const toggleNotStarted = () => {
        
        setSeeNotStarted(true)
        setSeeCompleted(false);
        setSeeStarted(false);
    }

    const toggleCompleted = () => {
        setSeeStarted(false);
        setSeeNotStarted(false)
        setSeeCompleted(true);
    }

    useEffect(() => {
        
        const xyz = async () => {
            if (document.cookie) {
        
                const  tokenUser = JSON.parse(document.cookie)
        
                 const foundUser = await fetchUser(tokenUser.username);
                 setUser(foundUser) 
                 const fulCompletedUser = await fetchUser(tokenUser.username);
                 const completedUser = await fetchCompleted(tokenUser.username);
                 fulCompletedUser.ratings = completedUser;
                 setCompleted(fulCompletedUser) 
                 const startedUser = await fetchStarted(tokenUser.username);
                 const fullStartedUser = await fetchUser(tokenUser.username);
                 fullStartedUser.ratings = startedUser;
                 setStarted(fullStartedUser) 
                 const notStartedUser = await fetchNotStarted(tokenUser.username);
                 const fullNotStartedUser = await fetchUser(tokenUser.username);
                 fullNotStartedUser.ratings = notStartedUser
                 setNotStarted(fullNotStartedUser) 
            }
         
            

        }
        xyz();

    },[])

    
    return (
        <>
            <br></br>
            <br></br>
            <br></br>
            
            {!user ?<h1>Sign in first!</h1> : ''}
            {user ? <h1 style={{textAlign: 'center'}}>Welcome {user.username}!</h1> : ''}
            <br></br>
            <br></br>
            
            
            <button style={{marginLeft:"400px"}} onClick={toggleCompleted}> Completed</button>
            <button style= {{marginLeft:"200px"}} onClick={toggleStarted}>Started</button>
            <button style= {{marginLeft:"200px"}} onClick={toggleNotStarted}>Wishlist</button>
            
            {user && user.ratings && !seeCompleted && !seeNotStarted && !seeStarted ? <UserRatings user = {user}>/</UserRatings> : ''}
            {completed && completed.ratings && seeCompleted ? <UserRatings user = {completed}>/</UserRatings> : ''}
            {started && started.ratings && seeStarted ? <UserRatings user = {started}>/</UserRatings> : ''}
            {notStarted && notStarted.ratings && seeNotStarted ? <UserRatings user = {notStarted}>/</UserRatings> : ''}
            
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
        </>
    )
}

export default Profile
