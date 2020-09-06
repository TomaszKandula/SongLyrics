import React, { Component } from "react";
import { Route } from "react-router";
import { BandsView } from "./views/bandsView";
import { DetailsView } from "./views/detailsView";

import "../styles/main.scss";

export class Layout extends Component
{

    render()
    {

        return (

            <div className="container">
                <Route exact path='/' component={BandsView} />
                <Route path='/details/' component={DetailsView} />
            </div>

        );

    }

}
