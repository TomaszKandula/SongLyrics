import React, { Component } from "react";
import { connect } from "react-redux";
import { GetData } from "../../ajax/simpleRest";
import * as Api from "../../ajax/apiUrls";
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";
import * as Loaders from "../common/preLoaders";
import * as Links from "../../constants/linkTypes";
import BandDetails from "../common/bandDetails";
import SongLyric from "../common/songLyric";
import SongVideo from "../common/songVideo";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";

class DetailsView extends Component
{

    constructor(props)
    {

        super(props);

        this.SelectBands  = this.clickSelectBands.bind(this);
        this.SelectAlbums = this.clickSelectAlbums.bind(this);
        this.SelectSongs  = this.clickSelectSongs.bind(this);
        this.dispatch  = this.props.dispatch.bind(this);
        this.bandData  = this.updateDetails.bind(this);

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
        if (this.props.state.band.id > 0)
            GetData(`${Api.Bands}/${this.props.state.band.id}/details/`, this.bandData, this.dispatch);
    }

    updateDetails(payload)
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

    clickSelectBands()  { this.props.dispatch({ type: ActionTypes.SELECT_BAND,  payload: 0 }); }
    clickSelectAlbums() { this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: 0 }); }
    clickSelectSongs()  { this.props.dispatch({ type: ActionTypes.SELECT_SONG,  payload: 0 }); }

    renderLinks(links)
    {

        switch (links)
        {

            case Links.ALBUMS_LIST:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectBands}>Bands</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                    </div>
                );

            case Links.SONGS_LIST:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectBands}>Bands</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectSongs}>Songs</a>
                    </div>
                );

            case Links.SONG_LYRIC:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectBands}>Bands</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectSongs}>Songs</a>
                        <a href="#!" className="breadcrumb grey-text darken-4">Song</a>
                    </div>
                );

            default:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectBands}>Bands</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                    </div>
                );

        }

    }

    render()
    {

        let data1 = null;
        let data2 = null;
        let data3 = null;

        if (this.props.state.band.id > 0 && this.props.state.album.id === 0)
        {
            data1 = <AlbumsTable />;
            data2 = this.state.loading ? <Loaders.Circular /> : < BandDetails details={this.state.details} /> 
            data3 = this.renderLinks(Links.ALBUMS_LIST);
        }

        if (this.props.state.album.id > 0 && this.props.state.song.id === 0)
        {
            data1 = <SongsTable />;
            data2 = this.state.loading ? <Loaders.Circular /> : <BandDetails details={this.state.details} /> 
            data3 = this.renderLinks(Links.SONGS_LIST);
        }

        if (this.props.state.song.id > 0 && this.props.state.album.id !== 0)
        {
            data1 = <SongLyric />;
            data2 = <SongVideo />;
            data3 = this.renderLinks(Links.SONG_LYRIC);
        }

        return (
            <div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <Posed.ScaleDiv initialPose="hidden" pose="visible" className="col s8">
                                {data2}
                            </Posed.ScaleDiv>
                        </div>

                        <div className="row">
                            <div className="col s8">

                                <div className="row margin-t-15"></div>

                                <nav className="z-depth-0 nav-box grey lighten-5">
                                    <div className="grey lighten-5">
                                        <div className="col s12">
                                            {data3}
                                        </div>
                                    </div>
                                </nav>

                                <div className="row margin-t-15"></div>
                                {data1}
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

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(DetailsView)
