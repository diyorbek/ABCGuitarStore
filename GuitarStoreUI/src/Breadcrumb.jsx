import GrainIcon from '@mui/icons-material/Grain';
import HomeIcon from '@mui/icons-material/Home';
import WhatshotIcon from '@mui/icons-material/Whatshot';
import Breadcrumbs from '@mui/material/Breadcrumbs';
import Link from '@mui/material/Link';
import Typography from '@mui/material/Typography';
import { createContext, useContext, useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';

const BreadcrumbContext = createContext({});

export const useBreadcrumb = () => useContext(BreadcrumbContext);

export function BreadcrumbContextProvider({ children }) {
  const [stack, setStack] = useState([]);

  const push = (item) => setStack((prev) => [...prev, item]);
  const pop = () => setStack((prev) => prev.slice(0, -1));

  return (
    <BreadcrumbContext.Provider value={{ stack, push, pop }}>
      {children}
    </BreadcrumbContext.Provider>
  );
}

export function Breadcrumb({ store, product }) {
  return (
    <div role="presentation">
      <Breadcrumbs aria-label="breadcrumb">
        <Link
          underline="hover"
          component={RouterLink}
          sx={{ display: 'flex', alignItems: 'center' }}
          color="inherit"
          to="/"
        >
          <HomeIcon sx={{ mr: 0.5 }} fontSize="inherit" />
          Home
        </Link>

        {store && (
          <Link
            underline="hover"
            component={RouterLink}
            sx={{ display: 'flex', alignItems: 'center' }}
            color="inherit"
            to={store.link}
          >
            <WhatshotIcon sx={{ mr: 0.5 }} fontSize="inherit" />
            {store.name}
          </Link>
        )}

        {product && (
          <Typography
            sx={{ display: 'flex', alignItems: 'center' }}
            color="text.primary"
          >
            <GrainIcon sx={{ mr: 0.5 }} fontSize="inherit" />
            {product.name}
          </Typography>
        )}
      </Breadcrumbs>
    </div>
  );
}
