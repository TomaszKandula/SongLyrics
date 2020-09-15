import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as MessageTypes from "../../constants/messageTypes";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Api from "../../ajax/apiUrls";

class SongsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.allowLoader = true;
        this.state = { songs: [], loading: true };
    }

    componentDidMount()
    {
        if (this.props.state.album.id > 0)
            this.getSongs(this.props.state.album.id);
    }

    async getSongs(albumId)
    {

        const response = await fetch(`${Api.Songs}/?albumid=${albumId}`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.allowLoader = true;
                this.setState( { songs: parsedJson.Songs, loading: false });
            }
            else
            {
                this.allowLoader = false;
                this.setState( { songs: [], loading: true });
                this.props.dispatch(
                {
                    type: ActionTypes.TOGGLE_MESSAGE,
                    payload:
                    {
                        messageType: MessageTypes.MESSAGE_WARN,
                        lastText: parsedJson.Error.ErrorDesc,
                        isVisible: true
                    }
                });
                console.warn(`${parsedJson.Error.ErrorDesc}`);
            }

        }
        catch (message)
        {
            this.props.dispatch(
            {
                type: ActionTypes.TOGGLE_MESSAGE,
                payload:
                {
                    messageType: MessageTypes.MESSAGE_ERROR,
                    lastText: parsedJson.Error.ErrorDesc,
                    isVisible: true
                }, 
            });
            console.error(`An error has occured during the processing: ${message}`);
        }

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

        let populatedTable = this.state.loading ? this.allowLoader ? <Loaders.Circular /> : null : this.renderTable();

        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {populatedTable}
            </Posed.FadeInDiv>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongsTable)
