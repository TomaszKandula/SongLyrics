import React, { Component } from "react";

export class Header extends Component
{
    render()
    {
        return (
            <nav className="nav-extended deep-purple lighten-1">
                <div className="container">
                    <div className="nav-wrapper deep-purple lighten-1">
                        <a href="../" className="brand-logo right deep-purple-text text-lighten-5">Song Lyrics</a>
                        <ul className="left hide-on-med-and-down">
                            <li><a href="#!"><i className="material-icons">menu</i></a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}
