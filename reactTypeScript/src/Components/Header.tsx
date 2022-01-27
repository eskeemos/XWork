import React from "react";
import { Link } from "react-router-dom";
import './Header.css'
export default function Header() {
    const logout = () => {
        localStorage.clear()
    }
    if (localStorage.getItem("logged") == "true")
        return (
            <header>
                <div id="title"><h1><div id="X" className="letters">X</div><div id="work" className="letters">Work</div></h1></div>
                <br />
                <div id="navbar">
                    <Link className="navbutton" to="/location">location</Link>
                    <Link className="navbutton" to="/personaldate">personal date</Link>
                    <Link className="navbutton" onClick={logout} to="/">log out</Link>
                </div>
            </header>
        );
    else
        return (
            <header>
                <div id="title"><h1><div id="X" className="letters">X</div><div id="work" className="letters">Work</div></h1></div>
                <br />
                <div id="navbar">
                    <Link className="navbutton" to="/login">log in</Link>
                    <Link className="navbutton" to="/signup">sign up</Link>
                    <Link className="navbutton" to="/">start</Link>
                </div>
            </header>
        )
}