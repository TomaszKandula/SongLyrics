import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Posed from "../common/posedComponents";
import * as Const from "../../shared/constants";
import { GetData } from "../../shared/simpleFetch";
import Modal from "../modals/defaultModal";

class AlbumsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.update = this.updateData.bind(this);
        this.state = { albums: [], loading: true, fetchError: null };
    }

    componentDidMount()
    {
        if (this.props.state.artist.id > 0)
            GetData(`${Const.Albums}/?artistid=${this.props.state.artist.id}`, this.update);
    }

    updateData(payload, error)
    {
        return !error
            ? this.setState({ albums: payload.Albums, loading: false, fetchError: null })
            : this.setState({ songs: [], loading: true, fetchError: error });
    }      

    returnFullYear(date)
    {

        const getDate = new Date(date);

        return date != null
            ? getDate.getFullYear()
            : null;

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
                        <th className="albumsTableCol4">Album cover</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.albums.map(albums =>
                        <tr key={albums.Id} onClick={() => this.clickRowSelect(albums.Id)}>
                            <td className="albumsTableCol1">{albums.Id}</td>
                            <td className="albumsTableCol2">{albums.AlbumName}</td>
                            <td className="albumsTableCol3">{this.returnFullYear(albums.Issued)}</td>
                            <td className="albumsTableCol4"></td>
                        </tr>
                    )}
                </tbody>
            </table>            
        );

    }

    render()
    {

        const showError = this.state.fetchError
            ? <Modal messageText={this.state.fetchError} messageType={Const.MESSAGE_ERROR} isOpened={true} />
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
export default connect(mapStateToProps)(AlbumsTable)
