import { useState, useEffect } from "react";

const BASE_URL = "http://localhost:5171/api";

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
        const response = await fetch(`${BASE_URL}${url}`);
        if (!response.ok) {
          throw new Error(`HTTP error: ${response.status}`);
        }
        const jsonData = await response.json();
        setData(jsonData);
        setLoading(false);
      } catch (err) {
        setError(err.message);
        setLoading(false);
      }
    };

    fetchData();
  }, [url]); // Runs only when the URL changes

  return { data, loading, error };
}
