export default class RestClient
{

    constructor(ACustomToken, AContentType)
    {
        this.LCustomToken = ACustomToken;
        this.LContentType = AContentType;
    }

    Execute(AMethod, AUrl, APayLoad, ACallback)
    {

        let LRequest = new XMLHttpRequest();
        try
        {

            LRequest.open(AMethod, AUrl, true);
            LRequest.setRequestHeader("Content-Type", this.LContentType);
            LRequest.setRequestHeader("X-CSRF-TOKEN", this.LCustomToken);

            LRequest.onload = function ()
            {

                if (this.status >= 200 && this.status < 400)
                {
                    ACallback(this.response, this.status);
                }
                else
                {
                    ACallback(null, this.status);
                }

            };

            LRequest.onerror = function ()
            {
                ACallback(null, this.status);
            };

            let LMethod = AMethod.toUpperCase();

            if (LMethod === "GET" || LMethod === "DELETE")
            {
                LRequest.send();
            }

            if (LMethod === "PUT" || LMethod === "POST" || LMethod === "PATCH")
            {
                LRequest.send(APayLoad);
            }

        }
        catch (Error)
        {
            alert(`An error occured during execution: ${Error.message}`);
            console.error(`[RestClient].[Execute]: An error has been thrown: ${Error.message}`);
        }

    }

}
