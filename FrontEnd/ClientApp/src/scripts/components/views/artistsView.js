import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Api from "../../ajax/apiUrls";
import { GetData } from "../../ajax/simpleRest";

class ArtistsView extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.update = this.updateData.bind(this);
        this.state = { artists: [], loading: true };
    }

    componentDidMount()
    {
        GetData(`${Api.Artists}`, this.update, this.dispatch);
    }

    updateData(payload)
    {
        return payload ? this.setState({ artists: payload.Artists, loading: false }) : this.setState({ artists: [], loading: false });
    }      

    clickRowSelect(bandId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_ARTIST, payload: bandId });
    }

    renderTable()
    {

        return (
            <table className="bandsTable">
                <thead>
                    <tr>
                        <th className="bandsTableCol1">Lp</th>
                        <th className="bandsTableCol2">Artist Name</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.artists.map(artists =>
                        <tr key={artists.Id} onClick={() => this.clickRowSelect(artists.Id)}>
                            <td className="bandsTableCol1">{artists.Id}</td>
                            <td className="bandsTableCol2">{artists.Name}</td>
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

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <div className="col s12">

                                <Posed.FadeInDiv initialPose="hidden" pose="visible">
                                    <nav className="hoverable">
                                        <div className="nav-wrapper white">
                                            <div className="input-field">
                                                <input id="search" type="search" placeholder="Search for artist" className="autocomplete black-text" />
                                                <label className="label-icon" htmlFor="search">
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

                    <div className="col s1">
                        &nbsp;
                    </div>

                </div>

                <div className="row margin-t-50"></div>

             </div>
        );

    }

}

export default connect()(ArtistsView)
