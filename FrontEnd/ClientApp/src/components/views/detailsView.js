import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as ActionTypes from "../../redux/actionTypes";
import { BandDetails } from "../common/bandDetails";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";

class DetailsView extends Component
{

    constructor(props)
    {
        super(props);
        this.BandDetails = this.renderOnCreate();
    }

    onClickBands()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_BAND, payload: 0 });
    }

    onClickAlbums()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: 0 });
    }

    onClickSongs()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: 0 });
    }

    renderLinks()
    {

        if (!this.props.isAlbumSelected)
        {
            return (
                <div className="col s12">
                    <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickBands.bind(this)}>Bands</a>
                    <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickAlbums.bind(this)}>Albums</a>
                </div>
            );
        }
        else
        {
            return (
                <div className="col s12">
                    <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickBands.bind(this)}>Bands</a>
                    <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickAlbums.bind(this)}>Albums</a>
                    <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickSongs.bind(this)}>Songs</a>
                </div>
            );
        }

    }

    renderOnCreate()
    {

        return (
            <div>
                <BandDetails />
            </div>
        );

    }

    render()
    {

        return (
            <div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <Posed.ScaleDiv initialPose="hidden" pose="visible" className="col s8">
                                {this.BandDetails}
                            </Posed.ScaleDiv>
                        </div>

                        <div className="row">
                            <div className="col s8">

                                <div className="row margin-t-15"></div>

                                <nav className="z-depth-0 nav-box grey lighten-5">
                                    <div className="grey lighten-5">
                                        <div className="col s12">
                                            {this.renderLinks()}
                                        </div>
                                    </div>
                                </nav>

                                <div className="row margin-t-15"></div>

                                {this.props.isAlbumSelected ? <SongsTable /> : <AlbumsTable />}

                            </div>
                        </div>

                    </div>

                    <div className="col s1">
                        &nbsp;
                    </div>

                </div>

                <div className="row margin-t-50"></div>

            </div>
        );

    }

}

const mapStateToProps = (state) =>
{
    let isAlbumSelected = state.album.id !== 0 ? true : false;
    return { isAlbumSelected }
}

export default connect(mapStateToProps)(DetailsView)
