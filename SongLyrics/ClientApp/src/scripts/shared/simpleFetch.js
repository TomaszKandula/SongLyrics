export const GetData = (endpoint, callback) =>
{
    const onSuccess = (data) =>
    {
        if (data.IsSucceeded)
        {
            callback(data, null);
        }
        else
        {
            callback(null, data.Error.ErrorDesc);
            console.warn(`${data.Error.ErrorDesc}`);
        }
    }

    const onError = (error) =>
    {
        callback(null, error);
        console.error(`${error}`);
    }

    fetch(endpoint)
    .then(response =>
    {
        if (!response.ok)
        {
            throw new Error("Error occurred during processing the request.");
        }          
        return response.json();
    })
    .then(data => 
    { 
        onSuccess(data);
    })
    .catch((error) => 
    {
        onError(error) 
    });
}
