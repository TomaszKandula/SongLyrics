import * as MessageTypes from "../constants/messageTypes";
import * as ActionTypes from "../redux/actionTypes";

export const GetData = (endpoint, callback, dispatch) =>
{

    const onSuccess = (data) =>
    {

        if (data.IsSucceeded)
        {
            callback(data);
        }
        else
        {

            callback(null);

            dispatch(
            {
                type: ActionTypes.TOGGLE_MESSAGE,
                payload:
                {
                    messageType: MessageTypes.MESSAGE_WARN,
                    lastText: data.Error.ErrorDesc,
                    isVisible: true
                }
            });

            console.warn(`${data.Error.ErrorDesc}`);

        }

    }

    const onError = (error) =>
    {

        dispatch(
        {
            type: ActionTypes.TOGGLE_MESSAGE,
            payload:
            {
                messageType: MessageTypes.MESSAGE_WARN,
                lastText: error,
                isVisible: true
            }
        });

        console.error(`${error}`);

    }

    fetch(endpoint)
        .then(response =>
        {
            if (!response.ok) throw new Error("Network response was non-ok.");
            return response.json();
        })
        .then(data => onSuccess(data))
        .catch((error) => onError(error));

}
