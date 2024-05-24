import React, { useEffect, useState } from 'react';
import axios from 'axios';

function ItemTable() {
    const [item, setItem] = useState([]);
    const [allItem, setAllItem] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
          try {
            const response = await axios.get('https://localhost:7053/api/items/66420e99000165ce4146b799');
            console.log(response.data);
            setItem(response.data);
          } catch (error) {
            console.error('Error fetching data:', error);
          }
        };
    
        fetchData();
      }, []); // Empty dependency array ensures this effect runs once after initial render

    return (
        <div>
            <p>ID: {item.id}</p>
            <p>name: {item.name}</p>
            <p>price: {item.price}</p>
            <p>category: {item.category}</p>
            <p>damage: {item.damage}</p>
        </div>
    );
}

export default ItemTable;