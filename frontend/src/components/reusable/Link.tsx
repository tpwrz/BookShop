import React from "react";
import styled from "styled-components";


const Linked = styled.a`color: #291e11;
text-transform: uppercase;
font-weight: 500;
font-size: large;
text-decoration: none;
outline: none;
margin:2px;
&:hover,
  &:focus {
    color: #a61e4d;
    text-shadow: 2px 4px 5px #8d847c;
  }`

export default function Link(props:any){

    return <Linked href={props.href}>{props.value}</Linked>
}