import { Button, Collapse, Grid, TextField } from "@mui/material";
import { FaBook, FaEdit, FaHatWizard, FaHiking, FaRegSave, FaRegWindowClose, FaRocket, FaTrashAlt } from 'react-icons/fa';
import { BookVM } from "../../ViewModels/BookVM";
import { useEffect, useState } from "react";
import { authorService } from "../../Services/author-service";
import { AuthorVM } from "../../ViewModels/AuthorVM";
import { GenreVM } from "../../ViewModels/GenreVM";
import { bookService } from "../../Services/book-service";

export function BookListItem(params: { 
    book: BookVM, 
    authors: Array<AuthorVM>, 
    genres: Array<GenreVM>,
    emitOnDelete: () => void  }) 
    {
    const [icon, setIcon] = useState(<FaBook />);
    const [isEdit, setIsEdit] = useState(false);

    useEffect(() => {
        setGenreIcon(params.book.genreName);
    }, []);

    function setGenreIcon(genre: string) {
        switch (genre) {
            case 'Fantasy': setIcon(<FaHatWizard />); break;
            case 'Science Fiction': setIcon(<FaRocket />); break;
            case 'Adventure': setIcon(<FaHiking />); break;
            case 'Horror': setIcon(<FaHatWizard />); break;
        }
    }



    function bookDelete() {
        return bookService
        .disable(params.book.id)
        .then((json: any) => {
            params.emitOnDelete();
        },
            (e) => {
                console.log('Error');
            });
    }

    function saveEdit() {
        return bookService
        .put(params.book)
        .then((json: any) => {
            params.emitOnDelete();
        },
            (e) => {
                console.log('Error');
            });
    }

    return (
        <>
            {isEdit === false &&
                <>
                    <Grid item xs={1}>{icon}</Grid>
                    <Grid item xs={5}>{params.book.title}</Grid>
                    <Grid item xs={4}>({params.book.authorName})</Grid>
                    <Grid item xs={1}>
                        <Button
                            fullWidth
                            disableElevation
                            onClick={(e) => setIsEdit(true)}
                        >
                            <FaEdit />
                        </Button>
                    </Grid>
                    <Grid item xs={1}>
                        <Button
                            fullWidth
                            disableElevation
                            onClick={bookDelete}
                        >
                            <FaTrashAlt />
                        </Button>
                    </Grid>
                </>
            }
            {isEdit &&
                <Collapse in={isEdit}>
                    <Grid item xs={5}>
                        <TextField id="book-title" label="Book Title" variant="filled" />
                    </Grid>
                    <Grid item xs={4}>
                        <TextField id="book-author" label="Book Author" variant="filled" />
                    </Grid>
                    <Grid item xs={3}>
                        <TextField id="book-genre" label="Book Genre" variant="filled" />
                    </Grid>
                    <Grid item xs={6}>
                        <FaRegSave onClick={saveEdit}/>
                    </Grid>
                    <Grid item xs={6}>
                        <FaRegWindowClose onClick={(e) => setIsEdit(false)}/>
                    </Grid>
                </Collapse>

            }
        </>
    );
}