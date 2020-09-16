import React, { Component } from "react";
import { connect } from "react-redux";
import { GetData } from "../../ajax/simpleRest";
import * as Api from "../../ajax/apiUrls";
import * as Loaders from "../common/preLoaders";

class BandDetails extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.bandData = this.updateDetails.bind(this);
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
        if (this.props.state.band.id > 0)
            GetData(`${Api.Bands}/${this.props.state.band.id}/details/`, this.bandData, this.dispatch);
    }

    updateDetails(payload)
    {

        if (!payload) return false;

        this.setState(
        {
            details:
            {
                name:        payload.Name,
                established: payload.Established,
                activeUntil: payload.ActiveUntil,
                genere:      payload.Genere,
                members:     payload.Members,
            },
            loading: false        
        });

        return true;

    }      

    renderTable()
    {

        let details = this.state.details;
        let pastMembers = "";
        let currMembers = "";

        for (let Index = 0; Index < details.members.length; ++Index)
        {

            if (details.members[Index].Status === "Active")
            {
                currMembers = currMembers + ` ${details.members[Index].FirstName} ${details.members[Index].LastName},`;
            }
            else
            {
                pastMembers = pastMembers + ` ${details.members[Index].FirstName} ${details.members[Index].LastName},`;
            }

        }

        currMembers = currMembers.replace(/.$/, ".");
        pastMembers = pastMembers.replace(/.$/, ".");

        let getEstablished = new Date(details.established);
        let getActiveUntil = new Date(details.activeUntil);

        let established = details.established != null ? getEstablished.getFullYear() : null;
        let activeUntil = details.activeUntil != null ? getActiveUntil.getFullYear() : null;

        return (
            <table className="detailsTable">
                <tbody>
                    <tr>
                        <td colSpan="2">
                            <h3><b>{details.name}</b></h3>
                        </td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Established</td>
                        <td className="detailsTableCol2">{established}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Active until</td>
                        <td className="detailsTableCol2">{activeUntil}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Genere</td>
                        <td className="detailsTableCol2">{details.genere}</td>
                    </tr>
                    <tr>
                        <td colSpan="2">Members</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Current</td>
                        <td className="detailsTableCol2">{currMembers}</td>
                    </tr>
                    <tr>
                        <td className="detailsTableCol1">Past</td>
                        <td className="detailsTableCol2">{pastMembers}</td>
                    </tr>

                </tbody>
            </table>
        );

    }

    render()
    {

        let renderedTable = this.state.loading ? <Loaders.Circular /> : this.renderTable();

        return (
            <div>
                {renderedTable}
            </div>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(BandDetails)
