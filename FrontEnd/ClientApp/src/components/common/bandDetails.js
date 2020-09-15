import React, { Component } from "react";

export default class BandDetails extends Component
{

    render()
    {

        let PastMembers    = "";
        let CurrentMembers = "";

        for (let Index = 0; Index < this.props.details.members.length; ++Index)
        {

            if (this.props.details.members[Index].Status === "Active")
            {
                CurrentMembers = CurrentMembers + ` ${this.props.details.members[Index].FirstName} ${this.props.details.members[Index].LastName},`;
            }
            else
            {
                PastMembers = PastMembers + ` ${this.props.details.members[Index].FirstName} ${this.props.details.members[Index].LastName},`;
            }

        }

        CurrentMembers = CurrentMembers.replace(/.$/, ".");
        PastMembers    = PastMembers.replace(/.$/, ".");

        let getEstablished = new Date(this.props.details.established);
        let getActiveUntil = new Date(this.props.details.activeUntil);

        let Established = this.props.details.established != null ? getEstablished.getFullYear() : null;
        let ActiveUntil = this.props.details.activeUntil != null ? getActiveUntil.getFullYear() : null;

        return (
            <table className="detailsTable">
                <tbody>
                    <tr>
                        <td colSpan="2">
                            <h3><b>{this.props.details.name}</b></h3>
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
                        <td className="detailsTableCol2">{this.props.details.genere}</td>
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

}
