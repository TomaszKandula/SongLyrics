export const GetData = (endpoint, callback) =>
{
    fetch(endpoint)
    .then(response =>
    {
        const responseData = response;
        const jsonResponse = response.json();
        jsonResponse
        .then(data =>
        {
            if (responseData.status >= 200 && responseData.status < 400)
            {
                callback(data, null);
            }
            else if (responseData.status >= 400)
            {
                callback(null, data.ErrorDesc);
            }
        })
        .catch(error => 
        {
            callback(null, `Error occurred during processing the request: ${error}.`);
        });       
    });
}
