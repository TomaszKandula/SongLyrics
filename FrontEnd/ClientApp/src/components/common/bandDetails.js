import React, { Component } from "react";
import * as mockPayLoads from "../../tempMocks/mockPayLoads"; 

export class BandDetails extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            name:        "",
            established: "",
            activeUntil: "",
            genere:      "",
            members:     [],
            loading:     true
        };
    }

    componentDidMount()
    {
        //this.getDetails();
        this.mockData();
    }

    mockData()
    {

        let jsonResponse = mockPayLoads.details;
        let parsedJson = JSON.parse(jsonResponse);

        this.setState(
            {
                name:        parsedJson.Name,
                established: parsedJson.Established,
                activeUntil: parsedJson.ActiveUntil,
                genere:      parsedJson.Genere,
                members:     parsedJson.Members,
                loading:     false
            });

    }

    renderTable(data)
    {

        let PastMembers    = "";
        let CurrentMembers = "";

        for (let Index = 0; Index < data.members.length; ++Index)
        {

            if (data.members[Index].Status === "Active")
            {
                CurrentMembers = CurrentMembers + ` ${data.members[Index].FirstName} ${data.members[Index].LastName},`;
            }
            else
            {
                PastMembers = PastMembers + ` ${data.members[Index].FirstName} ${data.members[Index].LastName},`;
            }

        }

        CurrentMembers = CurrentMembers.replace(/.$/, ".");
        PastMembers    = PastMembers.replace(/.$/, ".");

        let getEstablished = new Date(data.established);
        let getActiveUntil = new Date(data.activeUntil);

        let Established = null;
        let ActiveUntil = null;

        if (data.established != null) { Established = getEstablished.getFullYear(); }
        if (data.activeUntil != null) { ActiveUntil = getActiveUntil.getFullYear(); }

        return (
            
            <table className="detailsTable">
                <tbody>
                    <tr>
                        <td colSpan="2">
                            <h3><b>{data.name}</b></h3>
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
                        <td className="detailsTableCol2">{data.genere}</td>
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

        let populatedTable = this.state.loading ? <p><em>Loading..., please wait.</em></p> : this.renderTable(this.state);

        return (
            <div>
                {populatedTable}
            </div>
        );

    }

}
