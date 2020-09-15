import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as MessageTypes from "../../constants/messageTypes";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Api from "../../ajax/apiUrls";

class AlbumsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.allowLoader = true;
        this.state = { albums: [], loading: true };
    }

    componentDidMount()
    {
        if (this.props.state.band.id > 0)
            this.getAlbums(this.props.state.band.id);
    }

    async getAlbums(bandId)
    {

        const response = await fetch(`${Api.Albums}/?bandid=${bandId}`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.allowLoader = true;
                this.setState( { albums:  parsedJson.Albums, loading: false });
            }
            else
            {
                this.allowLoader = false;
                this.setState({ albums: [], loading: false });
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

    returnFullYear(date)
    {
        let getDate = new Date(date);
        return date != null ? getDate.getFullYear() : null;       
    }

    clickRowSelect(albumId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: albumId });
    }

    renderTable()
    {

        return (
            <table className="albumsTable">
                <thead>
                    <tr>
                        <th className="albumsTableCol1">Lp</th>
                        <th className="albumsTableCol2">Album Name</th>
                        <th className="albumsTableCol3">Issued</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.albums.map(albums =>
                        <tr key={albums.Id} onClick={() => this.clickRowSelect(albums.Id)}>
                            <td className="albumsTableCol1">{albums.Id}</td>
                            <td className="albumsTableCol2">{albums.AlbumName}</td>
                            <td className="albumsTableCol3">{this.returnFullYear(albums.Issued)}</td>
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
export default connect(mapStateToProps)(AlbumsTable)
