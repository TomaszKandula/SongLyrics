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
        //this.getBands();
        this.mockData();
    }

    mockData()
    {

        let jsonResponse = mockPayLoads.albums;
        let parsedJson = JSON.parse(jsonResponse);
        let objAblums = parsedJson.Albums;

        this.setState(
            {
                albums: objAblums,
                loading: false
            });

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
                        <tr key={albums.Id}>
                            <td className="albumsTableCol1">{albums.Id}</td>
                            <td className="albumsTableCol2">{albums.AlbumName}</td>
                            <td className="albumsTableCol3">{albums.Issued}</td>
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