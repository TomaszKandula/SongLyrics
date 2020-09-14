import React, { Component } from "react";
import { connect } from "react-redux";
import ReactHtmlParser from 'react-html-parser';
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";
import * as Loaders from "../common/preLoaders";
import * as Api from "../../ajax/apiUrls";

class SongBox extends Component
{

    constructor(props)
    {
        super(props);
        this.isLoaded = false;
        this.allowLoader = true;
        this.state = { song: {}, shortenLyrics: "", showShorten: true };
    }

    componentDidUpdate()
    {
        if (this.props.songId > 0 && !this.isLoaded)
            this.getSong(this.props.songId);
    }

    async getSong(songId)
    {

        this.allowLoader = true;
        const response = await fetch(`${Api.Songs}/${songId}/`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.isLoaded = true;
                this.setState({ song: parsedJson.Song, shortenLyrics: parsedJson.Song.Lyrics.substring(0, 330) + "..." });
            }
            else
            {
                console.warn(`${parsedJson.Error.ErrorDesc}`);
            }

        }
        catch (message)
        {
            console.error(`An error has occured during the processing: ${message}`);
        }

    }

    onClickEvent()
    {
        this.isLoaded = false;
        this.allowLoader = false;
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: -1 });
    }

    onClickEventShowMore()
    {
        return this.state.showShorten ? this.setState({ showShorten: false }) : this.setState({ showShorten: true });
    }

    modalContent()
    {

        let frame = `<iframe src="${this.state.song.Url}" frameborder="0" allowfullscreen></iframe>`;
        let video = this.allowLoader ? ReactHtmlParser(frame) : null;

        let lyrics = this.state.showShorten ? this.state.shortenLyrics : this.state.song.Lyrics; 
        let content = this.isLoaded ? ReactHtmlParser(lyrics) : this.allowLoader ? <Loaders.Circular /> : ReactHtmlParser(lyrics);

        return (
            <div className="song-modal">

                <div className="song-modal-holder">
                    <div className="song-modal-header">
                        <h6><strong>{this.state.song.Name}</strong></h6>
                        <div className="close-button" onClick={this.onClickEvent.bind(this)}></div>
                    </div>
                    <div className="song-modal-content">

                        <div className="content-box-header">

                            <div className="video-container">
                                {video}
                            </div>

                        </div>

                        <div className="content-box-content">
                            {content}
                        </div>

                        <div className="content-box-footer">

                            <div className="center-align">
                                <i className="material-icons more-horiz" onClick={this.onClickEventShowMore.bind(this)}>more_horiz</i>
                            </div>

                        </div>

                    </div>
                    <div className="song-modal-footer">
                        Provided by Song Lyrics.
                    </div>
                </div>

            </div>
        );
    }

    renderIn()
    {

        document.body.classList.add("songBox-open");

        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {this.modalContent()}
            </Posed.FadeInDiv>
        );

    }

    renderOut()
    {

        let isModalOpened = document.body.classList.contains("songBox-open");

        if (isModalOpened)
        {

            document.body.classList.remove("songBox-open");

            return (
                <Posed.FadeOutDiv initialPose="visible" pose="hidden">
                    {this.modalContent()}
                </Posed.FadeOutDiv>
            );

        }
        else
        {
            return null;
        }

    }

    render()
    {

        let content = this.props.isShown ? this.renderIn() : this.renderOut();

        return (
            <div>
                {content}
            </div>
        );

    }

}

const mapStateToProps = (state) =>
{
    let isVisible = state.song.id > 0 ? true : false;
    return { isShown: isVisible, songId: state.song.id }
}

export default connect(mapStateToProps)(SongBox)
