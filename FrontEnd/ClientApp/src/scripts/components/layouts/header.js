import React, { Component } from "react";

export class Header extends Component
{

    render()
    {

        return (
            <nav className="nav-extended grey lighten-5">

                <div className="container">

                    <div className="nav-wrapper grey lighten-5">

                        <a href="../" className="brand-logo right grey-text darken-4">Song Lyrics</a>

                        <ul class="left hide-on-med-and-down">
                            <li><a href="#!"><i class="material-icons grey-text">menu</i></a></li>
                        </ul>

                    </div>

                </div>

            </nav>
        );

    }

}
