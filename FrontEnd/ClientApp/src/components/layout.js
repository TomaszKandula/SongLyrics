import React, { Component } from "react";
import { BandsView } from "./views/bandsView";
import { DetailsView } from "./views/detailsView";

import "../styles/main.scss";

export class Layout extends Component
{

    render()
    {

        return (
            <div className="container">
                <DetailsView/>
            </div>
        );

    }

}
