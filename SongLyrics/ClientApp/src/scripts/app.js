import React, { Component } from "react";
import { Header } from "./components/layouts/header";
import { Footer } from "./components/layouts/footer";
import Layout from "./components/layout";

export default class App extends Component
{

    render()
    {
        return (
            <div>
                <Header/>
                <Layout />
                <Footer />
            </div>
        );
    }

}
