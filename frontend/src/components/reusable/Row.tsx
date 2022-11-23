import { Button } from "@mui/material";
import React from "react";
import styled from "styled-components"
import { ThemeProvider } from "@mui/material/styles";
import theme from "./Theme";
import Txt from "./Txt";

const Inside = styled.div`
background-color: #eceae5;
    margin-top: 20px;
    margin-bottom: 10px;
    padding-bottom: 10px;
    width: 90%;
    flex-wrap: wrap;
    display: flex;
    align-items: center;
    justify-self: center;
    justify-content: space-between;
    &:hover{
        background-color: #dcdad6; 
    }`

export default function Row(props: any) {
    if (props.btn) {
        return <ThemeProvider theme={theme}>
            <Inside>
                <Txt text={props.value} under={props.under} pref={props.pref}></Txt>
                <Button type="submit"
                    variant="contained"
                    sx={{ mt: 3, mb: 2, mr:4, }}>CHANGE</Button>
            </Inside>
        </ThemeProvider>
    }
    else return <ThemeProvider theme={theme}>
        <Inside>
            <Txt text={props.value} under={props.under} pref={props.pref}></Txt>
        </Inside></ThemeProvider >
}