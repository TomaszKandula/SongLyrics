import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
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
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {populatedTable}
            </Posed.FadeInDiv>
        );

    }

}

export default connect()(SongsTable)
