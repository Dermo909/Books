import { Button, Grid } from "@mui/material";
import { FaBook, FaEdit, FaHatWizard, FaHiking, FaRocket } from 'react-icons/fa';
import { BookVM } from "../../ViewModels/BookVM";
import { useEffect, useState } from "react";

export function BookListItem(params: { book: BookVM, emitOnBookEdit: () => void }) {
    const [icon, setIcon] = useState(<FaBook />);

    useEffect(() => {
        setGenreIcon(params.book.genreName);
    }, []);
    
    function setGenreIcon(genre: string) {
        switch(genre) {
            case 'Fantasy': setIcon(<FaHatWizard />); break;
            case 'Science Fiction': setIcon(<FaRocket />); break;
            case 'Adventure': setIcon(<FaHiking />); break;
            case 'Horror': setIcon(<FaHatWizard />); break;
        }
    }

    return (
        <>
            <Grid item xs={1}>{icon}</Grid>
            <Grid item xs={10}>{params.book.title}</Grid>
            <Grid item xs={1}>                
                <Button
                    fullWidth
                    disableElevation
                    onClick={params.emitOnBookEdit}
                >
                    <FaEdit />
                </Button></Grid>
        </>);
}