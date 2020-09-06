import React, { Component } from "react";
import * as mockPayLoads from "../../tempMocks/mockPayLoads"; 

export class BandsView extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            bands: [],
            loading: true
        };
    }

    componentDidMount()
    {
        //this.getBands();
        this.mockData();
    }

    async getBands()
    {
        const response = await fetch("https://songlyrics-api.azurewebsites.net/api/v1/bands/");
        const data = await response.json();

        try
        {

            let parsedJson = JSON.parse(data);

            if (parsedJson.IsSucceeded)
            {
                this.setState(
                    {
                        bands: data,
                        loading: false
                    });
            }
            else
            {
                console.error(`An error has occured during the processing: ${parsedJson.Error.ErrorDesc}`);
            }

        }
        catch (message)
        {
            console.error(`An error has occured during the processing: ${message}`);
        }

    }

    mockData()
    {
        let jsonResponse = mockPayLoads.bandsPayLoad;
        let parsedJson = JSON.parse(jsonResponse);
        let objBands = parsedJson.Bands;
        this.setState(
            {
                bands: objBands,
                loading: false
            });
    }

    renderTable(data)
    {

        return (

            <table className="bandsTable">
                <thead>
                    <tr>
                        <th className="bandsTableCol1">Lp</th>
                        <th className="bandsTableCol2">Band Name</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(bands =>  
                        <tr key={bands.Id}>
                            <td className="bandsTableCol1">{bands.Id}</td>
                            <td className="bandsTableCol2">{bands.Name}</td>
                        </tr>                       
                    )}
                </tbody>
            </table>                      

        );

    }

    render()
    {

        let populatedTable = this.state.loading ? <p><em>Loading...</em></p> : this.renderTable(this.state.bands);

        return (

            <div>

                <div className="row margin-t-30"></div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <div className="col s8">
                                <div className="row" id="topbarsearch">
                                    <div className="input-field col s6 s12 black-text">
                                        <i className="grey-text material-icons prefix">search</i>
                                        <input type="text" placeholder="Search for band" id="autocomplete-input" className="autocomplete black-text" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col s8">
                                {populatedTable}
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

