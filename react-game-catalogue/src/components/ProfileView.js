import React from 'react'
import UserRatedGame from './UserRatedGame'

const ProfileView = ({user}) => {
    return (
        <>
                {user && user.ratings ? user.ratings.map(rating => <UserRatedGame user = {user} rating = {rating} key = {rating.id}/>) : 'hmm'}
        </>
    )
}

export default ProfileView
