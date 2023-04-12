import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";
import { BookVM } from "../../ViewModels/BookVM";
import { Fab, Grid } from '@mui/material';
import { ReadingListItem } from "./reading-list-item";
import { readingListService } from "../../Services/reading-list-service";
import { ReadingListItemVM } from "../../ViewModels/ReadingListItemVM";
import { FaPlus } from "react-icons/fa";

export function ReadingList() {
    const [readingListData, setReadingListData] = useState<Array<ReadingListItemVM>>([]);

    useEffect(() => {
        fetchData();
    }, []);

    function fetchData() {
        return readingListService
            .getAll()
            .then((json: any) => {
                console.log('reading list json: ', json)
                setReadingListData(json);
            },
                (e) => {
                    console.log('Error');
                });
    }

    function emitOnBookDelete() {
        console.log('delete book');
    }

    return (
        <>
            {readingListData && readingListData &&
                <>
                    <Grid container style={{ paddingTop: "16px" }}>
                        {readingListData.map(book => <ReadingListItem book={book} emitOnBookDelete={emitOnBookDelete} key={book.id} />)}
                    </Grid>
                </>
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