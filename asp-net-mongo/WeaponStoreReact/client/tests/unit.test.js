const axios = require('axios');

async function getItem(id) {
    try {
        const response = await axios.get(`/api/items/${id}`);
        console.log(response);
        return response;
    } catch (error) {
        console.log(error);
        return [];
    }
}

    describe('API call', () => {
        it('successfully fetches API data', async () => {
            const fetchData = async () => {
                const response = await getItem("66420e99000165ce4146b799");
                return response.data;
            };

            const checkData = [
                {
                    //"id": "66420e99000165ce4146b799",
                    "name": "Short Sword",
                    "price": 5,
                    "category": "Slashing",
                    "damage": "1d6"
                }
            ]


            // Call the function and assert the response
            await expect(fetchData()).resolves.toEqual(checkData);

            // Assert that Axios.get was called with the correct URL
            expect(axios.get).toHaveBeenCalledWith('https://localhost:7053/api/items/66420e99000165ce4146b799');
        });
    });