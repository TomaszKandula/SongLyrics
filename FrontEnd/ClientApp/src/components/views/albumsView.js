import React, { Component } from "react";
import { BandDetails } from "../common/bandDetails";

export class AlbumsView extends Component
{

    render()
    {

        return (
            <div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">

                            <div className="col s8">
                                <BandDetails />
                            </div>

                        </div>

                        <div className="row margin-t-15"></div>

                        <div className="row">

                            <div className="col s8">

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
