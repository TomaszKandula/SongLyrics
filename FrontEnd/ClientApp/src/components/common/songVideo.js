import React, { Component } from "react";
import ReactHtmlParser from 'react-html-parser';
import { connect } from "react-redux";
import { GetData } from "../../ajax/simpleRest";
import * as Api from "../../ajax/apiUrls";

class SongVideo extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.songData = this.updateSong.bind(this);
        this.state =
        {
            songUrl: "",
            loading: true
        };
    }

    componentDidMount()
    {
        if (this.props.state.song.id > 0)
            GetData(`${Api.Songs}/${this.props.state.song.id}/`, this.songData, this.dispatch);
    }

    updateSong(payload)
    {

        if (!payload) return false;

        this.setState(
        {
            songUrl: payload.Song.Url,
            loading: false
        });

        return true;

    }

    render()
    {

        return (
            <div>
                <div className="row margin-t-15"></div>
                <div className="video-container">
                    {ReactHtmlParser(`<iframe src="${this.state.songUrl}" frameborder="0"></iframe>`)}
                </div>
            </div>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongVideo)
