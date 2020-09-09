import React, { Component } from "react";
import { connect } from "react-redux";
import { BandDetails } from "../common/bandDetails";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";

class DetailsView extends Component
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
                                { this.props.isAlbumSelected ? <SongsTable /> : <AlbumsTable /> }
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

const mapStateToProps = (state) =>
{

    let isAlbumSelected = false;

    if (state.album.id !== 0)
    {
        isAlbumSelected = true;
    }

    return { isAlbumSelected }

}

export default connect(mapStateToProps)(DetailsView)
