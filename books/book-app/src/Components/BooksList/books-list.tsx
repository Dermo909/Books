import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";
import { BookVM } from "../../ViewModels/BookVM";
import { List, ListItem, ListItemText } from '@mui/material';

export function BooksList() {
    const [bookData, setBookData] = useState<Array<BookVM>>([]);
    useEffect(() => {
        fetchData();
    }, []);

    function fetchData() {
        return bookService
        .getAll()
        .then((json: any) => {
            console.log('json received: ', json);
            setBookData(json);
        },
        (e) => {
            console.log('Error');
        });
    }
    return(
    <>
    {bookData && bookData &&
    <List>
        {bookData.map(book => <ListItem key={book.id}>
            <ListItemText primary={book.title} />
        </ListItem>)}
        
    </List>
}
    </>);
}