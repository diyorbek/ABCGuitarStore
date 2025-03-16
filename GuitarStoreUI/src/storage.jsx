import { createContext, useContext, useEffect, useState } from 'react';

const CART_KEY = 'SHOPPING_CART';

function getCart() {
  return JSON.parse(localStorage.getItem(CART_KEY) || '[]');
}

function addToCart(product) {
  const cart = JSON.parse(localStorage.getItem(CART_KEY) || '[]');

  // check duplicates
  cart.push(product);

  localStorage.setItem(CART_KEY, JSON.stringify(cart));
}

function removeFromCart(productId) {
  const cart = JSON.parse(localStorage.getItem(CART_KEY) || '[]');
  const updatedCart = cart.filter((product) => product.id !== productId);

  localStorage.setItem(CART_KEY, JSON.stringify(updatedCart));
}

const Context = createContext();

export function useShoppingCart() {
  return useContext(Context);
}

export function StorageContext({ children }) {
  const [cart, setCart] = useState(getCart());

  const add = (product) => {
    addToCart(product);
    setCart(getCart());
  };

  const remove = (productId) => {
    removeFromCart(productId);
    setCart(getCart());
  };

  useEffect(() => {
    const handler = () => setCart(getCart());
    window.addEventListener('storage', handler);
    return () => window.removeEventListener('storage', handler);
  }, []);

  return (
    <Context.Provider
      value={{
        cart,
        addToCart: add,
        removeFromCart: remove,
      }}
    >
      {children}
    </Context.Provider>
  );
}
