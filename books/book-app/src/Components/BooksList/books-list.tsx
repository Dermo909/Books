import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";
import { BookVM } from "../../ViewModels/BookVM";
import { Fab, Grid } from '@mui/material';
import { BookListItem } from "./book-list-item";
import { authorService } from "../../Services/author-service";
import { AuthorVM } from "../../ViewModels/AuthorVM";
import { genreService } from "../../Services/genre-service";
import { GenreVM } from "../../ViewModels/GenreVM";
import { FaPlus } from "react-icons/fa";

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

    function emitOnChange() {
        fetchData();
    }

    return (
        <>
            {bookData && bookData.length > 0 && !isLoading &&
                <>
                    <Grid container style={{ paddingTop: "16px" }}>
                        {bookData.map(book => <BookListItem book={book}
                            authors={authorData}
                            genres={genreData}
                            emitOnChange={emitOnChange}
                            key={book.id} />)}
                    </Grid>
                </>
            }

            {(!bookData || bookData.length === 0) && !isLoading &&
                <Grid container>
                    <Grid item>No Books!</Grid>
                </Grid>
            }
            <Fab
                color="primary"
                sx={{
                    position: 'absolute',
                    bottom: (theme) => theme.spacing(12),
                    right: (theme) => theme.spacing(6),
                }}
            >
                <FaPlus />
            </Fab>
        </>);
}