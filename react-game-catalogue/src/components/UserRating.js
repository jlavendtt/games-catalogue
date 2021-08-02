import React from 'react'
import {Link} from 'react-router-dom'
import {useState, useEffect} from 'react'
import ReactStars from 'react-stars'


const UserRating = ({curReview}) => {

    const [started, setStarted] = useState(false)
    const [rating, setRating] = useState(0)
    const [completed, setCompleted] = useState(false)
    const [description, setDescription] = useState('')


    return (
        <div>
            <div>
            <div class="form-check">
  <input disabled="disabled" checked={curReview.started} class="form-check-input" type="checkbox"  id="flexCheckDefault"
  value={curReview.started} onChange={(e) => setStarted(e.currentTarget.checked)}/>
  <label class="form-check-label" for="flexCheckDefault">
    Started
  </label>
  </div>
  
  <div class="form-check">
  <input disabled="disabled" checked={curReview.completed} class="form-check-input" type="checkbox"  id="flexCheckDefault"
  value={curReview.completed} onChange={(e) => setCompleted(e.currentTarget.checked)}/>
  <label class="form-check-label" for="flexCheckDefault">
    Beaten
  </label>
  </div>
  </div>
  
        
            
            <ReactStars style={{marginLeft:"100px"}}
        count={5}
        
        value = {curReview.rating}
        editing={false}
        edit = {false}
        half = {false}
        size={24}
        color2={'#ffd700'} />
        
        {/* <input type='text' style={{height:"200px",width: "500px"}} placeholder='Write Review Here'
                value={description} onChange={event => {setDescription(event.target.value)}}/> */}
                <p className="comment" style={{width: "200px"}}>{curReview.description}</p>
                
                
            



             
        </div>
    )
}

export default UserRating
