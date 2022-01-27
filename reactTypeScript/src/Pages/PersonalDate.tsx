import './Signup.css';
import React, { useState } from 'react';
import Button from '@mui/material/Button';
import { useFormik } from "formik";
import TextField from '@mui/material/TextField';
import * as Yup from 'yup';
import { FormControlLabel, Switch } from '@mui/material';
import instance from '../axios/axios';
import axios from 'axios';
import Header from '../Components/Header';
export default function Signup() {
    const [nameTitle, setNameTitle] = useState<string>("Please enter your first name")
    const [lastNameTitle, setLastNameTitle] = useState<string>("Please enter your  last name")
    const [phoneTitle, setPhoneTitle] = useState<string>("Please enter your phone number")
    const [peselTitle, setPeselTitle] = useState<string>("Please enter your pesel")
    const [bankAccountTitle, setBankAccountTitle] = useState<string>("Please enter your bank account")
    const [nameStatus, setNameStatus] = useState<boolean>(true)
    const [lastNameStatus, setLastNameStatus] = useState<boolean>(true)
    const [phoneStatus, setPhoneStatus] = useState<boolean>(true)
    const [peselStatus, setPeselStatus] = useState<boolean>(true)
    const [bankAccountStatus, setBankAccountStatus] = useState<boolean>(true)
    const formik = useFormik({
        initialValues: {
            id: localStorage.getItem("personalid"),
            name: '',
            lastName: '',
            phone: '',
            pesel: '',
            sanitaryBook: true,
            bankAccount: '',
        },
        validationSchema: Yup.object({
            name: Yup.string().required(),
            lastName: Yup.string().required(),
            phone: Yup.string().required().max(9).min(9),
            pesel: Yup.string().required().max(11).min(11),
            bankAccount: Yup.string().required().max(26).min(26),
        }),
        onSubmit: values => {
            instance.put('https://localhost:44393/api/PersonalData', values).then(resp => {
                console.log(resp.data);
            });
        },

    });
    const validationFunction = () => {
        if (formik.values.name == '') {
            setNameTitle("Name is required")
            setNameStatus(false)
        }
        else {
            setNameTitle("Please enter your first name")
            setNameStatus(true)
        }
        if (formik.values.lastName == '') {
            setLastNameTitle("Last name is required")
            setLastNameStatus(false)
        }
        else {
            setLastNameTitle("Please enter your last name")
            setLastNameStatus(true)
        }
        if (formik.values.pesel.length != 11) {
            setPeselTitle("Invalid pesel")
            setPeselStatus(false)
        }
        else {
            setPeselTitle("Please enter your pesel")
            setPeselStatus(true)
        }
        if (formik.values.bankAccount.length != 26) {
            setBankAccountTitle("Invalid bank account")
            setBankAccountStatus(false)
        }
        else {
            setBankAccountTitle("Please enter your bank account")
            setBankAccountStatus(true)
        }
        if (formik.values.phone.length != 9) {
            setPhoneTitle("Invalid phone number")
            setPhoneStatus(false)
        }
        else {
            setPhoneTitle("Please enter your phone number")
            setPhoneStatus(true)
        }
    }
    return (
        <div>
            <div id="signupContainer">
                <h1 id="center">Personal date</h1>
                <form onSubmit={formik.handleSubmit}>

                    <div id="linia"></div><br />
                    <br />
                    <div className="line">
                        <div className="flex">
                            <TextField
                                helperText={nameTitle}
                                error={!nameStatus}
                                label="first name"
                                id="name"
                                name="name"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.name}
                                style={{ width: 225 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText={lastNameTitle}
                                error={!lastNameStatus}
                                label="last name"
                                id="lastName"
                                name="lastName"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.lastName}
                                style={{ width: 225 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText={phoneTitle}
                                error={!phoneStatus}
                                label="phone"
                                id="phone"
                                name="phone"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.phone}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText={peselTitle}
                                error={!peselStatus}
                                label="pesel"
                                id="pesel"
                                name="pesel"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.pesel}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <TextField
                                helperText={bankAccountTitle}
                                error={!bankAccountStatus}
                                label="bank account"
                                id="bankAccount"
                                name="bankAccount"
                                type="text"
                                onChange={formik.handleChange}
                                value={formik.values.bankAccount}
                                style={{ width: 480 }}
                            />
                        </div>
                        <div className="flex">
                            <FormControlLabel name="sanitaryBook" control={<Switch defaultChecked onChange={formik.handleChange} />} label="sanitary book" />
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