import React from "react";

export default class Book {
    constructor(public ISBN: string, public Title: string, public Price: number, 
        public available: boolean, public Author: string = 'unknown',
        public Genre: string = 'unknown', public Pages:number ) {
    }
   
}