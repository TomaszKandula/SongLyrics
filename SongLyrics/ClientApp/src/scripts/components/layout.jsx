import React, { Component } from "react";
import { connect } from 'react-redux';
import ArtistsView from "./views/artistsView";
import DetailsView from "./views/detailsView";
import "../../styles/main.scss";

class Layout extends Component
{
    render()
    {
        return (
            <div className="container">
                {this.props.isArtistSelected ? <DetailsView /> : <ArtistsView /> }
            </div>
        );
    }
}

const mapStateToProps = (state) =>
{
    const isArtistSelected = state.artist.id !== 0
        ? true
        : false;
    return { isArtistSelected }
}

export default connect(mapStateToProps)(Layout);
