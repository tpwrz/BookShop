import * as React from 'react';
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import CardMedia from '@mui/material/CardMedia';
import CssBaseline from '@mui/material/CssBaseline';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { ThemeProvider } from '@mui/material/styles';
import FavoriteBorderIcon from '@mui/icons-material/FavoriteBorder';
import FavoriteOutlinedIcon from '@mui/icons-material/FavoriteOutlined';
import theme from '../reusable/Theme';
import { useState } from 'react';
import axios from 'axios';
import useFetch from '../UseFetch';

const cards = useFetch();

function Home(){
  
  const [favourite, setState] = useState(false);
  const setIcon = (id: number) => {
    setState(favourite => !favourite);
    console.log(favourite);
  }
   
    return (
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <main>
          <Container sx={{ py: 4 }} maxWidth="md">
            <Grid container spacing={3}>
              {cards.map((card) => (
                <Grid item key={card} xs={10} sm={6} md={4} lg={3}>
                  <Card
                    sx={{ height: '100%', display: 'flex', flexDirection: 'column' }}>
                    <CardMedia
                      component="img"
                      sx={{
                        pt: '10%',
                      }}
                      image="https://res.cloudinary.com/dw4zyn95l/image/upload/v1669031954/samples/ecommerce/accessories-bag.jpg"
                      alt="random"
                    />
                    <CardContent sx={{ flexGrow: 1 }}>
                      <Typography gutterBottom variant="h5" component="h2">
                        Heading
                      </Typography>
                      <Typography>
                        This is a media card. You can use this section to describe the
                        content.
                      </Typography>
                    </CardContent>
                    <CardActions>
                      <Button size="small" onClick={() => setIcon(101) /*props.id*/} >{favourite ? <FavoriteOutlinedIcon /> : <FavoriteBorderIcon />}</Button>
                      <Button size="small">Add to Cart</Button>
                    </CardActions>
                  </Card>
                </Grid>
              ))}
            </Grid>
          </Container>
        </main>
      </ThemeProvider>
    );
  }


export default Home;