import CssBaseline from '@mui/material/CssBaseline';
import { red } from '@mui/material/colors';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import * as React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter as Router } from 'react-router-dom';
import App from './App';
import { BreadcrumbContextProvider } from './Breadcrumb';

const rootElement = document.getElementById('root');
const root = createRoot(rootElement);

// Create a theme instance.
const theme = createTheme({
  palette: {
    primary: {
      main: '#556cd6',
    },
    secondary: {
      main: '#19857b',
    },
    error: {
      main: red.A400,
    },
  },
});

root.render(
  <React.StrictMode>
    <Router>
      <BreadcrumbContextProvider>
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <App />
        </ThemeProvider>
      </BreadcrumbContextProvider>
    </Router>
  </React.StrictMode>
);
