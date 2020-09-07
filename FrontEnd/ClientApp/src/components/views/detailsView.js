import React, { Component } from "react";
import { BandDetails } from "../common/bandDetails";
import { AlbumsTable } from "../tables/albumsTable";
import { SongsTable } from "../tables/songsTable";

export class DetailsView extends Component
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
                                <SongsTable />
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
