
import React, { lazy, Suspense } from 'react';
import './CSS/App.css';
import Header from './Components/Header'
import { BrowserRouter as Router, Routes as Switch, Route, Link, BrowserRouter, Routes } from "react-router-dom"
import Loader from './Components/Loader';
import Footer from './Components/Footer';
import PersonalDate from './Pages/PersonalDate'
import Location from './Pages/Location';
import Start from './Pages/Start';
import Logged from './Components/Logged';
import Signedup from './Components/Signedup';
const Login = lazy(() => import("./Pages/Login"))
const Signup = lazy(() => import("./Pages/Signup"))
function App() {
  //localStorage.setItem("logged", "false")
  return (
    <BrowserRouter>
      <Suspense fallback={<Loader />}>
        <Routes>
          <Route path="/signedup" element={<Signedup />} />
          <Route path="/logged" element={<Logged />} />
          <Route path="/" element={<Start />} />
          <Route path="/login" element={<Login />} />
          <Route path="/signup" element={<Signup />} />
          <Route path="/personalDate" element={<PersonalDate />} />
          <Route path="/location" element={<Location />} />
        </Routes>

        <Footer></Footer>
        <div id="Back"></div>
      </Suspense>
    </BrowserRouter>
  );
}

export default App;
