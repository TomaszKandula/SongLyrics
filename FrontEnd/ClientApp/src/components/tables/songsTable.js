import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as mockPayLoads from "../../tempMocks/mockPayLoads";

class SongsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            songs: [],
            loading: true
        };
    }

    componentDidMount()
    {
        this.mockData();
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

    mockData()
    {

        let jsonResponse = mockPayLoads.songs;
        let parsedJson = JSON.parse(jsonResponse);
        let objSongs = parsedJson.Songs;

        this.setState(
            {
                songs: objSongs,
                loading: false
            });

    }

    rowClickEvent(songId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: songId });
    }

    renderTable(data)
    {

        return (
            
            <table className="songsTable">
                <thead>
                    <tr>
                        <th className="songsTableCol1">Lp</th>
                        <th className="songsTableCol2">Song Name</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(songs =>
                        <tr key={songs.Id} onClick={() => this.rowClickEvent(songs.Id)}>
                            <td className="songsTableCol1">{songs.Id}</td>
                            <td className="songsTableCol2">{songs.Name}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            
        );

    }

    render()
    {

        let populatedTable = this.state.loading ? <p><em>Loading..., please wait.</em></p> : this.renderTable(this.state.songs);

        return (
            <div className="margin-t-5">
                <nav className="z-depth-0 nav-box grey lighten-5">
                    <div className="grey lighten-5">
                        <div className="col s12">
                            <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickBands.bind(this)}>Bands</a>
                            <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickAlbums.bind(this)}>Albums</a>
                            <a href="#" className="breadcrumb grey-text darken-4" onClick={this.onClickSongs.bind(this)}>Songs</a>
                        </div>
                    </div>
                </nav>
                <div className="margin-b-30"></div>
                {populatedTable}
            </div>
        );

    }

}

export default connect()(SongsTable)
