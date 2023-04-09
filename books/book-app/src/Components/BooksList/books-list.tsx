import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";
import { BookVM } from "../../ViewModels/BookVM";
import { Grid, List, ListItem, ListItemText } from '@mui/material';
import { BookListItem } from "./book-list-item";

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

    function emitOnBookEdit() {
        console.log('edit book');
    }

    return (
        <>
            {bookData && bookData &&
                <>
                    <Grid container>
                        {bookData.map(book => <BookListItem book={book} emitOnBookEdit={emitOnBookEdit} key={book.id}/>)}
                    </Grid>
                </>
            }
        </>);
}