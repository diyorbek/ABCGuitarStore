import { Box, Button, TextField } from '@mui/material';
import { useState } from 'react';
import { StoreList } from './StoreList';
import { Breadcrumb } from './Breadcrumb';

export function Home() {
  const [name, setName] = useState('');
  const [city, setCity] = useState('');
  const [query, setQuery] = useState({ name, city });

  return (
    <>
      <Box margin="auto" paddingTop={2}>
        <Breadcrumb />
      </Box>

      <Box py={4} display="flex" flexDirection="column">
        <Box
          width="100%"
          component="form"
          onSubmit={(event) => {
            event.preventDefault();
            setQuery({ name, city });
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

      <StoreList {...query} />
    </>
  );
}
