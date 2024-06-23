import { useEffect, useState } from 'react';

const BASE_URL = 'http://localhost:5171/api';

export function useAuth() {
  useEffect(() => {
    fetch(`${BASE_URL}/account/login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email: 'user@example.com',
        password: 'string',
      }),
    }).then(async (response) => {
      const { token } = await response.json();
      localStorage.setItem('auth_token', token);
    });
  }, []);
}

// Custom hook for fetching data from a URL
export function useFetch(url) {
  const [data, setData] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Reset states on URL change
    setData(null);
    setLoading(true);
    setError(null);

    const fetchData = async () => {
      try {
        const response = await fetch(`${BASE_URL}${url}`, {
          headers: {
            Authorization: `Bearer ${localStorage.getItem('auth_token')}`,
          },
        });

        if (!response.ok) {
          throw new Error(`HTTP error: ${response.status}`);
        }
        const jsonData = await response.json();
        setData(jsonData);
        setLoading(false);
      } catch (err) {
        setError(err);
        setLoading(false);
      }
    };

    fetchData();
  }, [url]); // Runs only when the URL changes

  return { data, loading, error };
}

export function useMakeOrderMutation() {
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const makeOrder = async (storeId, order) => {
    setLoading(true);
    setError(null);

    try {
      const response = await fetch(`${BASE_URL}/store/${storeId}/order`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${localStorage.getItem('auth_token')}`,
        },
        body: JSON.stringify(order),
      });

      if (!response.ok) {
        const errors = await response.json();
        console.log('Order error: ', errors);
        throw new Error(
          errors?.title ? `${errors.title}` : `HTTP error: ${response.status}.`
        );
      }
    } catch (err) {
      setError(err);
      throw err;
    } finally {
      setLoading(false);
    }
  };

  return { makeOrder, loading, error };
}
