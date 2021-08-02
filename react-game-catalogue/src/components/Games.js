import React from 'react'
import Game from './Game'
import '../Games.css'

const Games = ({games, user, onSubmit, editReview}) => {
    return (
        <div className = "container">
        
            {games.map(game=> <Game game = {game} editReview = {editReview} onSubmit = {onSubmit} key = {game.id} user = {user}/>)}
        
        </div>
    )
}

export default Games
