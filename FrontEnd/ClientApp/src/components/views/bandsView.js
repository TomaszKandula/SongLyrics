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
        this.state = { bands: [], loading: true };
    }

    componentDidMount()
    {
        GetData(`${Api.Bands}`, this.update, this.dispatch);
    }

    updateData(payload)
    {
        return payload ? this.setState({ bands: payload.Bands, loading: false }) : this.setState({ bands: [], loading: false });
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

        let renderedTable = this.state.loading ? <Loaders.Circular /> : this.renderTable();

        return (
            <div>

                <div className="row margin-t-30"></div>

                <div className="row">

                    <div className="col s2">
                        &nbsp;
                    </div>

                    <div className="col s8">

                        <div className="row">
                            <div className="col s12">

                                <Posed.FadeInDiv initialPose="hidden" pose="visible">
                                    <nav className="hoverable">
                                        <div className="nav-wrapper white">
                                            <div className="input-field">
                                                <input id="search" type="search" placeholder="Search for artist" className="autocomplete black-text" />
                                                <label className="label-icon" for="search">
                                                    <i className="material-icons grey-text darken-4">search</i>
                                                </label>
                                                <i className="material-icons">close</i>
                                            </div>
                                        </div>
                                    </nav>
                                </Posed.FadeInDiv>

                            </div>
                        </div>

                        <div className="row">

                            <Posed.FadeInDiv initialPose="hidden" pose="visible" className="col s12">

                                <div className="card-panel white hoverable">
                                    {renderedTable}
                                </div>

                            </Posed.FadeInDiv>

                        </div>

                    </div>

                    <div className="col s2">
                        &nbsp;
                    </div>

                </div>

                <div className="row margin-t-50"></div>

             </div>
        );

    }

}

export default connect()(BandsView)
