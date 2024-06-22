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
import { Home } from "./Home";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <AppBar position="static">
        <Container maxWidth="md">
          <Toolbar>
            <Typography
              variant="h6"
              noWrap
              component="a"
              href="#app-bar-with-responsive-menu"
              sx={{
                mr: 2,
                display: { xs: "none", md: "flex" },
                fontFamily: "monospace",
                fontWeight: 700,
                color: "inherit",
                textDecoration: "none",
              }}
            >
              ABS Guitar Stores
            </Typography>

            <Box
              sx={{
                flex: 1,
                gap: 2,
                display: "flex",
                flexDirection: "row-reverse",
              }}
            >
              <IconButton sx={{ p: 0 }}>
                <Avatar alt="User" />
              </IconButton>
              <Button variant="contained">Orders</Button>
              <Button variant="contained" href="/">
                Home
              </Button>
            </Box>
          </Toolbar>
        </Container>
      </AppBar>

      <Container maxWidth="sm">
        <Home />
      </Container>
    </>
  );
}

export default App;
