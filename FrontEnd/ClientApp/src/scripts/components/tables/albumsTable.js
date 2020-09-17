import React, { Component } from "react";
import { connect } from "react-redux";
import * as ActionTypes from "../../redux/actionTypes";
import * as Loaders from "../common/preLoaders";
import * as Posed from "../common/posedComponents";
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
        if (this.props.state.artist.id > 0)
            GetData(`${Api.Albums}/?bandid=${this.props.state.artist.id}`, this.update, this.dispatch);
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
export default connect(mapStateToProps)(AlbumsTable)
