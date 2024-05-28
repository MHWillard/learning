import React, { useEffect, useState } from 'react';
import axios from 'axios';

function ItemTable() {
    const [item, setItem] = useState([]);
    const [allItem, setAllItem] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
          try {
            const response = await axios.get('https://localhost:7053/api/Items/allitems/');
            console.log(response.data);
            setAllItem(response.data);
          } catch (error) {
            console.error('Error fetching data:', error);
          }
        };
    
        fetchData();
      }, []); // Empty dependency array ensures this effect runs once after initial render

      const itemTable = allItem.map(item =>
        <div key={item.id}>
          <p>{item.id}</p>
          <p>NAME: {item.name} CATEGORY: {item.category} DAMAGE: {item.damage}</p>
          <p>PRICE: {item.price}</p>
        </div>
      )

    return (
        <div>
            {itemTable}
        </div>
    );
}

export default ItemTable;