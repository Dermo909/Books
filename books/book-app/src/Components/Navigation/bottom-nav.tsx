
import { BottomNavigation, BottomNavigationAction, Paper } from '@mui/material';
import { FaPlus } from 'react-icons/fa';
import { BsBook, BsHeart, BsGear } from "react-icons/bs";
import { useEffect, useState } from 'react';
import { createBrowserHistory } from 'history';
export const historyHelper = createBrowserHistory();

export function BottomNav() {
    const [value, setValue] = useState(0);

    function goTo(link: string) {
        historyHelper.push('/' + link);
        historyHelper.go(0);
    }

    return (
        <>
            <Paper sx={{ position: 'fixed', bottom: 0, left: 0, right: 0, zIndex: 9999 }} elevation={3}>
                <BottomNavigation
                    showLabels
                    value={value}
                    onChange={(e, value) => {setValue(value);}}
                >
                    <BottomNavigationAction label="Books" onClick={(e) => goTo('bookslist')} icon={<BsBook />} />
                    <BottomNavigationAction label="ReadingList" onClick={(e) => goTo('readinglist')} icon={<BsHeart />} />
                </BottomNavigation>
            </Paper>
        </>);
}