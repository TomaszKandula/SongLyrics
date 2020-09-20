import React, { Component } from "react";
import ReactHtmlParser from 'react-html-parser';
import { connect } from "react-redux";
import { GetData } from "../../ajax/simpleRest";
import * as Api from "../../ajax/apiUrls";
import * as Posed from "../common/posedComponents";
import * as MessageTypes from "../../constants/messageTypes";
import Modal from "../modals/defaultModal";

class SongLyric extends Component
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
            GetData(`${Api.Songs}/${this.props.state.song.id}/`, this.songData);
    }

    updateSong(payload, error)
    {
        return !error ? this.setState({ song: payload.Song, loading: false, fetchError: null })
            : this.setState({ song: {}, loading: true, fetchError: error });
    }

    render()
    {

        let showError = this.state.fetchError ? <Modal messageText={this.state.fetchError} messageType={MessageTypes.MESSAGE_ERROR} isOpened={true} /> : null;

        return (
            <>
                {showError}
                <Posed.FadeInDiv initialPose="hidden" pose="visible">
                    <div className="card margin-t-30 hoverable">
                        <div className="card-content gray-text darken-4">
                            <span className="card-title">{this.state.song.Name} from album "{this.state.song.AlbumName}"</span>
                            <div className="margin-t-30 margin-b-30">
                                {ReactHtmlParser(this.state.song.Lyrics)}
                            </div>
                        </div>
                    </div>
                </Posed.FadeInDiv>
            </>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongLyric)
