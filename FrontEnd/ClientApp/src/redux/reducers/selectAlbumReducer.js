import { SELECT_ALBUM } from "../actions/selectAlbum";

const selectAlbumReducer = (state = {}, { type, payload }) =>
{

    switch (type)
    {

        case SELECT_ALBUM:
            return { id: payload }

        default:
            return state

    };

};

export default selectAlbumReducer;
