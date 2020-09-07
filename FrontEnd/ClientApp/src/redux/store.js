import { createStore, combineReducers } from "redux";
import selectBandReducer from "./reducers/selectBandReducer";
import selectAlbumReducer from "./reducers/selectAlbumReducer";
import selectSongReducer from "./reducers/selectSongReducer";

const reducer = combineReducers(
{
    band:  selectBandReducer,
    album: selectAlbumReducer,
    song:  selectSongReducer
});

const initialState =
{

    band:
    {
        id: 0
    },

    album:
    {
        id: 0
    },

    song:
    {
        id: 0
    }

};

const store = createStore(reducer, initialState, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

export default store;
