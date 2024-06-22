import {
  AppBar,
  Avatar,
  Box,
  Button,
  Card,
  CardContent,
  CardMedia,
  Container,
  IconButton,
  TextField,
  Toolbar,
  Typography,
} from "@mui/material";
import { useState } from "react";
import { useFetch } from "./useFetch";

export function Home() {
  const [name, setName] = useState("");
  const [city, setCity] = useState("");
  const { data, loading } = useFetch(`/store`);
  console.log(data);
  return (
    <>
      <Box py={4} display="flex" flexDirection="column">
        <Box
          alignSelf="center"
          display="flex"
          justifyContent="space-between"
          gap={4}
        >
          <TextField
            label="Store Name"
            value={name}
            onChange={({ target }) => setName(target.value)}
          />
          <TextField
            label="City"
            value={city}
            onChange={({ target }) => setCity(target.value)}
          />
          <Button variant="contained">Search</Button>
        </Box>
      </Box>

      <Box display="flex" flexDirection="column" gap={4}>
        <Card sx={{ height: 180, display: "flex" }}>
          <CardMedia
            component="img"
            sx={{ width: 200, height: 200, objectFit: "cover" }}
            image="https://media.gettyimages.com/id/78057641/photo/guitars-in-music-store.jpg?s=612x612&w=0&k=20&c=kPQaoZ5d9Wown6J_vLQjlKiaJLEbdDJeYRnqkeqUI0Y="
            alt="Live from space album cover"
          />
          <CardContent sx={{ flex: 1 }}>
            <CardContent sx={{ flex: "1 0 auto" }}>
              <Typography component="div" variant="h5">
                Live From Space
              </Typography>
              <Typography
                variant="subtitle1"
                color="text.secondary"
                component="div"
              >
                Mac Miller
              </Typography>
              <Button sx={{ mt: 4 }} variant="outlined">
                View products
              </Button>
            </CardContent>
          </CardContent>
        </Card>
      </Box>
    </>
  );
}
