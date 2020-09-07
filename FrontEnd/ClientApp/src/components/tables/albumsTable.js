import React, { Component } from "react";
import * as mockPayLoads from "../../tempMocks/mockPayLoads"; 

export class AlbumsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            albums: [],
            loading: true
        };
    }

    componentDidMount()
    {
        //this.getAlbums();
        this.mockData();
    }

    mockData()
    {

        let jsonResponse = mockPayLoads.albums;
        let parsedJson = JSON.parse(jsonResponse);
        let objAlbums = parsedJson.Albums;

        this.setState(
            {
                albums: objAlbums,
                loading: false
            });

    }

    returnFullYear(date)
    {

        let getDate = new Date(date);
        let fullYear = null;

        if (date != null)
        {
            fullYear = getDate.getFullYear();
        }

        return fullYear;
        
    }

    rowClickEvent(albumId)
    {
        // render songsTable with "albumId"
        console.log(albumId);
    }

    renderTable(data)
    {

        return (

            <table className="albumsTable">
                <thead>
                    <tr>
                        <th className="albumsTableCol1">Lp</th>
                        <th className="albumsTableCol2">Album Name</th>
                        <th className="albumsTableCol3">Issued</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(albums =>
                        <tr key={albums.Id} onClick={() => this.rowClickEvent(albums.Id)}>
                            <td className="albumsTableCol1">{albums.Id}</td>
                            <td className="albumsTableCol2">{albums.AlbumName}</td>
                            <td className="albumsTableCol3">{this.returnFullYear(albums.Issued)}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            
        );

    }

    render()
    {

        let populatedTable = this.state.loading ? <p><em>Loading..., please wait.</em></p> : this.renderTable(this.state.albums);

        return (
            <div>
                {populatedTable}
            </div>
        );

    }

}