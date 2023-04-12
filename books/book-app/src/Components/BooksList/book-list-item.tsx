import { Alert, Button, Collapse, Grid, TextField } from "@mui/material";
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
    emitOnChange: () => void
}) {
    const [icon, setIcon] = useState(<FaBook />);
    const [isEdit, setIsEdit] = useState(false);
    const [isDelete, setIsDelete] = useState(false);

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
                params.emitOnChange();
            },
                (e) => {
                    console.log('Error');
                });
    }

    function saveEdit() {
        return bookService
            .put(params.book)
            .then((json: any) => {
                params.emitOnChange();
            },
                (e) => {
                    console.log('Error');
                });
    }

    return (
        <>
            <>
                <Grid item xs={1} style={{ paddingLeft: "14px" }}>{icon}</Grid>
                <Grid item xs={5}>{params.book.title}</Grid>
                <Grid item xs={3}>({params.book.authorName})</Grid>
                <Grid item xs={1}>
                    <Button
                        fullWidth
                        disableElevation
                        onClick={(e) => setIsEdit(true)}
                    >
                        <FaEdit style={{ color: "#32a852", height: "20px", width: "20px" }}/>
                    </Button>
                </Grid>
                <Grid item xs={2}>
                    <Button
                        fullWidth
                        disableElevation
                        onClick={(e) => setIsDelete(true)}
                    >
                        <FaTrashAlt  style={{ color: "#f55142", height: "20px", width: "20px" }}/>
                    </Button>
                </Grid>
            </>
            {isEdit === true &&
                <>
                    <Grid item xs={12}><Alert severity="info" onClick={(e) => setIsEdit(false)}>Editing!</Alert></Grid>
                </>
            }
            {isDelete === true &&
                <>
                    <Grid item xs={12}><Alert severity="info" onClick={(e) => setIsDelete(false)}>Deleting!</Alert></Grid>
                </>
            }
        </>
    );
}