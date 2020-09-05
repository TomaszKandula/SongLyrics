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

                    <div className="col s9">

                        <div className="row">

                            <div className="col s8">

                                <div className="row" id="topbarsearch">
                                    <div className="input-field col s6 s12 black-text">
                                        <i className="grey-text material-icons prefix">search</i>
                                        <input type="text" placeholder="Search for band" id="autocomplete-input" class="autocomplete black-text" />
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div className="row">

                            <table className="bandsTable">

                                <col className="bandsTableCol1" />
                                <col className="bandsTableCol2" />

                                <thead>
                                    <tr>
                                        <th>Lp</th>
                                        <th>Band Name</th>
                                    </tr>
                                </thead>

                                <tbody>
                                    <tr>
                                        <td>1</td>
                                        <td>Queen</td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td>Led Zeppelin</td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td>Metallica</td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>

                    </div>

                    <div className="col s2">
                        &nbsp;
                    </div>

                </div>

             </div>

        );

    }

}
