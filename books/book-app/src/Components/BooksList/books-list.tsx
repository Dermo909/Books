import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";

export function BooksList() {
    useEffect(() => {
        fetchData();
    }, []);

    function fetchData() {
        return bookService
        .getAll()
        .then((json: any) => {
            console.log('json received: ', json);
        },
        (e) => {
            console.log('Error');
        });
    }
    return(<>BookList</>);
}