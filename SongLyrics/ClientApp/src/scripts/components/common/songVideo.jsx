import React, { Component } from "react";
import ReactHtmlParser from 'react-html-parser';
import { connect } from "react-redux";
import { GetData } from "../../shared/simpleFetch";
import * as Const from "../../shared/constants";
import * as Posed from "./posedComponents";
import Modal from "../modals/defaultModal";

class SongVideo extends Component
{

    constructor(props)
    {
        super(props);
        this.songData = this.updateSong.bind(this);
        this.state = { song: {}, loading: true, fetchError: null };
    }

    componentDidMount()
    {
        if (this.props.state.song.id > 0)
            GetData(`${Const.Songs}/${this.props.state.song.id}/`, this.songData);
    }

    updateSong(payload, error)
    {
        return !error
            ? this.setState({ song: payload.Song, loading: false, fetchError: null })
            : this.setState({ song: {}, loading: true, fetchError: error });
    }

    render()
    {

        let showError = this.state.fetchError ? <Modal messageText={this.state.fetchError} messageType={Const.MESSAGE_ERROR} isOpened={true} /> : null;

        return (
            <>
                {showError}
                <div className="margin-t-30 margin-b-5">

                    <Posed.FadeInDiv initialPose="hidden" pose="visible">
                        <h3>
                            <b>{this.state.song.ArtistName}</b>
                        </h3>
                    </Posed.FadeInDiv>

                    <Posed.FadeInDiv initialPose="hidden" pose="visible" className="card margin-t-30 hoverable">

                        <div className="card-image">
                            <div className="video-container">
                                <div>{ReactHtmlParser(`<iframe src="${this.state.song.Url}" frameborder="0"></iframe>`)}</div>
                            </div>
                        </div>

                        <div className="card-content">
                            <div>
                                <span>{this.state.song.Name}</span>
                            </div>
                        </div>

                    </Posed.FadeInDiv>

                </div>
            </>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongVideo)
