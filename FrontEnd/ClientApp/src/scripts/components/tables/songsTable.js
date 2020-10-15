import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as MessageTypes from "../../constants/messageTypes";
import * as Loaders from "../common/preLoaders";
import * as Posed from "../common/posedComponents";
import * as Api from "../../ajax/apiUrls";
import { GetData } from "../../ajax/simpleRest";
import Modal from "../modals/defaultModal";

class SongsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.update = this.updateData.bind(this);
        this.state = { songs: [], loading: true, fetchError: null };
    }

    componentDidMount()
    {
        if (this.props.state.album.id > 0)
            GetData(`${Api.Songs}/?albumid=${this.props.state.album.id}`, this.update);
    }

    updateData(payload, error)
    {
        return !error
            ? this.setState({ songs: payload.Songs, loading: false, fetchError: null })
            : this.setState({ songs: [], loading: true, fetchError: error });
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

        const showError = this.state.fetchError
            ? <Modal messageText={this.state.fetchError} messageType={MessageTypes.MESSAGE_ERROR} isOpened={true} />
            : null;

        const renderedTable = this.state.loading
            ? <Loaders.Circular />
            : this.renderTable();

        return (
            <>
                {showError}
                <Posed.FadeInDiv initialPose="hidden" pose="visible">
                    <div className="card-panel margin-t-30 white hoverable">
                        {renderedTable}
                    </div>
                </Posed.FadeInDiv>
            </>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongsTable)
