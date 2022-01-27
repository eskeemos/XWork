import './Signup.css';
import React, { useState } from 'react';
import Button from '@mui/material/Button';
import { Formik, Form, Field, ErrorMessage, useFormik } from "formik";
import TextField from '@mui/material/TextField';
import LocalizationProvider from '@mui/lab/LocalizationProvider';
import AdapterDateFns from '@mui/lab/AdapterDateFns';
import { DatePicker } from '@mui/lab';
import * as Yup from 'yup';
import { Checkbox, FormControlLabel, Switch } from '@mui/material';
import instance from '../axios/axios';
import Header from '../Components/Header';
export default function Location() {
    const formik = useFormik({
        initialValues: {
            id: localStorage.getItem("locationid"),
            voivodeship: "",
            county: "",
            municipality: "",
            postalCode: "",
            locality: "",
            street: "",
            homeCode: "",

        },
        validationSchema: Yup.object({
        }),
        onSubmit: values => {
            //alert(JSON.stringify(values, null, 2));
            instance.put('https://localhost:44393/api/Location', values).then(resp => {
                console.log(resp.data);
            });
        },

    });
    const validationFunction = () => {

    }
    return (
        <div>
            <div id="signupContainer">
                <h1 id="center">Location</h1>
                <form onSubmit={formik.handleSubmit}>

                    <div id="linia"></div><br />
                    <br />
                    <div className="line">
                        <div className="flex">
                            <TextField
                                helperText="Please enter your voivodeship"
                                label="voivodeship"
                                id="voivodeship"
                                name="voivodeship"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.voivodeship}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText="Please enter your county"
                                label="county"
                                id="county"
                                name="county"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.county}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText="Please enter your municipality"
                                label="municipality"
                                id="municipality"
                                name="municipality"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.municipality}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div id="pole">
                            <div className="flex">
                                <TextField
                                    helperText="postal code"
                                    label="post code"
                                    id="postalCode"
                                    name="postalCode"
                                    type="text"
                                    onChange={formik.handleChange}
                                    value={formik.values.postalCode}
                                    style={{ width: 100 }}
                                />
                            </div>
                            <div className="flex">
                                <TextField
                                    helperText="Please enter your locality"
                                    label="locality"
                                    id="locality"
                                    name="locality"
                                    type="text"
                                    onChange={formik.handleChange}
                                    value={formik.values.locality}
                                    style={{ width: 350 }}
                                />
                            </div>
                        </div>
                        <div className="flex">
                            <TextField
                                helperText="Please enter your street"
                                label="street"
                                id="street"
                                name="street"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.street}
                                style={{ width: 225 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText="Please enter your home code"
                                label="home code"
                                id="homeCode"
                                name="homeCode"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.homeCode}
                                style={{ width: 225 }}
                            />
                        </div>
                        <div className="flex">
                            <Button onClick={() => validationFunction()} id="buttonlong" variant="contained" type="submit" style={{ width: 480 }}>sign up</Button>
                        </div>
                    </div>
                </form >
            </div >
            <Header></Header>
            <div id="backgroundsignup"></div>
        </div>
    );
};