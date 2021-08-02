import React from 'react'
import UserDisplay from './UserDisplay'
import Games from './Games'
import {useState, useEffect, createContext} from 'react'
import { useLocation } from 'react-router-dom';

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

  


const Home = ({games, onSubmit, editReview, allGames, searchTerm, clearSearchTerm, search}) => {

    const [user, setUser] = useState(null)

    const [foundGames, setFoundGames] = useState([])

    const [randGames, setRandGames] = useState([])

    const [location, setLocation] = useState([])

    useEffect(() => {

        
        // const searchForGames = () => {

      

    
    
    
        //     let found = allGames.filter((game)=> {
        //       if (searchTerm==="") {
        //         return false
        //       }
        //        if (game.name.toLowerCase().includes(searchTerm.toLowerCase())) {
        //          return true;
        //        }
        //     })
        //     setFoundGames(found)
        //     clearSearchTerm('')
            
        //  }
        
        // const xyz = async () => {
        //     if (document.cookie) {
        
        //         const  tokenUser = JSON.parse(document.cookie)
        
        //          const foundUser = await fetchUser(tokenUser.username);
        //          setUser(foundUser) 
        //     }
         
            

        // }
        // xyz();
        // searchForGames();
        search();

    },[])

    return (
        <div style={{marginTop:'100px'}}>
       
        
        {/* <h1>{window.location.href}</h1> */}
        <Games 
            games = {games}
            user = {user}
            onSubmit = {onSubmit}
            editReview = {editReview}
        />
        {games.length===0 ? <Games 
            games = {allGames.slice(15,33)}
            user = {user}
            onSubmit = {onSubmit}
            editReview = {editReview}
        /> : ''}

        
        </div>
    )
}

export default Home
