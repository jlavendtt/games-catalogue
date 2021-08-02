import React from 'react'
import UserRating from './UserRating'

const UserRatings = ({user}) => {
    return (
        <div>
            {user && user.ratings ? user.ratings.map((rating)=> 
            <div>
                
                <h1 style={{textAlign: 'center'}}>{rating.ratedGame.name}</h1>
                <div style={{display : "flex", justifyContent: "center" }}>
                    <div>
                <img className='img' style={{height: '200px', width: 'auto'}}
      src={rating.ratedGame.pic}
      alt="new"
      />
      </div>
                
                <UserRating curReview={rating} key={rating.gameId}></UserRating> 
                </div>
                <hr></hr>
            </div>) : ''}
        </div>
    )
}

export default UserRatings
