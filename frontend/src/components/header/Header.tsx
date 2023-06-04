import React, { useState } from "react";
;
import { Outlet } from "react-router-dom";
import styled from "styled-components"
import { ThemeProvider } from '@mui/material/styles';
import { Clock } from "./Clock";
import Link from "../reusable/Link"
import Logo from "../imgs/bookicon.png";
import Set from "../imgs/settings.png";
import HomeOutlinedIcon from '@mui/icons-material/HomeOutlined';
import VpnKeyOutlinedIcon from '@mui/icons-material/VpnKeyOutlined';
import LoyaltyOutlinedIcon from '@mui/icons-material/LoyaltyOutlined';
import ShoppingBagOutlinedIcon from '@mui/icons-material/ShoppingBagOutlined';
import theme from "../reusable/Theme";

const Head = styled.header`background: #ddd4c5;
box-shadow: 1px 1px 3px #e2d4c3cc;
flex-direction: column;
display: flex;
padding: 2em;
justify-content: center;
align-items: center;`

const Top = styled.div`display: flex;
flex-direction: row;
width:100%;
align-content: center;
align-items: center;
justify-content: space-between;
position: sticky;`

const Icon = styled.div`    display: flex;
flex-direction: row;
align-content: center;
width: 20%;
align-items: center;
justify-content: space-evenly;    
flex-wrap: wrap;`

const Ul_text = styled.ul`list-style: none; display: flex;
flex-direction: row;
justify-content: space-between;
width:70%;
align-items: center;
flex-wrap: wrap;
@media (max-width:910px) {
    display:none;
  }
`

const Ul_icon = styled.ul`
list-style: none; 
display: none;
width:70%;
flex-direction: row;
flex-wrap: wrap;
@media (max-width:910px) {
    display:flex;
    justify-content: space-evenly;
  }
`

export default function Header() {
    return <>
        <Head>
            <Top>
                <Icon>
                    <a href='/'><img width={60} src={Logo} /></a>
                    <Link href="/" value="Book.exe">
                    </Link>
                </Icon>
                <div><span></span></div>
                <Ul_text>
                    <li><Link href="/" value="Home">Home</Link></li>
                    <li><Link href='signin' value="Sign In">Sign In</Link></li>
                    <li><Link href='' value="Favourites">Favourites</Link></li>
                    <li><Link href='cart' value="Shopping Bag">Shopping Bag</Link></li>
                    <li><a href="settings"><img src={Set} width="25px" /></a></li>
                </Ul_text>
                <Ul_icon>
                    <ThemeProvider theme={theme}>
                        <li><a href="/"><HomeOutlinedIcon htmlColor="#0f0f0f" fontSize="medium" /></a></li>
                        <li><a href='signin' ><VpnKeyOutlinedIcon htmlColor="#0f0f0f" fontSize="medium" /></a></li>
                        <li><a href=''><LoyaltyOutlinedIcon htmlColor="#0f0f0f" fontSize="medium" /></a></li>
                        <li><a href='cart'><ShoppingBagOutlinedIcon htmlColor="#0f0f0f" fontSize="medium" /></a></li>
                        <li><a href="settings"><img src={Set} width="25px" /></a></li>
                    </ThemeProvider>
                </Ul_icon>
            </Top>
        </Head>
        <Outlet />
    </>

}

//np}


