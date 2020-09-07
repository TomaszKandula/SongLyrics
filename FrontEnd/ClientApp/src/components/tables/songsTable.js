import React, { Component } from "react";
import * as mockPayLoads from "../../tempMocks/mockPayLoads"; 

export class SongsTable extends Component
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
        //this.getSongs();
        //this.mockData();
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
        // display lyrics for "songId" in modal window
        console.log(songId);
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
            <div className="">
                {populatedTable}
            </div>
        );

    }

}
