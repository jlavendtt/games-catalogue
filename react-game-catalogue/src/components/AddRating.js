import React from 'react'
import ReactStars from 'react-stars'
import {useState, useEffect} from 'react'
import userSprite from '../userSprite.png'

const AddRating = ({game, user, addRating, toggleReview}) => {

    
    const [started, setStarted] = useState(false)
    const [rating, setRating] = useState(0)
    const [completed, setCompleted] = useState(false)
    const [description, setDescription] = useState('')

    const ratingChanged = (newRating) => {
        setRating(newRating)
      }

      const onUserSubmit = (e) => {
        e.preventDefault();
        const toAdd = {
            GameId : game.id,
            UserId : user.id,
            Rating : rating,
            Completed : completed,
            Started : started,
            Description : description
        }
        addRating(toAdd)
        setStarted(false);
        setRating(0)
        setCompleted(false);
        setDescription('')
        toggleReview(toAdd)
    }

    return (
        <div>
            <div>
            <div class="form-check">
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault"
  value={started} onChange={(e) => setStarted(e.currentTarget.checked)}/>
  <label class="form-check-label" for="flexCheckDefault">
    Started
  </label>
  </div>
  
  <div class="form-check">
  <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault"
  value={completed} onChange={(e) => setCompleted(e.currentTarget.checked)}/>
  <label class="form-check-label" for="flexCheckDefault">
    Beaten
  </label>
  </div>
  </div>
  
        
            
            <ReactStars style={{marginLeft:"100px"}}
        count={5}
        onChange={ratingChanged}
        value = {rating}
        // edit = {false}
        half = {false}
        size={24}
        color2={'#ffd700'} />
        
                
                <textarea wrap="hard" style={{height:"200px",width: "500px"}} placeholder='Write Review Here'
                value={description} onChange={event => {setDescription(event.target.value)}}/>
                <button onClick={onUserSubmit} style={{display: 'block'}}>Post</button>
                
            



             
        </div>
        
    )
}

export default AddRating
