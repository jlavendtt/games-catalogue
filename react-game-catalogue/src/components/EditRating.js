import React from 'react'
import {useState, useEffect} from 'react'

const EditRating = ({editReview, toggleShowAdd, user, game}) => {
    const [started, setStarted] = useState(false)
    const [rating, setRating] = useState(0)
    const [completed, setCompleted] = useState(false)

    const onUserSubmit = (e) => {
        e.preventDefault();
        const toAdd = {
            GameId : game.id,
            UserId : user.id,
            Rating : rating,
            Completed : completed,
            Started : started
        }
        toggleShowAdd()
        editReview(toAdd)
        setStarted(false);
        setRating(0)
        setCompleted(false);
    }

    return (
        <form className ="add-form"
        onSubmit={onUserSubmit}>
            <div className='form-control'>
                <label>Rating</label>
                <input type='text' placeholder='Enter Rating'
                value={rating} onChange={(e) => setRating(e.target.value)}></input>
            </div>
            
            <div className='form-control form-control-check' >
                <label>Started Game</label>
                <input type='checkbox'
                
                value={started} onChange={(e) => setStarted(e.currentTarget.checked)}
                ></input>
            </div>

            <div className='form-control form-control-check' >
                <label>Completed Game</label>
                <input type='checkbox'
                
                value={completed} onChange={(e) => setCompleted(e.currentTarget.checked)}
                ></input>
            </div>

            <input className='btn btn-block' type='submit' value='Add Rating'></input>
        </form>
    )
}

export default EditRating
