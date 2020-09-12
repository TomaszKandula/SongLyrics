import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as ActionTypes from "../../redux/actionTypes";

class SongsTable extends Component
{

    constructor(props)
    {
        super(props);
        this.state =
        {
            songs: [],
            loading: true
        };
    }

    componentDidMount()
    {
        if (this.props.state.album.id > 0)
            this.getSongs(this.props.state.album.id);
    }

    async getSongs(albumId)
    {

        const response = await fetch(`http://localhost:59384/api/v1/songs/?albumid=${albumId}`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.setState(
                {
                    songs: parsedJson.Songs,
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

    rowClickEvent(songId)
    {
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: songId });
    }

    renderTable(data)
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
                    {data.map(songs =>
                        <tr key={songs.Id} onClick={() => this.rowClickEvent(songs.Id)}>
                            <td className="songsTableCol1">{songs.Id}</td>
                            <td className="songsTableCol2">{songs.Name}</td>
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

        let populatedTable = this.state.loading ? this.renderLoading() : this.renderTable(this.state.songs);

        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {populatedTable}
            </Posed.FadeInDiv>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongsTable)
