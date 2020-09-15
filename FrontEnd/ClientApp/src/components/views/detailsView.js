import React, { Component } from "react";
import { connect } from "react-redux";
import * as Api from "../../ajax/apiUrls";
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";
import * as Loaders from "../common/preLoaders";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";

class DetailsView extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            details:
            {
                name:        "",
                established: "",
                activeUntil: "",
                genere:      "",
                members:     []
            },
            loading: true
        };
    }

    componentDidMount()
    {
        if (this.props.bandId > 0)
            this.getDetails(this.props.bandId);
    }

    async getDetails(bandId)
    {

        const response = await fetch(`${Api.Bands}/${bandId}/details/`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.setState(
                {
                    details:
                    {
                        name:        parsedJson.Name,
                        established: parsedJson.Established,
                        activeUntil: parsedJson.ActiveUntil,
                        genere:      parsedJson.Genere,
                        members:     parsedJson.Members,
                    },
                    loading: false
                });

            }
            else
            {
                console.warn(`${parsedJson.Error.ErrorDesc}`);
            }

        }
        catch (message)
        {
            console.error(`An error has occured during the processing: ${message}`);
        }

    }

    clickSelectBands()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_BAND, payload: 0 });
    }

    clickSelectAlbums()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: 0 });
    }

    clickSelectSongs()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: 0 });
    }

    renderLinks()
    {

        if (!this.props.isAlbumSelected)
        {
            return (
                <div className="col s12">
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.clickSelectBands.bind(this)}>Bands</a>
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.clickSelectAlbums.bind(this)}>Albums</a>
                </div>
            );
        }
        else
        {
            return (
                <div className="col s12">
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.clickSelectBands.bind(this)}>Bands</a>
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.clickSelectAlbums.bind(this)}>Albums</a>
                    <a href="#!" className="breadcrumb grey-text darken-4" onClick={this.clickSelectSongs.bind(this)}>Songs</a>
                </div>
            );
        }

    }

    renderDetails()
    {

        let PastMembers    = "";
        let CurrentMembers = "";

        for (let Index = 0; Index < this.state.details.members.length; ++Index)
        {

            if (this.state.details.members[Index].Status === "Active")
            {
                CurrentMembers = CurrentMembers + ` ${this.state.details.members[Index].FirstName} ${this.state.details.members[Index].LastName},`;
            }
            else
            {
                PastMembers = PastMembers + ` ${this.state.details.members[Index].FirstName} ${this.state.details.members[Index].LastName},`;
            }

        }

        CurrentMembers = CurrentMembers.replace(/.$/, ".");
        PastMembers    = PastMembers.replace(/.$/, ".");

        let getEstablished = new Date(this.state.details.established);
        let getActiveUntil = new Date(this.state.details.activeUntil);

        let Established = this.state.details.established != null ? getEstablished.getFullYear() : null;
        let ActiveUntil = this.state.details.activeUntil != null ? getActiveUntil.getFullYear() : null;

        return (
            <table className="detailsTable">
                <tbody>
                    <tr>
                        <td colSpan="2">
                            <h3><b>{this.state.details.name}</b></h3>
                        </td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Established</td>
                        <td className="detailsTableCol2">{Established}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Active until</td>
                        <td className="detailsTableCol2">{ActiveUntil}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Genere</td>
                        <td className="detailsTableCol2">{this.state.details.genere}</td>
                    </tr>
                    <tr>
                        <td colSpan="2">Members</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Current</td>
                        <td className="detailsTableCol2">{CurrentMembers}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Past</td>
                        <td className="detailsTableCol2">{PastMembers}</td>
                    </tr>

                </tbody>
            </table>
        );

    }

    render()
    {

        let populatedDetails = this.state.loading ? <Loaders.Circular /> : this.renderDetails();

        return (
            <div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <Posed.ScaleDiv initialPose="hidden" pose="visible" className="col s8">
                                {populatedDetails}
                            </Posed.ScaleDiv>
                        </div>

                        <div className="row">
                            <div className="col s8">

                                <div className="row margin-t-15"></div>

                                <nav className="z-depth-0 nav-box grey lighten-5">
                                    <div className="grey lighten-5">
                                        <div className="col s12">
                                            {this.renderLinks()}
                                        </div>
                                    </div>
                                </nav>

                                <div className="row margin-t-15"></div>

                                {this.props.isAlbumSelected ? <SongsTable /> : <AlbumsTable />}

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
    let isAlbumSelected = state.album.id !== 0 ? true : false;
    return { isAlbumSelected: isAlbumSelected, bandId: state.band.id }
}

export default connect(mapStateToProps)(DetailsView)
