import { createTheme, ThemeProvider } from '@mui/material/styles';
import React from 'react';


const theme = createTheme({
    palette: {
        primary: {
            main: '#a61e4d',
        },
        secondary: {
            light: '#a61e4d',
            main: '#a61e4d',
            contrastText: '#a61e4d',
        },
        contrastThreshold: 3,
        tonalOffset: 0.2,
    },

    typography: {
        fontFamily: [
            'book antiqua'
        ].join(','),
    },
}
);

export default theme;