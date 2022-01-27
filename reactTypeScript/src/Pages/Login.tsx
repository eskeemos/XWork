import './Login.css';
import React, { useState } from 'react';
import ReactDOM from 'react-dom';
import Button from '@mui/material/Button';
import { Formik, useFormik } from 'formik';
import instance from '../axios/axios';
import { TextField } from '@mui/material';
import Header from '../Components/Header';
import { Link, useNavigate } from 'react-router-dom';
export default function Login() {
    const [passwordTitle, setPasswordTitle] = useState<string>("Please enter your password")
    const [passwordStatus, setPasswordStatus] = useState<boolean>(true)
    const [emailTitle, setEmailTitle] = useState<string>("Please enter your password")
    const [emailStatus, setEmailStatus] = useState<boolean>(true)
    const navigate = useNavigate();
    const formik = useFormik({
        initialValues: {
            email: '',
            password: ''
        },
        onSubmit: values => {
            console.log(values)
            instance.post('https://localhost:44393/api/Account/login', values).then(resp => {
                console.log(resp.data.error);
                if (resp.data.error == null) {
                    localStorage.clear()
                    localStorage.setItem("token", "Bearer " + resp.data.jwt)
                    localStorage.setItem("id", resp.data.id)
                    localStorage.setItem("logged", "true")
                    instance.get('https://localhost:44393/api/Account/' + localStorage.getItem("id")).then(resp => {
                        //console.log(resp.data.location.id, resp.data.personalData.id);
                        localStorage.setItem("locationid", resp.data.locationId)
                        localStorage.setItem("personalid", resp.data.personalDataId)
                        navigate('/logged')
                    });
                }
                if (resp.data.error == "Incorrect Password") {
                    setPasswordTitle("Incorrect password")
                    setPasswordStatus(false)
                }
                else {
                    setPasswordTitle("Please enter your password")
                    setPasswordStatus(true)
                }
                if (resp.data.error == "User with this email don't exists") {
                    setEmailTitle("User with this email don't exists")
                    setEmailStatus(false)
                }
                else {
                    setEmailTitle("Please enter your email")
                    setEmailStatus(true)
                }
            });
        },
    });
    return (
        <div>
            {/* <img className="backGroundImage" src="https://image.freepik.com/free-vector/access-control-system-abstract-concept_335657-3180.jpg" alt="obrazek" />
            <div id="border"></div> */}
            <div id="loginPage">
                <div id="loginContainer">
                    <div id="loginicon"><div id="empty"></div><div id="head"></div><div id="arms"></div></div>
                    <form onSubmit={formik.handleSubmit}>
                        <h1>Login</h1>
                        <div id="linia"></div><br />
                        <TextField
                            helperText={emailTitle}
                            error={!emailStatus}
                            label="Email"
                            id="email"
                            name="email"
                            type="email"
                            onChange={formik.handleChange}
                            value={formik.values.email}
                        />
                        <br />
                        <br />
                        <TextField
                            helperText={passwordTitle}
                            error={!passwordStatus}
                            label="Password"
                            id="password"
                            name="password"
                            type="password"
                            onChange={formik.handleChange}
                            value={formik.values.password}
                        />
                        <br />
                        {/* <a href="">Forgot Password?</a> */}
                        <br /><br />
                        <Button id="button" variant="contained" type="submit">login</Button>
                        <p>Not a member? <Link to="/signup">Sign up</Link></p>
                    </form>
                </div>
            </div>
            <div id="backgroundlogin"></div>
            <Header></Header>
        </div>
    );
};