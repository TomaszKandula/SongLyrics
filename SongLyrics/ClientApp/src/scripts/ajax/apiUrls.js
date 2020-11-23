// Base URL
const BASE_URI = "http://localhost:5000";

// Current API version (we use only integer for versioning)
const apiVersion = "v1";

// Exposed endpoints
export const Artists = `${BASE_URI}/api/${apiVersion}/artists`;
export const Albums  = `${BASE_URI}/api/${apiVersion}/albums`;
export const Songs   = `${BASE_URI}/api/${apiVersion}/songs`;
