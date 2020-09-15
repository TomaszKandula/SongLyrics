import React, { Component } from "react";
import { connect } from "react-redux";
import * as Api from "../../ajax/apiUrls";
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";
import * as Loaders from "../common/preLoaders";
import BandDetails from "../common/bandDetails";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";
import { GetData } from "../../ajax/simpleRest";

class DetailsView extends Component
{

    constructor(props)
    {
        super(props);
        this.SelectBands = this.clickSelectBands.bind(this);
        this.SelectAlbums = this.clickSelectAlbums.bind(this);
        this.SelectSongs = this.clickSelectSongs.bind(this);
        this.dispatch = this.props.dispatch.bind(this);
        this.update = this.updateData.bind(this);
        this.state =
        {
            details:
            {
                name:        "",
                established: "",
                activeUntil: "",
                genere:      "",
                members:     []
            },
            loading: true
        };
    }

    componentDidMount()
    {
        if (this.props.bandId > 0)
            GetData(`${Api.Bands}/${this.props.bandId}/details/`, this.update, this.dispatch);
    }

    updateData(payload)
    {

        if (!payload) return false;

        this.setState(
        {
            details:
            {
                name:        payload.Name,
                established: payload.Established,
                activeUntil: payload.ActiveUntil,
                genere:      payload.Genere,
                members:     payload.Members,
            },
            loading: false
        });

        return true;

    }      

    clickSelectBands()  { this.props.dispatch({ type: ActionTypes.SELECT_BAND, payload: 0 });  }
    clickSelectAlbums() { this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: 0 }); }
    clickSelectSongs()  { this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: 0 });  }

    renderLinks()
    {

        if (!this.props.isAlbumSelected)
        {
            return (
                <div className="col s12">
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectBands}>Bands</a>
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                </div>
            );
        }
        else
        {
            return (
                <div className="col s12">
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectBands}>Bands</a>
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectSongs}>Songs</a>
                </div>
            );
        }

    }

    render()
    {

        let populatedDetails = this.state.loading ? <Loaders.Circular /> : <BandDetails details={this.state.details} />

        return (
            <div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <Posed.ScaleDiv initialPose="hidden" pose="visible" className="col s8">
                                {populatedDetails}
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
    return { isAlbumSelected: isAlbumSelected, bandId: state.band.id }
}

export default connect(mapStateToProps)(DetailsView)
