import { SELECT_SONG } from "../actionTypes";

const selectSongReducer = (state = {}, { type, payload }) =>
{

    switch (type)
    {

        case SELECT_SONG:
            return { id: payload }

        default:
            return state

    };

};

export default selectSongReducer;
