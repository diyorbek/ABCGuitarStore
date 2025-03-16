import ShoppingCartIcon from '@mui/icons-material/ShoppingCart';
import { IconButton } from '@mui/material';
import Badge from '@mui/material/Badge';

import { useShoppingCart } from './storage';

export function ShoppingCart() {
  const { cart } = useShoppingCart();

  return (
    <IconButton>
      <Badge badgeContent={cart.length} color="error">
        <ShoppingCartIcon />
      </Badge>
    </IconButton>
  );
}
