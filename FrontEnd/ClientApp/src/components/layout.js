import React, { Component } from "react";
import { BandsView } from "./views/bandsView";
import { AlbumsView } from "./views/albumsView";
import { SongsView } from "./views/songsView";

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
