import 'bootstrap/dist/css/bootstrap.css'
import { Nav, Navbar, NavDropdown } from 'react-bootstrap'
import { BrowserRouter as Router, Route, Link } from 'react-router-dom'
import { useState, useEffect } from 'react'
import Profile from './components/Profile'
import Home from './components/Home'
import SingleGame from './components/SingleGame';
import SingleUser from './components/SingleUser';
import UserRegister from './components/UserRegister';
import UserLogin from './components/UserLogin';
import React from 'react';
import './App.css';
import sprite from './download.png';
import AddRating from './components/AddRating'
import Rating from 'react-simple-star-rating'
import Landing from './components/Landing'

const userContext = React.createContext('token');

function App() {


  const [token, setToken] = useState(null);


  const [globalUser, setGlobalUser] = useState([])

  const [games, setGames] = useState([])

  const [users, setUsers] = useState([])

  const [searchedGames, setSearchedGames] = useState([])

  const [user, setUser] = useState(null)

  const [ratings, setRatings] = useState([])

  const [searchTerm, setSearchTerm] = useState('')

  useEffect(() => {

    const getGames = async () => {

      const gamesFromServer = await fetchGames();
      setGames(gamesFromServer)
      const tokenUser = JSON.parse(document.cookie)

      const foundUser = await fetchUser(tokenUser.username);
      setGlobalUser(foundUser)
      //     const usersFromServer = await fetchUsers();
      //     setUsers(usersFromServer);
      //     const jesse = await fetchUser(1002)
      //     var today = new Date();
      //     console.log(today)
      //    setGlobalUser(jesse)
    }

    getGames()



  }, [])

  const fetchUsers = async () => {
    const res = await fetch('https://localhost:44305/User')

    const data = await res.json();

    return data;
  }

  const fetchUser = async (name) => {

    const parsed = JSON.parse(document.cookie);

    const res = await fetch(`https://localhost:44305/User/${name}`, {
      headers: {
        'Authorization': `Bearer ${parsed.token}`,
      }
    })

    const data = await res.json();
    return data;
  }

  const signOut = () => {
    document.cookie += '; Max-Age=0'
    console.log('signout called')
    console.log(document.cookie)
    window.location.replace("/");
  }



  const signOutUser = async (something) => {

    console.log("signout was clicked")

  }

  const fetchGames = async () => {
    const parsed = JSON.parse(document.cookie);
    const res = await fetch('https://localhost:44305/Game', {
      headers: {
        'Authorization': `Bearer ${parsed.token}`,
      }
    })

    const data = await res.json();

    return data;
  }

  const searchForGames = (e) => {


    if (e) {
      e.preventDefault();
    }

    console.log('was search for game called')

    let found = games.filter((game) => {
      if (searchTerm === "") {
        return false
      }
      if (game.name.toLowerCase().includes(searchTerm.toLowerCase())) {
        return true;
      }
    })
    setSearchedGames(found);

    setSearchTerm('')

  }

  const editGame = async (edited) => {
    const res = await fetch('https://localhost:44305/Game', {
      method: 'PUT',
      headers: {
        'Content-type': 'application/json'
      },
      body: JSON.stringify(edited)
    })

    const getGames = async () => {

      const gamesFromServer = await fetchGames();
      setGames(gamesFromServer)
    }

    getGames()

  }

  const editReview = async (edited) => {
    console.log(edited)
    const res = await fetch('https://localhost:44305/UserRating', {
      method: 'PUT',
      headers: {
        'Content-type': 'application/json'
      },
      body: JSON.stringify(edited)
    })

    await reloadUser(globalUser.id);

  }



  const selectUser = (user) => {
    setUser(user);
    setRatings(user.ratings)
  }

  const fetchGame = async (id) => {
    const res = await fetch(`https://localhost:44305/Game/${id}`)

    const data = await res.json();

    return data;
  }

  const deleteGame = async (id) => {
    await fetch(`address${id}`, {
      method: 'DELETE',
    })

    setGames(games.filter((game) => game.id !== id))
  }

  const addGame = async (game) => {
    const res = await fetch('api', {
      method: 'POST',
      headers: {
        'Content-type': 'application/json'
      },
      body: JSON.stringify(game)
    })

    const data = res.json();

    setGames([...games, data])
  }

  const addRating = async (rating) => {
    const parsed = JSON.parse(document.cookie);
    console.log(rating)
    const res = await fetch('https://localhost:44305/UserRating', {
      method: 'POST',
      headers: {
        'Content-type': 'application/json',
        'Authorization': `Bearer ${parsed.token}`,
      },
      body: JSON.stringify(rating)
    });

    const data = await res.json();
    console.log(data)

  }



  const reloadUser = async (id) => {
    const res = await fetch(`https://localhost:44305/User/${id}`)

    const data = await res.json();
    setUser(data)
  }

  const addUser = async (user) => {
    const res = await fetch('https://localhost:44305/User', {
      method: 'POST',
      headers: {
        'Content-type': 'application/json'
      },
      body: JSON.stringify(user)
    });

    const updatedUsers = await fetchUsers();
    setUsers(updatedUsers);
  }

  return (

    <div className="App">
      <Router>
      {document.cookie !== '' ? <Navbar bg="dark" variant="dark"
          fixed="top">
          <Navbar.Brand>
            <img className="logo" style={{ marginLeft: '20px' }} src={sprite}></img>
          </Navbar.Brand>

          <Nav className="nav-popular-spacing">

            <Navbar.Brand style={{ marginLeft: "140px" }}><Nav.Link href="/home">Library </Nav.Link></Navbar.Brand>
          </Nav>
          <form className="searchSpacing"
            onSubmit={searchForGames}>
            <input className="searchWidth" value={searchTerm} onChange={event => { setSearchTerm(event.target.value) }} type="search" placeholder="Find Games" aria-label="Search" />
            {window.location.href !== 'http://localhost:3000/home' ? <Link to="/home"><button className="btn btn-outline-success btn-spacing" type="submit">Search</button></Link> : ''}
            {window.location.href === 'http://localhost:3000/home' ? <button className="btn btn-outline-success btn-spacing" type="submit">Search</button> : ''}
          </form>
          <NavDropdown className="nav-profile-spacing" title="User Profile">
            <NavDropdown.Item href="/profile">Profile</NavDropdown.Item>
            <NavDropdown.Item onClick={signOut}  >Signout</NavDropdown.Item>
          </NavDropdown>
          <Navbar.Brand>
            <img className="logo" src={sprite}></img>
          </Navbar.Brand>
        </Navbar> 
        : ''}
        
        <Route path='/register'
          exact
          render={(props) => (
            <>
              <UserRegister


              />
            </>
          )}
        />
        <Route path='/login'
          exact
          render={(props) => (
            <>
              <UserLogin
                setToken={setToken}
                token={token}
              />
            </>
          )}
        />
       
        <Route path="/user/:id">
          <SingleUser globalUser={globalUser} />
        </Route>
        <Route path="/game/:id">
          <SingleGame
            addRating={addRating}
            user={globalUser} />
        </Route>
        <Route path='/profile'
          exact
          render={(props) => (
            <>
              <Profile
                user={globalUser}
                token={token}
              />
            </>
          )}
        />
        <Route path='/home'
          exact
          render={(props) => (
            <>
              <Home
                games={searchedGames}
                user={globalUser}
                onSubmit={addRating}
                editReview={editReview}
                allGames={games}
                searchTerm={searchTerm}
                clearSearchTerm={setSearchTerm}
                search={searchForGames}
              />
            </>
          )}
        />
        

        
        {document.cookie === '' && window.location.href === 'http://localhost:3000/' ? <Landing /> : ''}
      </Router>


    </div>


  );
}

export default App;
