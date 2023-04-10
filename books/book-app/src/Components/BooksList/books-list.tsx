import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";
import { BookVM } from "../../ViewModels/BookVM";
import { Grid, List, ListItem, ListItemText } from '@mui/material';
import { BookListItem } from "./book-list-item";
import { authorService } from "../../Services/author-service";
import { AuthorVM } from "../../ViewModels/AuthorVM";
import { genreService } from "../../Services/genre-service";
import { GenreVM } from "../../ViewModels/GenreVM";

export function BooksList() {
    const [bookData, setBookData] = useState<Array<BookVM>>([]);
    const [authorData, setAuthorData] = useState<Array<AuthorVM>>([]);
    const [genreData, setGenreData] = useState<Array<GenreVM>>([]);
    const [isLoading, setIsLoading] = useState(false);

    useEffect(() => {
        fetchData();
        fetchAuthors();
        fetchGenres();
    }, []);

    function fetchData() {
        setIsLoading(true);
        return bookService
            .getAll()
            .then((json: any) => {
                setBookData(json);
            },
                (e) => {
                    console.log('Error');
                })
            .finally(() => setIsLoading(false));;
    }

    function fetchAuthors() {
        return authorService
            .getAll()
            .then((json: any) => {
                setAuthorData(json);
                console.log('author data: ', json);
            },
                (e) => {
                    console.log('Error');
                });
    }

    function fetchGenres() {
        return genreService
            .getAll()
            .then((json: any) => {
                setGenreData(json);
                console.log('genre data: ', json);
            },
                (e) => {
                    console.log('Error');
                });
    }

    function emitOnDelete() {
        fetchData();
    }

    return (
        <>
            {bookData && bookData.length > 0 && !isLoading && 
                <>
                    <Grid container>
                        {bookData.map(book => <BookListItem book={book}
                            authors={authorData}
                            genres={genreData}
                            emitOnDelete={emitOnDelete}
                            key={book.id} />)}
                    </Grid>
                </>
            }
            
            {(!bookData || bookData.length === 0) && !isLoading && 
                <Grid container>
                    <Grid item>No Books!</Grid>
                </Grid>
            }
        </>);
}