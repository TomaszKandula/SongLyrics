import React, { Component } from "react";

export class SongsTable extends Component
{

    render()
    {

        return (
            <div>

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
        );

    }

}
