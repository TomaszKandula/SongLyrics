import { TOGGLE_MESSAGE } from "../actionTypes";

export const toggleMessage =
{

    type: TOGGLE_MESSAGE,
    payload:
    {
        messageType: "",
        lastText: "",
        isVisible: false
    }

};
