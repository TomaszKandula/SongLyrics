const API_VERSION = process.env.REACT_APP_API_VER;
const BACKEND = process.env.REACT_APP_BACKEND;

/* EXPOSED ENDPOINTS */

export const Artists = `${BACKEND}/api/v${API_VERSION}/artists`;
export const Albums = `${BACKEND}/api/v${API_VERSION}/albums`;
export const Songs = `${BACKEND}/api/v${API_VERSION}/songs`;

/* LINK TYPES */

export const ALBUMS_LIST = "ALBUMS_LIST";
export const SONGS_LIST = "SONGS_LIST";
export const SONG_LYRIC = "SONG_LYRIC";

/* MESSAGE TYPES */

export const MESSAGE_INFO = "MESSAGE_INFO";
export const MESSAGE_WARN = "MESSAGE_WARN";
export const MESSAGE_ERROR = "MESSAGE_ERROR";
