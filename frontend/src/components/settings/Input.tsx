import React from "react";
import styled from "styled-components";

const Chsub = styled.div`
font-size: 13px;
    font-weight: lighter;
    margin-left: 25px;
    color: #7c7a75;
    line-height: 1.5;`

export default function Input(props: any) {
    return <>
        <input type="checkbox" id="news" />
        <label>{props.label}</label>
        <Chsub>{props.text}</Chsub>
    </>
}