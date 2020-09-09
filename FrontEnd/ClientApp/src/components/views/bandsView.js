import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as mockPayLoads from "../../tempMocks/mockPayLoads"; 

class BandsView extends Component
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
        this.mockData();
    }

    mockData()
    {
        let jsonResponse = mockPayLoads.bands;
        let parsedJson = JSON.parse(jsonResponse);
        let objBands = parsedJson.Bands;
        this.setState(
            {
                bands: objBands,
                loading: false
            });
    }

    rowClickEvent(bandId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_BAND, payload: bandId });
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
                        <tr key={bands.Id} onClick={() => this.rowClickEvent(bands.Id)}>
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

        let populatedTable = this.state.loading ? <p><em>Loading..., please wait.</em></p> : this.renderTable(this.state.bands);

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

export default connect()(BandsView)
