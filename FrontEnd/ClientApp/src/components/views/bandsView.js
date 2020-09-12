import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as ActionTypes from "../../redux/actionTypes";

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
        this.getBands();
    }

    async getBands()
    {

        const response = await fetch("http://localhost:59384/api/v1/bands/", { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                let objBands = parsedJson.Bands;
                this.setState(
                {
                    bands: objBands,
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

    renderLoading()
    {

        return (

            <div className="preloader-wrapper small active">
                <div className="spinner-layer spinner-green-only">
                    <div className="circle-clipper left">
                        <div className="circle"></div>
                    </div>
                    <div className="gap-patch">
                        <div className="circle"></div>
                    </div>
                    <div className="circle-clipper right">
                        <div className="circle"></div>
                    </div>
                </div>
            </div>
        );

    }

    render()
    {

        let populatedTable = this.state.loading ? this.renderLoading() : this.renderTable(this.state.bands);

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
                                <Posed.FadeInDiv initialPose="hidden" pose="visible" className="row" id="topbarsearch">
                                    <div className="input-field col s6 s12 black-text">
                                        <i className="grey-text material-icons prefix">search</i>
                                        <input type="text" placeholder="Search for band" id="autocomplete-input" className="autocomplete black-text" />
                                    </div>
                                </Posed.FadeInDiv>
                            </div>
                        </div>

                        <div className="row">
                            <Posed.FadeInDiv initialPose="hidden" pose="visible" className="col s8">
                                {populatedTable}
                            </Posed.FadeInDiv>
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
