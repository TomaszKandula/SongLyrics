import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Posed from "../common/posedComponents";
import * as Api from "../../ajax/apiUrls";
import { GetData } from "../../ajax/simpleRest";

class SongsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.update = this.updateData.bind(this);
        this.state = { songs: [], loading: true };
    }

    componentDidMount()
    {
        if (this.props.state.album.id > 0)
            GetData(`${Api.Songs}/?albumid=${this.props.state.album.id}`, this.update, this.dispatch);
    }

    updateData(payload)
    {
        return payload ? this.setState({ songs: payload.Songs, loading: false }) : this.setState({ songs: [], loading: true });
    }
    
    clickRowSelect(songId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: songId });
    }

    renderTable()
    {

        return (            
            <table className="songsTable">
                <thead>
                    <tr>
                        <th className="songsTableCol1">Lp</th>
                        <th className="songsTableCol2">Song Name</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.songs.map(songs =>
                        <tr key={songs.Id} onClick={() => this.clickRowSelect(songs.Id)}>
                            <td className="songsTableCol1">{songs.Id}</td>
                            <td className="songsTableCol2">{songs.Name}</td>
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
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                <div className="card-panel margin-t-30 white hoverable">
                    {renderedTable}
                </div>
            </Posed.FadeInDiv>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongsTable)
