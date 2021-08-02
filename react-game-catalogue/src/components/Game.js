import React from 'react'
import {useState, useEffect} from 'react'
import MakeRating from './MakeRating'
import EditRating from './EditRating'
import { withRouter } from 'react-router-dom'
import {Link} from 'react-router-dom'
import {BrowserRouter as Router, Route} from 'react-router-dom'
import SingleGame from './SingleGame'
import '../Game.css'



const Game = ({game, user, onSubmit, editReview}) => {
    
    const [showAdd, setShowAdd] = useState(false)


    const toggleShowAdd = () => {
        setShowAdd(!showAdd)
    }

    const hasReview = () => {
        if(!user) return false;
        for (let i = 0; i<user.ratings.length;++i) {
                if (game.id === user.ratings[i].gameId) {
                    return true;
                }
        }
        return false;
    }

    return (
        <Link style={{textDecoration: 'none'}} to ={"/game/"+game.id}>
        <div className="card">
        
           <span className="gameTitle">{game.name}</span> 
            <br></br>
            <img className='img'
      src={game.pic}
      alt="new"
      />
        
             
            {/* {!showAdd && user && !hasReview() ? <button onClick={toggleShowAdd}>add review</button> : ''}
           {showAdd && user && !hasReview() ?  <MakeRating 
                user = {user}
                game = {game}
                onSubmit = {onSubmit}
                toggleShowAdd = {toggleShowAdd}
            /> : ''}
            {!showAdd && user && hasReview() ? <button onClick={toggleShowAdd}>Edit review</button> : ''}
           {showAdd && user && hasReview() ?  <EditRating 
                user = {user}
                game = {game}
                editReview = {editReview}
                toggleShowAdd = {toggleShowAdd}
            /> : ''} */}
           
            
            

           
        </div>
        </Link>
    )
}

export default withRouter(Game);
