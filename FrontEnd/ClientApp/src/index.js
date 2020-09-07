import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";
import store from "./store";
import App from "./app";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter basename={baseUrl}>
            <App />
        </BrowserRouter>
    </Provider>,
    rootElement
);
