import React, { Component } from "react";
import { Route } from "react-router";
import { Header } from "./components/header";
import { Footer } from "./components/footer";
import { Container } from "./components/container";

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
                <Container />
                <Footer />
            </div>
        );

    }

}
