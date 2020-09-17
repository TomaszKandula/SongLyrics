import React, { Component } from "react";
import { Header } from "./components/layouts/header";
import { Footer } from "./components/layouts/footer";
import Layout from "./components/layout";
import MessageBox from "./components/modals/messageBox";

export default class App extends Component
{

    render()
    {
        return (
            <div className="grey lighten-5">
                <Header />
                <div>
                    <MessageBox />
                </div>
                <Layout />
                <Footer />
            </div>
        );

    }

}
