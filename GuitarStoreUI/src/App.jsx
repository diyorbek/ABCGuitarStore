import {
  AppBar,
  Avatar,
  Box,
  Button,
  Container,
  IconButton,
  Toolbar,
  Typography,
} from '@mui/material';
import { Link, Route, Switch } from 'react-router-dom';
import { Home } from './Home';
import { ProductDetails } from './ProductDetails';
import { Products } from './Products';
import { useAuth } from './api';

function App() {
  useAuth();

  return (
    <>
      <AppBar position="static">
        <Container maxWidth="md">
          <Toolbar>
            <Typography
              variant="h6"
              noWrap
              component={Link}
              to="/"
              sx={{
                mr: 2,
                display: 'flex',
                fontFamily: 'monospace',
                fontWeight: 700,
                color: 'inherit',
                textDecoration: 'none',
              }}
            >
              ABS Guitar Stores
            </Typography>

            <Box
              sx={{
                flex: 1,
                gap: 2,
                display: 'flex',
                flexDirection: 'row-reverse',
              }}
            >
              <IconButton sx={{ p: 0 }}>
                <Avatar alt="User" />
              </IconButton>
              <Button variant="contained">Orders</Button>
              <Button variant="contained" to="/" component={Link}>
                Home
              </Button>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>

      <Switch>
        <Route path="/:storeId/:productId" exact>
          <ProductDetails />
        </Route>

        <Route path="/:storeId" exact>
          <Products />
        </Route>

        <Route path="/" exact>
          <Container maxWidth="sm">
            <Home />
          </Container>
        </Route>
      </Switch>
    </>
  );
}

export default App;
