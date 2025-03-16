import CssBaseline from '@mui/material/CssBaseline';
import { red } from '@mui/material/colors';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import * as React from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter } from 'react-router';
import App from './App';
import { BreadcrumbContextProvider } from './Breadcrumb';
import { StorageContext } from './storage';

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
    <BrowserRouter>
      <BreadcrumbContextProvider>
        <ThemeProvider theme={theme}>
          <StorageContext>
            <CssBaseline />
            <App />
          </StorageContext>
        </ThemeProvider>
      </BreadcrumbContextProvider>
    </BrowserRouter>
  </React.StrictMode>
);
