import React, { Component } from "react";
import { Header } from "./components/layouts/header";
import { Footer } from "./components/layouts/footer";
import Layout from "./components/layout";
import MessageBox from "./components/common/messageBox";

export default class App extends Component
{

    render()
    {
        return (
            <div>
                <Header />
                <MessageBox />
                <Layout />
                <Footer />
            </div>
        );

    }

}
