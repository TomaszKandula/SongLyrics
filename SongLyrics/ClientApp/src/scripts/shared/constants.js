const API_VERSION = 1;
const BASE_URI = "https://songlyrics.azurewebsites.net";

/* EXPOSED ENDPOINTS */

export const Artists = `${BASE_URI}/api/v${API_VERSION}/artists`;
export const Albums  = `${BASE_URI}/api/v${API_VERSION}/albums`;
export const Songs   = `${BASE_URI}/api/v${API_VERSION}/songs`;

/* LINK TYPES */

export const ALBUMS_LIST = "ALBUMS_LIST";
export const SONGS_LIST  = "SONGS_LIST";
export const SONG_LYRIC  = "SONG_LYRIC";

/* MESSAGE TYPES */

export const MESSAGE_INFO  = "MESSAGE_INFO";
export const MESSAGE_WARN  = "MESSAGE_WARN";
export const MESSAGE_ERROR = "MESSAGE_ERROR";
