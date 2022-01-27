import "./Start.css"
import React, { useState } from 'react';
import { Link } from "react-router-dom";
export default function Start() {

    return (
        <div>
            <div id="startTitle"><h1><div id="X" className="startLetters">X</div><div id="work" className="startLetters">Work</div></h1></div>
            <div id="line2"></div>
            <p className="startText">make your application for a job a lot of easier today!</p>
            <div id="buttonHolder">
                <Link to="/login"><div className="startbutton" >sign in</div></Link>
                <Link to="/signup"><div className="startbutton">sign up</div></Link>
            </div>
        </div>
    );
};