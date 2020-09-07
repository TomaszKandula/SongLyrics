import { SELECT_BAND } from "../actions/selectBand";

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
