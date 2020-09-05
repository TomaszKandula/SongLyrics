import React, { Component } from "react";
import { BandsView } from "./views/bandsView";
import { AlbumsView } from "./views/albumsView";
import { SongsView } from "./views/songsView";

import "../styles/main.scss";

export class Layout extends Component
{

    render()
    {

        return (
            <div class="container">
                <BandsView />
            </div>
        );

    }

}
