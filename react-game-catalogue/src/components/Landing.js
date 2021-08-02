import React from 'react'
import nes from '../nes.jpg'
import consoles from '../consoles.jpg'
import "./Landing.css"
import present from '../present.jpg'
import hourglass from '../hourglass.jpg'
import checkmark from '../checkmark.jpg'
const Landing = () => {

    const goToSignin = () => {
        window.location.replace("/login");
    }
    const goToRegister = () => {
        window.location.replace("/register");
    }
    return (
        <>
            
           <section className="bg-dark text-light p-5 text-center">
               <div className="container">
                   <div className="d-sm-flex">
                   <div style={{width:"33%"}}>
                       <img className="img-fluid"  src={nes} alt=""/>
                       </div>
                       <div style={{width:"33%"}}>
                           <h1> 
                               <span className="text-warning"> Games Catalogue</span> 
                            </h1>
                            <p className="lead my-4">Browse through hundreds of games and track the ratings and progress of games you've played or might play one day!
                            </p>
                            <button onClick={goToRegister} style={{marginRight:"200px"}} className="btn btn-primary btn-lg my-4">Register</button>
                            
                             <button onClick={goToSignin} style={{marginLeft:"20px"}} className="btn btn-primary btn-lg my-4">Sign in</button>
                       </div >
                       <div style={{width:"33%"}}>
                       <img className="img-fluid"  src={consoles} alt=""/>
                       
                       </div>
                       
                   </div>        
               </div>
           </section>
          
           <div class="newRow">
  <div className="newColumn bg-dark text-light p-5 text-center" style={{marginLeft:"3.0%"}} >
     <img className="img"  src={present} alt=""/>
     <p className="lead my-4">Catalogue games you want to play one day!</p>
  </div>
  <div className="newColumn bg-dark text-light p-5 text-center">
    <img className="img"  src={hourglass} alt=""/>
    <p className="lead my-4">Keep track of the Games you need to finish!</p>
  </div>
  <div className="newColumn bg-dark text-light p-5 text-center">
    <img className="img"  src={checkmark} alt=""/>
    <p className="lead my-4">Remember the games you have conquered!</p>
  </div>
</div>
        </>
    )
}

export default Landing
