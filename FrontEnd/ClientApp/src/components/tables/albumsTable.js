import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Api from "../../ajax/apiUrls";
import { GetData } from "../../ajax/simpleRest";

class AlbumsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.update = this.updateData.bind(this);
        this.state = { albums: [], loading: true };
    }

    componentDidMount()
    {
        if (this.props.state.band.id > 0)
            GetData(`${Api.Albums}/?bandid=${this.props.state.band.id}`, this.update, this.dispatch);
    }

    updateData(payload)
    {
        return payload ? this.setState({ albums: payload.Albums, loading: false }) : this.setState({ songs: [], loading: true });
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

        let renderedTable = this.state.loading ? <Loaders.Circular /> : this.renderTable();

        return (
            <div>
                {renderedTable}
            </div>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(AlbumsTable)
