import React, { Component } from 'react';
import { Route } from 'react-router';
import { Header } from './components/header';
import { Footer } from './components/footer';

export default class App extends Component
{

    static displayName = App.name;

    render()
    {
        return (
            <div>
            <Header />
            <div>
                <p>
                    Main container
                </p>
                <p>
                    Line 1
                </p>
                <p>
                    Line 2
                </p>
                <p>
                    Line 3
                </p>
                <p>
                    Line 4
                </p>
                <p>
                    Line 5
                </p>
            </div>
            <Footer />
            </div>
        );

    }

}
