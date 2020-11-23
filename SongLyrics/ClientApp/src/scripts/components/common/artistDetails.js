import React, { Component } from "react";
import { connect } from "react-redux";
import { GetData } from "../../ajax/simpleRest";
import * as Api from "../../ajax/apiUrls";
import * as Posed from "./posedComponents";
import * as Loaders from "./preLoaders";
import * as MessageTypes from "../../constants/messageTypes";
import Modal from "../modals/defaultModal";

class ArtistDetails extends Component
{

    constructor(props)
    {
        super(props);
        this.artistData = this.updateDetails.bind(this);
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
            loading: true,
            fetchError: null
        };
    }

    componentDidMount()
    {
        if (this.props.state.artist.id > 0)
            GetData(`${Api.Artists}/${this.props.state.artist.id}/details/`, this.artistData);
    }

    updateDetails(payload, error)
    {
        return !error
            ? this.setState({
                details: { name: payload.Name, established: payload.Established, activeUntil: payload.ActiveUntil, genere: payload.Genere, members: payload.Members },
                loading: false,
                fetchError: null
            })
            : this.setState({
                details: { name: "", established: "", activeUntil: "", genere: "", members: "" },
                loading: true,
                fetchError: error
            });
    }      

    processData()
    {

        if (!this.state.details.members)
        {

            const processed =
            {
                established: "n/a",
                activeUntil: "n/a",
                currMembers: "n/a",
                pastMembers: "n/a"
            };

            return processed;
        }

        let pastMembers = "";
        let currMembers = "";

        for (let Index = 0; Index < this.state.details.members.length; ++Index)
        {

            if (this.state.details.members[Index].Status === "Active")
            {
                currMembers = currMembers
                    + ` ${this.state.details.members[Index].FirstName} ${this.state.details.members[Index].LastName},`;
            }
            else
            {
                pastMembers = pastMembers
                    + ` ${this.state.details.members[Index].FirstName} ${this.state.details.members[Index].LastName},`;
            }

        }

        currMembers = currMembers.replace(/.$/, ".");
        pastMembers = pastMembers.replace(/.$/, ".");

        const getEstablished = new Date(this.state.details.established);
        const getActiveUntil = new Date(this.state.details.activeUntil);

        const established = this.state.details.established != null
            ? getEstablished.getFullYear()
            : null;

        const activeUntil = this.state.details.activeUntil != null
            ? getActiveUntil.getFullYear()
            : null;

        const processed =
        {
            established: established,
            activeUntil: activeUntil,
            currMembers: currMembers,
            pastMembers: pastMembers
        };

        return processed;

    }

    renderTable(processed)
    {

        return (
            <table className="detailsTable">
                <tbody>
                    <tr>
                        <td className="detailsTableCol1">Established</td>
                        <td className="detailsTableCol2">{processed.established}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Active until</td>
                        <td className="detailsTableCol2">{processed.activeUntil}</td>
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
                        <td className="detailsTableCol2">{processed.currMembers}</td>
                    </tr>
                    <tr className="lastTableRow">
                        <td className="detailsTableCol1">Past</td>
                        <td className="detailsTableCol2">{processed.pastMembers}</td>
                    </tr>

                </tbody>
            </table>
        );

    }

    render()
    {

        const showError = this.state.fetchError
            ? <Modal messageText={this.state.fetchError} messageType={MessageTypes.MESSAGE_ERROR} isOpened={true} />
            : null;

        const renderedTable = this.state.loading
            ? <Loaders.Circular />
            : this.renderTable(this.processData());

        const bandName = this.state.loading
            ? null
            : this.state.details.name;

        return (
            <>
                {showError}
                <div className="margin-t-30">

                    <Posed.FadeInDiv initialPose="hidden" pose="visible">
                        <h3>
                            <b>{bandName}</b>
                        </h3>
                    </Posed.FadeInDiv>

                    <Posed.ScaleDiv initialPose="hidden" pose="visible">
                        <div className="card-panel margin-t-30 white hoverable">
                            {renderedTable}
                        </div>
                    </Posed.ScaleDiv>

                </div>
            </>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(ArtistDetails)
