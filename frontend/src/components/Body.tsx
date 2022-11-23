import React from "react";
import { Routes, Route,BrowserRouter as Router } from "react-router-dom";
import styled from "styled-components";
import Checkout from "./cart/Checkout";
import Footer from "./footer/Footer";
import Header from "./header/Header";
import Home from "./home/Home";
import Settings from "./settings/Settings";
import SignIn from "./signIn/SignIn";
import SignUp from "./signIn/SignUp";

const Bod = styled.div`font-family: 'book antiqua';
font-size: 14px;
background-color: #f3f1ed;
width:85%;
margin: auto;
display: flex;
flex-direction: column;
flex-wrap: wrap;
justify-content: center;`


export default function Body() {
    return <Bod>
        
        <Router>
            <Routes>
                <Route path="/" element={<Header/>}>
                    <Route index element={<Home/>} />
                    <Route path="settings" element={<Settings/>} />
                    <Route path="signin" element={<SignIn />} />
                    <Route path="checkout" element={<Checkout />} />
                    <Route path="signup" element={<SignUp />} />
                </Route>
            </Routes>
        </Router>
        <Footer />
    </Bod>
}