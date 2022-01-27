import axios from "axios";
import React from "react";
const instance = axios.create({
    headers: { 'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*', Authorization: localStorage.getItem("token") ?? "" }
});
console.log(localStorage.getItem("token"));

export default instance