import { TOGGLE_MESSAGE } from "../actionTypes";

const toggleMessageReducer = (state = {}, { type, payload }) => {

    switch (type) {

        case TOGGLE_MESSAGE:
            return Object.assign({}, state, { messageType: payload.messageType, lastText: payload.lastText, isVisible: payload.isVisible })

        default:
            return state

    };

};

export default toggleMessageReducer;
