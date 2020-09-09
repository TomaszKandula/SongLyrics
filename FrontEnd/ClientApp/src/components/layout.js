import React, { Component } from "react";
import { connect } from 'react-redux';
import BandsView from "./views/bandsView";
import DetailsView from "./views/detailsView";

import "../styles/main.scss";

class Layout extends Component
{

    render()
    {

        return (

            <div className="container">
                {this.props.isBandSelected ? <DetailsView /> : <BandsView /> }
            </div>

        );

    }

}

const mapStateToProps = (state) =>
{

    let isBandSelected = false;

    if (state.band.id !== 0)
    {
        isBandSelected = true;
    }

    return { isBandSelected }

}

export default connect(mapStateToProps)(Layout);
