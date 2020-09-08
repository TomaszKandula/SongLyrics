import { SELECT_BAND } from "../actionTypes";

const selectBandReducer = (state = {}, { type, payload }) =>
{

    switch (type)
    {

        case SELECT_BAND:
            return { id: payload }

        default:
            return state

    };

};

export default selectBandReducer;
