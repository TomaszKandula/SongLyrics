import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/layout";
import { Header } from "./components/layouts/header";
import { Footer } from "./components/layouts/footer";

export default class App extends Component
{

    bindDom()
    {

    }

    addEvents()
    {

    }

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
