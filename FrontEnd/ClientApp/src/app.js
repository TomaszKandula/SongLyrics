import React, { Component } from "react";
import { Header } from "./components/layouts/header";
import { Footer } from "./components/layouts/footer";
import Layout from "./components/layout";
import MessageBox from "./components/modals/messageBox";
import SongBox from "./components/modals/songBox";

export default class App extends Component
{

    render()
    {
        return (
            <div>
                <Header />
                <div>
                    <MessageBox />
                    <SongBox />
                </div>
                <Layout />
                <Footer />
            </div>
        );

    }

}
