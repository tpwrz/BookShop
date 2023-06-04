import { List, Avatar, IconButton, ListItem, ListItemAvatar, ListItemText, ThemeProvider } from '@mui/material';
import * as React from 'react';
import DeleteRoundedIcon from '@mui/icons-material/DeleteRounded';
import MenuBookRoundedIcon from '@mui/icons-material/MenuBookRounded';
import Link from '../reusable/Link';
import theme from '../reusable/Theme';
import useFetch from '../../hooks/UseFetch';
import { Book } from '../entities/Book';




export default function Items() {
 // const cards: Book[] = useFetch("https://localhost:7136/api/Books");
 const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];
  return <ThemeProvider theme={theme}>
    <List >
      {cards.map(card =>
        <ListItem
          secondaryAction={
            <IconButton edge="end" aria-label="delete">
              <DeleteRoundedIcon />
            </IconButton>
          }
        >
          <ListItemAvatar>
            <Avatar>
              <MenuBookRoundedIcon />
            </Avatar>
          </ListItemAvatar>
          <ListItemText
            primary={card}
            secondary={card+"$"}
          />
        </ListItem>,
      )}
    </List>
    <Link href="checkout" value="CHECKOUT">CHECKOUT</Link>
  </ThemeProvider>

}