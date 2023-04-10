import React, { useEffect, useState } from "react";
import { bookService } from "../../Services/book-service";
import { BookVM } from "../../ViewModels/BookVM";
import { Grid } from '@mui/material';
import { ReadingListItem } from "./reading-list-item";
import { readingListService } from "../../Services/reading-list-service";
import { ReadingListItemVM } from "../../ViewModels/ReadingListItemVM";

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
                    <Grid container>
                        {readingListData.map(book => <ReadingListItem book={book} emitOnBookDelete={emitOnBookDelete} key={book.id}/>)}
                    </Grid>
                </>
            }
        </>);
}