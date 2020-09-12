import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as ActionTypes from "../../redux/actionTypes";

class AlbumsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            albums: [],
            loading: true
        };
    }

    componentDidMount()
    {
        if (this.props.state.band.id > 0)
            this.getAlbums(this.props.state.band.id);
    }

    async getAlbums(bandId)
    {

        const response = await fetch(`http://localhost:59384/api/v1/albums/?bandid=${bandId}`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.setState(
                {
                    albums:  parsedJson.Albums,
                    loading: false
                });

            }
            else
            {
                console.error(`An error has occured during the processing: ${parsedJson.Error.ErrorDesc}`);
            }

        }
        catch (message)
        {
            console.error(`An error has occured during the processing: ${message}`);
        }

    }

    returnFullYear(date)
    {
        let getDate = new Date(date);
        return date != null ? getDate.getFullYear() : null;       
    }

    rowClickEvent(albumId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_ALBUM, payload: albumId });
    }

    renderTable(data)
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
                    {data.map(albums =>
                        <tr key={albums.Id} onClick={() => this.rowClickEvent(albums.Id)}>
                            <td className="albumsTableCol1">{albums.Id}</td>
                            <td className="albumsTableCol2">{albums.AlbumName}</td>
                            <td className="albumsTableCol3">{this.returnFullYear(albums.Issued)}</td>
                        </tr>
                    )}
                </tbody>
            </table>
            
        );

    }

    renderLoading()
    {

        return (

            <div className="preloader-wrapper small active">
                <div className="spinner-layer spinner-green-only">
                    <div className="circle-clipper left">
                        <div className="circle"></div>
                    </div>
                    <div className="gap-patch">
                        <div className="circle"></div>
                    </div>
                    <div className="circle-clipper right">
                        <div className="circle"></div>
                    </div>
                </div>
            </div>
        );

    }

    render()
    {

        let populatedTable = this.state.loading ? this.renderLoading() : this.renderTable(this.state.albums);

        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {populatedTable}
            </Posed.FadeInDiv>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(AlbumsTable)
