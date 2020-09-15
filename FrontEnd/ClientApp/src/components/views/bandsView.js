import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Api from "../../ajax/apiUrls";
import { GetData } from "../../ajax/simpleRest";

class BandsView extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.update = this.updateData.bind(this);
        this.allowLoader = true;
        this.state = { bands: [], loading: true };
    }

    componentDidMount()
    {
        GetData(`${Api.Bands}`, this.update, this.dispatch);
    }

    updateData(payload)
    {

        if (payload)
        {
            this.allowLoader = true;
            this.setState({ bands: payload.Bands, loading: false });
        }
        else
        {
            this.allowLoader = false;
            this.setState({ bands: [], loading: false });
        }

    }      

    clickRowSelect(bandId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_BAND, payload: bandId });
    }

    renderTable()
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
                    {this.state.bands.map(bands =>
                        <tr key={bands.Id} onClick={() => this.clickRowSelect(bands.Id)}>
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

        let populatedTable = this.state.loading ? this.allowLoader ? <Loaders.Circular /> : null : this.renderTable();

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
