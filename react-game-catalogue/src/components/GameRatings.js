import React from 'react'
import GameRating from './GameRating'
import userSprite from '../userSprite.png'

const gameratings = ({user, ratings}) => {
    return (
        <div>
            <img className="logo"  src={userSprite}></img>
            {user && ratings ? ratings.map((rating)=> <GameRating rating={rating} key={rating.rater.id}></GameRating> ) : ''}
        </div>
    )
}

export default gameratings
