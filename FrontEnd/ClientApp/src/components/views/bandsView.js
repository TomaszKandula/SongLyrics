import React, { Component } from "react";

export class BandsView extends Component
{

    render()
    {

        return (

            <div>

                <div className="row">

                    <div className="col s2">
                        &nbsp;
                    </div>

                    <div className="col s8">

                        <div className="row">

                            <div className="col s8">

                                <div className="row" id="topbarsearch">
                                    <div className="input-field col s6 s12 black-text">
                                        <i className="grey-text material-icons prefix">search</i>
                                        <input type="text" placeholder="Search for band" id="autocomplete-input" className="autocomplete black-text" />
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div className="row">

                            <div className="col s8">

                                <table className="bandsTable">
                                    <thead>
                                        <tr>
                                            <th className="bandsTableCol1">Lp</th>
                                            <th className="bandsTableCol2">Band Name</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td className="bandsTableCol1">1</td>
                                            <td className="bandsTableCol2">Queen</td>
                                        </tr>
                                        <tr>
                                            <td className="bandsTableCol1">2</td>
                                            <td className="bandsTableCol2">Led Zeppelin</td>
                                        </tr>
                                        <tr>
                                            <td className="bandsTableCol1">3</td>
                                            <td className="bandsTableCol2">Metallica</td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>

                        </div>

                    </div>

                    <div className="col s2">
                        &nbsp;
                    </div>

                </div>

                <div className="row customBtmMargin"></div>

             </div>

        );

    }

}
