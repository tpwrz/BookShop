import React from "react";
import Link from "../reusable/Link"
import styled from "styled-components"

const Foot = styled.div`padding: 30px 0;
background: #7c7a75;
color: white;
margin-top:4em;
padding-right:20px;
display: flex;
flex-wrap: wrap;
flex-direction: column;
align-items: flex-end;`


export default function Footer(){
    return <Foot>
            <div >
                <div>
                    <Link href='/' value="Home"></Link> |
                    <Link href=''value="About us"></Link> |
                    <Link href=''value="Contacts">Contacts</Link>
                </div>
            </div>
            <div ><span>Poverjuc Tatiana for AMDARIS © 2022</span></div>
        </Foot>


}