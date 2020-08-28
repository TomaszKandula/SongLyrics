import React, { Component } from 'react';

export class Header extends Component
{

    static displayName = Header.name;

    render() {
        return (
            <nav>
                <div class="nav-wrapper grey lighten-5">
                    <a href="../" class="brand-logo center grey-text darken-4">Song Lyrics</a>
                </div>
            </nav>
        );
    }
}
