import React, { Component } from "react";

export default class BandDetails extends Component
{

    render()
    {

        let details = this.props.details;
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

}
