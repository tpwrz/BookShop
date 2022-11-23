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
import { CloudinaryContext, Transformation, Image } from 'cloudinary-react';
import { constructor, useState } from 'react';
import axios from 'axios';

const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];

class Home extends React.Component {

 
  componentDidMount() {
    axios.get('http://res.cloudinary.com/christekh/image/list/xmas.json')
      .then(res => {
        console.log(res.data.resources);
        this.setState({ gallery: res.data.resources });
      });
  }

  render() {
    const [favourite, setState] = useState(false);
    const setIcon = (id: number) => {
      this.setState(favourite => !favourite);
      console.log(favourite);
    }

    constructor() {
      this.state = {
        gallery: []
      }
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
                   
                   <CloudinaryContext cloudName="christekh">
                        {
                            this.state.gallery.map((data: { public_id: React.Key | null | undefined; created_at: string | number | boolean | React.ReactElement<any, string | React.JSXElementConstructor<any>> | React.ReactFragment | React.ReactPortal | null | undefined; }) => {
                                return (
                                    <div className="responsive" key={data.public_id}>
                                        <div className="img">
                                            <a target="_blank" href={`http://res.cloudinary.com/christekh/image/upload/${data.public_id}.jpg`}>
                                                <Image publicId={data.public_id}>
                                                    <Transformation
                                                        crop="scale"
                                                        width="300"
                                                        height="200"
                                                        dpr="auto"
                                                        responsive_placeholder="blank"
                                                    />
                                                </Image>
                                            </a>
                                            <div className="desc">Created at {data.created_at}</div>
                                        </div>
                                    </div>
                                )
                            })
                        }
                    </CloudinaryContext>
                   
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
}