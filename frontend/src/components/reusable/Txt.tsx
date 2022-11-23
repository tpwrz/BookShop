import React from "react";
import styled from "styled-components";

const T = styled.div`
float: left;
position: relative;
padding-top: 3%;
margin-left: 4%;
font-size: 18px;
color: #32302d;
width: 70%;
&:hover{
    background-color: #dcdad6;
}`

const Span = styled.span`
float: left;
position: relative;
padding-top: 3%;
margin-left: 4%;
margin-bottom: 10px;
font-size: 15px;
color: #57534d;`

export default function Txt(props: any) {
    return <T>{props.text}<br></br>
        <Span>
            {props.under}
        </Span>
        {props.pref}
        </T>
}