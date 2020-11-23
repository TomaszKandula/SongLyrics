import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import { ALBUMS_LIST, SONGS_LIST, SONG_LYRIC } from "../../shared/constants";

class NavigationLinks extends Component
{

    constructor(props)
    {
        super(props);
        this.SelectArtists = this.clickSelectArtists.bind(this);
        this.SelectAlbums  = this.clickSelectAlbums.bind(this);
        this.SelectSongs   = this.clickSelectSongs.bind(this);
    }

    clickSelectArtists() { this.props.dispatch({ type: ActionTypes.SELECT_ARTIST,payload: 0 }); }
    clickSelectAlbums()  { this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: 0 }); }
    clickSelectSongs()   { this.props.dispatch({ type: ActionTypes.SELECT_SONG,  payload: 0 }); }

    render()
    {

        switch (this.props.selection)
        {

            case ALBUMS_LIST:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectArtists}>Artists</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                    </div>
                );

            case SONGS_LIST:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectArtists}>Artists</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectSongs}>Songs</a>
                    </div>
                );

            case SONG_LYRIC:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectArtists}>Artists</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectSongs}>Songs</a>
                        <a href="#!" className="breadcrumb grey-text darken-4">Song</a>
                    </div>
                );

            default:
                return (
                    <div className="col s12">
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectArtists}>Artists</a>
                        <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.SelectAlbums}>Albums</a>
                    </div>
                );

        }

    }

}

export default connect()(NavigationLinks)
