import React, { Component } from "react";
import { BandDetails } from "../common/bandDetails";

export class SongsView extends Component
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

                                <table className="songsTable">
                                    <thead>
                                        <tr>
                                            <th className="songsTableCol1">Lp</th>
                                            <th className="songsTableCol2">Song Name</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td className="songsTableCol1">1</td>
                                            <td className="songsTableCol2">Keep Yourself Alive</td>
                                        </tr>
                                        <tr>
                                            <td className="songsTableCol1">2</td>
                                            <td className="songsTableCol2">Doing All Right</td>
                                        </tr>
                                        <tr>
                                            <td className="songsTableCol1">3</td>
                                            <td className="songsTableCol2">Great King Rat</td>
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
