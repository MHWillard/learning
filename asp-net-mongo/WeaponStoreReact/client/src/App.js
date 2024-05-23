import logo from './logo.svg';
import './App.css';

import React, { useEffect } from 'react';
import axios from 'axios';

function App() {

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('https://localhost:7053/api/items/66420e99000165ce4146b799');
        console.log(response.data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, []); // Empty dependency array ensures this effect runs once after initial render

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
