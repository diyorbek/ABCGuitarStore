import {
  Box,
  Button,
  Card,
  CardContent,
  CardMedia,
  CircularProgress,
  Typography,
} from '@mui/material';
import { Link } from 'react-router-dom';

import { useFetch } from './api';

export function StoreList({ name, city }) {
  const { data, loading, error } = useFetch(`/store?name=${name}&city=${city}`);

  if (error) {
    return (
      <Box
        display="flex"
        justifyContent="center"
        gap={4}
        padding={8}
        color="red"
      >
        {error.message}
      </Box>
    );
  }

  if (loading) {
    return (
      <Box display="flex" justifyContent="center" gap={4} padding={8}>
        <CircularProgress />
      </Box>
    );
  }

  if (!data || data.length === 0) {
    return (
      <Box
        display="flex"
        flexDirection="column"
        gap={4}
        padding={8}
        color="text.secondary"
      >
        <Typography align="center" variant="h5">
          No stores found
        </Typography>
      </Box>
    );
  }

  return (
    <Box display="flex" flexDirection="column" gap={4}>
      {data.map((store) => (
        <Card key={store.id} sx={{ height: 180, display: 'flex' }}>
          <CardMedia
            component="img"
            sx={{ width: 200, height: 200, objectFit: 'cover' }}
            image={store.image}
            alt={store.name}
          />
          <CardContent sx={{ flex: 1 }}>
            <CardContent sx={{ flex: '1 0 auto' }}>
              <Typography component="div" variant="h5">
                {store.name}
              </Typography>
              <Typography
                variant="subtitle1"
                color="text.secondary"
                component="div"
                height={60}
              >
                {store.address.street}, {store.address.city},{' '}
                {store.address.postalCode}
              </Typography>
              <Button variant="outlined" component={Link} to={`/${store.id}`}>
                View products
              </Button>
            </CardContent>
          </CardContent>
        </Card>
      ))}
    </Box>
  );
}
