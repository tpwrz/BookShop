import React from "react";
import styled from "styled-components";
import Next from "../imgs/next.png"
import Link from "../reusable/Link";

const Item = styled.div`
display: flex;
justify-content: space-between;
padding: 10%;
margin: 3% 4%;
align-content: center;
align-items: center;
&:hover{
    color: #a61e4d;
    background-color: #e2dfd6;
    font-size: 15px;
}`

export default function Sidebar(props:any){
    return <Item>
    <Link href={props.href} value={props.text}>
        </Link> 
        <img src={Next} height="20px"/>
    </Item>
       
}