import React, { Component } from "react";
import { Layout } from "./components/layout";
import { Header } from "./components/layouts/header";
import { Footer } from "./components/layouts/footer";

export default class App extends Component
{

    render()
    {
        return (
            <div>
                <Header />
                <Layout />
                <Footer />
            </div>
        );

    }

}
