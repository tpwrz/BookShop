import React from "react";
export interface Book {
    isbn: string,
    title: string,
    author: string,
    genre: string,
    pages: number,
    price: number,
    available: boolean
}