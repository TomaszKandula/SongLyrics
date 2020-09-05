import React, { Component } from "react";

export class AlbumsTable extends Component
{

    render()
    {

        return (
            <div>

                <table className="albumsTable">
                    <thead>
                        <tr>
                            <th className="albumsTableCol1">Lp</th>
                            <th className="albumsTableCol2">Album Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td className="albumsTableCol1">1</td>
                            <td className="albumsTableCol2">Queen</td>
                        </tr>
                        <tr>
                            <td className="albumsTableCol1">2</td>
                            <td className="albumsTableCol2">Queen II</td>
                        </tr>
                        <tr>
                            <td className="albumsTableCol1">3</td>
                            <td className="albumsTableCol2">Sheer Heart Attack</td>
                        </tr>
                    </tbody>
                </table>

            </div>
        );

    }

}