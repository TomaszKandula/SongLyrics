import { SELECT_ARTIST } from "../actionTypes";

const selectArtistReducer = (state = {}, { type, payload }) =>
{

    switch (type)
    {

        case SELECT_ARTIST:
            return { id: payload }

        default:
            return state

    };

};

export default selectArtistReducer;
