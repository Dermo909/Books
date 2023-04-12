import { AppBar, Button, Toolbar } from "@mui/material";
import { BsPlus } from "react-icons/bs";

export function TopNav() {
    return(
    <>
    <AppBar position="static">
        <Toolbar sx={{ marginLeft: "auto", marginRight: "0px!important" }}>
        </Toolbar>
    </AppBar>
    </>);
}