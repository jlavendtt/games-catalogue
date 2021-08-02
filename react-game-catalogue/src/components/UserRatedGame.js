import React from 'react'
import Game from './Game'
import {BrowserRouter as Router, Route} from 'react-router-dom'
import SingleGame from './SingleGame'
import {Link} from 'react-router-dom'
const UserRatedGame = ({rating, user}) => {
    return (
        <>

           <p>{rating.rating}/10  {rating.ratedGame.name} {rating.completed ? <p> beat </p>: rating.started ? <p>not started</p> : <p> not finished </p> }</p>
           
          
         
            
        </>
    )
}

export default UserRatedGame
