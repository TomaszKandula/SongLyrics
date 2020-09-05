import React, { Component } from "react";

export class Header extends Component
{

    render()
    {

        return (
            <nav className="grey lighten-5">
                <div className="container">
                    <div className="nav-wrapper grey lighten-5">
                        <a href="../" className="brand-logo grey-text darken-4">Song Lyrics</a>
                    </div>
                </div>
            </nav>
        );

    }

}
