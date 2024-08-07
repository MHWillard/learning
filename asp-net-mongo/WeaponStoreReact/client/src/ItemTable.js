import React, { useEffect, useState } from 'react';
import axios from 'axios';

function ItemTable() {
    //const [item, setItem] = useState([]);
    const [allItem, setAllItem] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
          try {
            const response = await axios.get('https://weaponstoreapi.azurewebsites.net/api/allitems/'); //.net backend
            setAllItem(response.data);
          } catch (error) {
            console.error('Error fetching data:', error);
          }
        };
    
        fetchData();
      }, []); // Empty dependency array ensures this effect runs once after initial render

      const itemTable = allItem.map(item =>
        <tr key={item.id}>
          <th>{item.name}</th>
          <th>{item.category}</th> 
          <th>{item.damage}</th>
          <th>{item.price}</th>
        </tr>
      )

    return (
        <div class="container is-max-widescreen">
          <table class="table is-fullwidth">
            <thead>
              <tr>
                <th>Name</th>
                <th>Category</th>
                <th>Damage</th>
                <th>Price</th>
              </tr>
            </thead>
            <tbody>
            {itemTable}
            </tbody>
          </table>
        </div>
    );
}

export default ItemTable;