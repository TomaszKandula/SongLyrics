import React, { Component } from "react";

export class BandsView extends Component
{

    render()
    {

        return (

            <div>

                <div class="row">

                    <div class="col s2">
                        &nbsp;
                    </div>

                    <div class="col s9">

                        <div class="row">

                            <div class="col s8">

                                <div class="row" id="topbarsearch">
                                    <div class="input-field col s6 s12 black-text">
                                        <i class="grey-text material-icons prefix">search</i>
                                        <input type="text" placeholder="Search for band" id="autocomplete-input" class="autocomplete black-text" />
                                    </div>
                                </div>

                            </div>

                        </div>

                        <div class="row">

                            <table class="highlight">
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

                    <div class="col s2">
                        &nbsp;
                    </div>

                </div>

             </div>

        );

    }

}
