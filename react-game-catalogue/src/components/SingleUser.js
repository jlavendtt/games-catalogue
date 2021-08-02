import React, { Component } from 'react'
import UserRatings from './UserRatings'

export default class SingleUser extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
            url : window.location.href,
            user : [],
            globalUser : this.props.globalUser 
        }
    }

    componentDidMount() {
        let splitUrl = this.state.url.split('/')
        let id = splitUrl[splitUrl.length-1];
        const parsed = JSON.parse(document.cookie);
            const fetchUser = async (id) => {
            const res = await fetch(`https://localhost:44305/UserById/${id}`, {
                headers: {
                    'Authorization': `Bearer ${parsed.token}`,
                   }
            })
        
            const data = await res.json();
        
            return data;
          }
    
          const getUser = async () => {
    
            const userFromServer = await fetchUser(id);
            this.setState({
              user: userFromServer
            })
          }
          getUser()
       }
    
    render() {
        return (
            <div>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <br></br>
                <h1>{this.state.user.username}'s Profile</h1>
                <UserRatings user = {this.state.user}/>
            </div>
        )
    }
}


// import React from 'react'

// const SingleUser = ({globalUser}) => {
//     return (
//         <div>
//             <br></br>
//             <br></br>
//             <br></br>
//             <br></br>
//             <h1>hi</h1>
//         </div>
//     )
// }

// export default SingleUser
