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
import theme from '../reusable/Theme';
import { useState } from 'react';
import { Stack, Pagination, Checkbox, FormControlLabel, FormGroup } from '@mui/material';
import { Filter } from '../reusable/pagination/Filter';


function Home() {
  const [pageIndex, setPageIndex] = useState(1);
  const [filters, setFilters] = useState<Filter[]>([]);

  function changePage(event: React.ChangeEvent<unknown>, page: number) {
    setPageIndex(page);
    console.log(pageIndex)
  }

  const setFilterOnChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    if (event.target.checked) {
      setFilters([...filters, {
        path: "DanceType.Name",
        value: event.target.value.toString(),
        expression: 0
      }
      ]);
    }
    else {
      const clearedFilters = filters.filter(x => x.value !== event.target.value.toString());
      setFilters(clearedFilters);
    }
  }

  //const filteredResult: PaginatedResult<Book> = usePaginatedFetch("https://localhost:7136/api/Books/paginated", (pageIndex - 1), 3, filters);
  //const cards = filteredResult.items;
  //const cards: Book[] = useFetch("https://localhost:7136/api/Books");
  const cards = [1, 2, 3, 4, 5, 6, 7, 8, 9];
  const [favourite, setState] = useState(false);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <main>
        <div style={{ width: '100%',padding: '2%', display: 'flex',
         justifyContent: "center"}}>
          <FormGroup style={{ fontFamily: 'Montserrat' }} row={true}>
            <FormControlLabel control={<Checkbox value="Available" onChange={setFilterOnChange} />} label="Available" />
            <FormControlLabel control={<Checkbox value="Must-Go" onChange={setFilterOnChange} />} label="Must-Go" />
            <FormControlLabel control={<Checkbox value="Pre Order" onChange={setFilterOnChange} />} label="Pre Order" />
            <FormControlLabel control={<Checkbox value="Unavailable" onChange={setFilterOnChange} />} label="Unavailable" />
          </FormGroup>
        </div>
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
                      {card}
                    </Typography>
                    <Typography>
                     {card}$ {"\n"}
                      {!card ? " Available": " Unavailable"}
                    </Typography>
                  </CardContent>
                  <CardActions>
                    <Button size="small" /*onClick={() => setIcon(101) /*props.id*/ >{ /*? <FavoriteOutlinedIcon /> :*/ <FavoriteBorderIcon />}</Button>
                    <Button size="small">Add to Cart</Button>
                  </CardActions>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Container>
      </main>
      <Stack spacing={2} style={{ margin: '0 auto', display: 'block' }}>
        <Pagination count={3/*Math.ceil(filteredResult.total / filteredResult.pageSize)*/} page={pageIndex} onChange={changePage} />
      </Stack>
    </ThemeProvider>
  );
}


export default Home;