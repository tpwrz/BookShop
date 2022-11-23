import React from "react";
import styled from "styled-components";
import Title from "../reusable/Title";
import Sidebar from "./Sidebar";
import Row from "../reusable/Row";
import Preferences from "./Preferences";
import Button from "../reusable/Button";

const Container = styled.div`
width: 90%;
display: flex;
align-self: center;
justify-self: center;
margin: auto;
margin-bottom: 10px;
column-count: 2;`

const Nav = styled.div`
width: 25%;
margin: 1% 1% 2% 2%;
padding-top: 5%;`

const Main = styled.div`    margin: 1% 1% 1% 1%;
width: 90%;`

export default function Settings() {
     
    return <Container>
        <Nav>
            <Sidebar href="" text="Account "></Sidebar>
            <Sidebar href="" text="Orders"></Sidebar>
            <Sidebar href="" text="Adresses"></Sidebar>
            <Sidebar href="" text="Payment  "></Sidebar>
            <Sidebar href="" text="Favourites"></Sidebar>
        </Nav>

        <Main>
            <Title title = "Account Settings"/>
            <Row value="Email" under="your.email@mail.com" btn="CHANGE"/>
            <Row value="Password" under="******" btn="CHANGE"/>
            <Row value="Personal Data" under={`Name: Poverjuc Tatiana \n Date of birth:  unset`} btn="CHANGE"/>
            <Row value="Email" under="your.email@mail.com" btn="CHANGE"/>
            <Row value="Preferences" under="Select the communication categories from which you want to receive notifications at
                            your_email@gmail.com" pref={<><Preferences /></>} />
        </Main>
    </Container>
}

