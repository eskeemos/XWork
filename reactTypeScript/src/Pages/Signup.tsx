import './Signup.css';
import React, { useState } from 'react';
import Button from '@mui/material/Button';
import { Formik, Form, Field, ErrorMessage, useFormik } from "formik";
import TextField from '@mui/material/TextField';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import AdapterDateFns from '@mui/lab/AdapterDateFns';
import { DatePicker } from '@mui/lab';
import * as Yup from 'yup';
import axios from 'axios';
import instance from '../axios/axios';
import Header from '../Components/Header';
import { useNavigate } from 'react-router-dom';
export default function Signup() {
    const navigate = useNavigate();
    const [comparePasswords, setComparePasswords] = useState<string>("Please confirm your password")
    const [emailTitle, setEmailTitle] = useState<string>("Please enter your email")
    const [emailForm, setEmailForm] = useState<boolean>(true)
    const [checkConfirmPassword, setCheckConfirmPassword] = useState<boolean>(true)
    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
            confirmpassword: '',
            date: '',
        },
        validationSchema: Yup.object({
            password: Yup.string().required(),
            date: Yup.date().required(),
            confirmpassword: Yup.string().oneOf([Yup.ref('password'), null], 'Passwords must match')
        }),
        onSubmit: values => {
            let request = {
                email: values.email,
                password: values.password,
                birthDate: values.date,
            }
            //alert(JSON.stringify(request, null, 2));
            instance.post('https://localhost:44393/api/Account/register', request).then(resp => {
                console.log(resp.data);
                setEmailTitle("Please enter your email")
                setEmailForm(true)
                if (resp.data >= 0) {
                    let requestlogin = {
                        email: values.email,
                        password: values.password,
                    }
                    instance.post('https://localhost:44393/api/Account/login', requestlogin).then(resp => {
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
                                navigate('/signedup')
                            });
                        }
                    });
                }
            }).catch(function (error) {
                if (error.response.status == 400) {
                    setEmailTitle("Account with this email already exist")
                    setEmailForm(false)
                }
            });

        },

    });
    const validationFunction = () => {
        if (formik.values.password == formik.values.confirmpassword) {
            setCheckConfirmPassword(true)
            setComparePasswords("Please confirm your password")
        }
        else {
            setCheckConfirmPassword(false)
            setComparePasswords("Passwords must match")
        }
        let regEmail = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!regEmail.test(formik.values.email)) {
            setEmailForm(false)
            setEmailTitle("invalid email")
        }
        else {
            setEmailForm(true)
            setEmailTitle("please enter your email")
        }
    }
    return (
        <div>
            <div id="signupContainer">
                <h1 id="center">Sign up</h1>
                <form onSubmit={formik.handleSubmit}>

                    <div id="linia"></div><br />
                    <br />
                    <div className="line">
                        <div className="flex">
                            <TextField
                                helperText={emailTitle}
                                label="Email"
                                id="emaillong"
                                name="email"
                                type="email"
                                onChange={formik.handleChange}
                                value={formik.values.email}
                                error={!emailForm}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText={"Please enter your password"}
                                label="Password"
                                id="passwordlong"
                                name="password"
                                type="password"
                                onChange={formik.handleChange}
                                value={formik.values.password}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText={comparePasswords}
                                label="confirm Password"
                                id="confirmpassword"
                                name="confirmpassword"
                                type="password"
                                onChange={formik.handleChange}
                                value={formik.values.confirmpassword}
                                error={!checkConfirmPassword}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <LocalizationProvider dateAdapter={AdapterDateFns}>
                                <DatePicker
                                    label="Date of birth"
                                    value={formik.values.date}
                                    onChange={(newValue) => {
                                        console.log(newValue)
                                        formik.setFieldValue('date', newValue);
                                    }}
                                    renderInput={(formik) => (
                                        <TextField {...formik} error={false} id="date" style={{ width: 480 }} helperText="Please enter your date of birth" />
                                    )}
                                />
                            </LocalizationProvider>
                        </div>
                        <div className="flex">
                            <Button onClick={() => validationFunction()} id="buttonlong" variant="contained" style={{ width: 480 }} type="submit">sign up</Button>
                        </div>
                    </div>
                </form >
            </div >
            <Header></Header>
            <div id="backgroundsignup"></div>
        </div>
    );
};