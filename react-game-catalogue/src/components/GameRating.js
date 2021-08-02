import React from 'react'
import {Link} from 'react-router-dom'

const GameRating = ({rating}) => {
    return (
        <div>
             {rating ? 
                <>
                <h1>Rating Score</h1> 
                <Link to ={"/user/"+rating.rater.id}>{rating.rater.username}</Link>
                <h1>No Need for picture</h1>
                <h1>Checkmarks and other stuff indicating completion</h1>
                </> : 'err'}
        </div>
    )
}

export default GameRating
