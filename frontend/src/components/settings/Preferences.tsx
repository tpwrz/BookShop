import { Button, Checkbox, FormControlLabel, Grid } from "@mui/material";
import React from "react";
import { ThemeProvider } from "@mui/material/styles";
import theme from "../reusable/Theme";
import Input from "./Input";




export default function Preferences() {
    return <ThemeProvider theme={theme}>

        <Grid item xs={12}>
            <FormControlLabel
                control={<Checkbox value="Newsteller" color="primary" />}
                label="Newsletter with the latest promotions in all READ books"
            />
            <FormControlLabel
                control={<Checkbox value="SMS" color="primary" />}
                label="SMS with the latest promotions"
            />
            <FormControlLabel
                control={<Checkbox value="Personalized email" color="primary" />}
                label="Personalized e-mails or communications such as 'Your product now has a different price' or 'Your basket contains products with reduced stock"
            />
            <FormControlLabel
                control={<Checkbox value="Book.exe Premium" color="primary" />}
                label="Information related to Book.exe Premium points and activities"
            />
            <FormControlLabel
                control={<Checkbox value="Newsteller" color="primary" />}
                label="Newsletter with the latest promotions in all READ books"
            />
        </Grid>
        <Button type="submit"
            variant="contained"
            sx={{ mt: 3, mb: 2, mr: 4, }}>CHANGE</Button>
    </ThemeProvider>
}
