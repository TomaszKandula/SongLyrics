import { SHOW_MESSAGE } from "../actionTypes";

const showMessageReducer = (state = {}, { type, payload }) => {

    switch (type) {

        case SHOW_MESSAGE:
            return Object.assign({}, state, { messageType: payload.messageType, lastText: payload.lastText, isVisible: payload.isVisible })

        default:
            return state

    };

};

export default showMessageReducer;
