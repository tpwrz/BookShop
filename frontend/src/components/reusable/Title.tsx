import React from "react";
import styled from "styled-components";

const Tit = styled.div`
font-size: 25px;
display: flex;
margin-left: 35%;
margin-bottom: 2%;`

export default function Title(props:any){
    return <Tit>{props.title}</Tit>
}