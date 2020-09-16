import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as Links from "../../constants/linkTypes";

class NavigationLinks extends Component
{

    constructor(props)
    {
        super(props);
        this.SelectBands  = this.clickSelectBands.bind(this);
        this.SelectAlbums = this.clickSelectAlbums.bind(this);
        this.SelectSongs  = this.clickSelectSongs.bind(this);
    }

    clickSelectBands()  { this.props.dispatch({ type: ActionTypes.SELECT_BAND,  payload: 0 }); }
    clickSelectAlbums() { this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: 0 }); }
    clickSelectSongs()  { this.props.dispatch({ type: ActionTypes.SELECT_SONG,  payload: 0 }); }

    render()
    {

        switch (this.props.selection)
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

}

export default connect()(NavigationLinks)
