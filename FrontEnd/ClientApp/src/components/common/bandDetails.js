import React, { Component } from "react";

export class BandDetails extends Component
{

    render()
    {

        return (
            <div>

                <table className="detailsTable">

                    <tbody>
                        <tr>
                            <td colSpan="2">
                                <h3><b>Queen</b></h3>
                            </td>
                        </tr>
                        <tr>
                            <td className="detailsTableCol1">Established</td>
                            <td className="detailsTableCol2">1970</td>
                        </tr>
                        <tr>
                            <td className="detailsTableCol1">Active until</td>
                            <td className="detailsTableCol2">-</td>
                        </tr>
                        <tr>
                            <td className="detailsTableCol1">Genere</td>
                            <td className="detailsTableCol2">Rock</td>
                        </tr>
                        <tr>
                            <td colSpan="2">Members</td>
                        </tr>
                        <tr>
                            <td className="detailsTableCol1">Current</td>
                            <td className="detailsTableCol2">Brian May, Roger Taylor, Adam Lambert (guest singer)</td>
                        </tr>
                        <tr>
                            <td className="detailsTableCol1">Past</td>
                            <td className="detailsTableCol2">Freddie Mercury, John Deacon</td>
                        </tr>

                    </tbody>

                </table>

            </div>
        );

    }

}
