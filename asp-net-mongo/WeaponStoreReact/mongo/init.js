// mongo-init.js
db = db.getSiblingDB('ItemsData');

// Create a collection
db.createCollection('items');

// Insert sample items
db.items.insertMany([
    {name: 'Sword', category: 'Slashing', damage: '1d8', price: '10'},
    {name: 'Greataxe', category: 'Slashing', damage: '1d10', price: '13'},
    {name: 'Spear', category: 'Piercing', damage: '1d8', price: '10'},
    {name: 'Mace', category: 'Bashing', damage: '1d6', price: '7'}
]);