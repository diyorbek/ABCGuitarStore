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
import { Link, Route, Routes } from 'react-router';
import { Home } from './Home';
import { ProductDetails } from './ProductDetails';
import { Products } from './Products';
import { ShoppingCart } from './ShoppingCart';
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

              <ShoppingCart />
            </Box>
          </Toolbar>
        </Container>
      </AppBar>

      <Routes>
        <Route path="/:storeId/:productId" Component={ProductDetails} />

        <Route path="/:storeId" Component={Products} />

        <Route index Component={Home} />
      </Routes>
    </>
  );
}

export default App;
