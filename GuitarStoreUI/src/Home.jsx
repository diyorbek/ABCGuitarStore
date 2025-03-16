import { Box, Button, Container, TextField } from '@mui/material';
import { useEffect, useState } from 'react';
import { useSearchParams } from 'react-router';
import { Breadcrumb } from './Breadcrumb';
import { StoreList } from './StoreList';

export function Home() {
  const [searchParams, setSearchParam] = useSearchParams();

  const [name, setName] = useState('');
  const [city, setCity] = useState('');

  useEffect(() => {
    setName(searchParams.get('name') || '');
    setCity(searchParams.get('city') || '');
  }, [searchParams]);

  return (
    <Container maxWidth="sm">
      <Box margin="auto" paddingTop={2}>
        <Breadcrumb />
      </Box>

      <Box py={4} display="flex" flexDirection="column">
        <Box
          width="100%"
          component="form"
          onSubmit={(event) => {
            event.preventDefault();
            setSearchParam({ name, city });
            // setQuery({ name, city });
          }}
          alignSelf="center"
          display="flex"
          gap={2}
        >
          <TextField
            label="Store Name"
            value={name}
            size="small"
            onChange={({ target }) => setName(target.value)}
          />
          <TextField
            label="City"
            value={city}
            size="small"
            onChange={({ target }) => setCity(target.value)}
          />
          <Button type="submit" variant="contained">
            Search
          </Button>
        </Box>
      </Box>

      <StoreList />
    </Container>
  );
}
