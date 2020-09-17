// Base URI
const BASE_URI = "https://songlyrics-api.azurewebsites.net";

// Current API version (we use only integer for versioning)
const apiVersion = "v1";

// Exposed endpoints
export const Artists = `${BASE_URI}/api/${apiVersion}/artists`;
export const Albums  = `${BASE_URI}/api/${apiVersion}/albums`;
export const Songs   = `${BASE_URI}/api/${apiVersion}/songs`;
