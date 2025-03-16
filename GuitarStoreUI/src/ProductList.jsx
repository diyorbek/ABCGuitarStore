import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import {
  Box,
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  CircularProgress,
  Grid,
  IconButton,
  Typography,
  colors,
} from '@mui/material';
import { Link } from 'react-router';
import { useFetch } from './api';
import { useShoppingCart } from './storage';
import { priceFormatter } from './utils';

export function ProductList({ storeId, name, category }) {
  const { addToCart } = useShoppingCart();

  const { data, loading, error } = useFetch(
    `/store/${storeId}?name=${name}&category=${category}`
  );

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

  if (!data || !data.result || data.result.length === 0) {
    return (
      <Box
        display="flex"
        flexDirection="column"
        gap={4}
        padding={8}
        color="text.secondary"
      >
        <Typography align="center" variant="h5">
          No products found
        </Typography>
      </Box>
    );
  }

  return (
    <Grid container spacing={4}>
      {data?.result?.map((product) => (
        <Grid key={product.id} item xs={12} sm={6} md={4}>
          <Card>
            <CardActionArea
              LinkComponent={Link}
              to={`/${storeId}/${product.id}`}
            >
              <CardMedia
                component="img"
                height="300"
                image={product.images[0]}
                alt={product.name}
              />
              <CardContent>
                <Typography
                  gutterBottom
                  variant="h6"
                  component="div"
                  sx={{ height: 60 }}
                >
                  {product.name}
                </Typography>

                <Typography
                  color={
                    product.isUsed ? colors.orange[600] : colors.green[600]
                  }
                >
                  {product.isUsed ? 'Used' : 'New'}
                </Typography>
                <Typography fontWeight="bold" fontSize={30}>
                  {priceFormatter.format(product.price)}
                </Typography>

                <IconButton
                  onClick={(e) => {
                    e.preventDefault();
                    addToCart(product);
                  }}
                >
                  <AddShoppingCartIcon />
                </IconButton>
              </CardContent>
            </CardActionArea>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
}
