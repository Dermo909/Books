import { Button, Grid, LinearProgress } from "@mui/material";
import { FaTrashAlt } from 'react-icons/fa';
import { ReadingListItemVM } from "../../ViewModels/ReadingListItemVM";

export function ReadingListItem(params: { book: ReadingListItemVM, emitOnBookDelete: () => void }) {
    return (
        <>
            <Grid item xs={8}>{params.book.title}</Grid>
            <Grid item xs={2}><LinearProgress variant="determinate" value={params.book.readingStatus} /></Grid>
            <Grid item xs={2}>                
                <Button
                    fullWidth
                    disableElevation
                    onClick={params.emitOnBookDelete}
                >
                    <FaTrashAlt />
                </Button></Grid>
        </>);
}