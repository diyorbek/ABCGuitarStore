// @ts-check
import {
  Box,
  Button,
  CircularProgress,
  Container,
  MenuItem,
  TextField,
  Typography,
} from '@mui/material';
import { useState } from 'react';
import { useLocation, useRouteMatch } from 'react-router-dom';
import { Breadcrumb } from './Breadcrumb';
import { ProductList } from './ProductList';
import { useFetch } from './api';

const CATEGORY_OPTIONS = [
  { value: 'GUITAR', label: 'Guitar' },
  { value: 'ACCESSORY', label: 'Accessory' },
];

export function Products() {
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);

  const { params } = useRouteMatch();
  const [name, setName] = useState(searchParams.get('name') || '');
  const [category, setCategory] = useState('');
  const [query, setQuery] = useState({ name, category });
  const { data, loading, error } = useFetch(`/store/${params.storeId}`);

  if (loading) {
    return (
      <Box display="flex" justifyContent="center" padding={8}>
        <CircularProgress />
      </Box>
    );
  }

  if (error) {
    return (
      <Box display="flex" justifyContent="center" padding={8}>
        <Typography variant="h6" color="error">
          {error.message}
        </Typography>
      </Box>
    );
  }

  return (
    <>
      <Container maxWidth="sm">
        <Box margin="auto" paddingTop={2}>
          <Breadcrumb
            store={{ name: data?.store.name, link: `/${params.storeId}` }}
          />
        </Box>
      </Container>

      <Container maxWidth="sm">
        <Box py={4} display="flex" flexDirection="column">
          <Box
            width="100%"
            component="form"
            onSubmit={(event) => {
              event.preventDefault();
              setQuery({ name, category });
            }}
            alignSelf="center"
            display="flex"
            gap={2}
          >
            <TextField
              label="Category"
              select
              value={category}
              size="small"
              sx={{ width: 200 }}
              defaultValue={CATEGORY_OPTIONS[0].value}
              onChange={({ target }) => setCategory(target.value)}
            >
              {CATEGORY_OPTIONS.map(({ value, label }) => (
                <MenuItem key={value} value={value}>
                  {label}
                </MenuItem>
              ))}
            </TextField>
            <TextField
              label="Product Name"
              value={name}
              size="small"
              sx={{ width: 200 }}
              onChange={({ target }) => setName(target.value)}
            />
            <Button type="submit" variant="contained">
              Search
            </Button>
          </Box>
        </Box>
      </Container>

      <Container maxWidth="md">
        <ProductList storeId={params.storeId} {...query} />
      </Container>
    </>
  );
}
