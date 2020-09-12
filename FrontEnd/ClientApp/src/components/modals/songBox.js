import React, { Component } from "react";
import { connect } from "react-redux";
import ReactHtmlParser from 'react-html-parser';
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";
import * as Api from "../../ajax/apiUrls";

class SongBox extends Component
{

    constructor(props)
    {
        super(props);
        this.isLoaded = false;
        this.state = { song: { } };
    }

    componentDidUpdate()
    {
        if (this.props.songId > 0 && !this.isLoaded)
            this.getSong(this.props.songId);
    }

    async getSong(songId)
    {

        const response = await fetch(`${Api.Songs}/${songId}/`, { mode: "cors" });
        const parsedJson = await response.json();

        try
        {

            if (parsedJson.IsSucceeded)
            {
                this.isLoaded = true;
                this.setState({ song: parsedJson.Song });
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

    onClickEvent()
    {
        this.isLoaded = false;
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: -1 });
    }

    shouldRenderOut()
    {
        return document.body.classList.contains("songBox-open");
    }

    renderIn()
    {

        document.body.classList.add("songBox-open");
        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {this.modalContent(this.state.song)}
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
                    {this.modalContent(this.state.song)}
                </Posed.FadeOutDiv>
            );

        }
        else
        {
            return null;
        }

    }

    modalContent(data)
    {
        return (
            <div className="song-modal">

                <div className="song-modal-holder">
                    <div className="song-modal-header">
                        <h6>{data.Name}</h6>
                        <div className="close-button" onClick={this.onClickEvent.bind(this)}></div>
                    </div>
                    <div className="song-modal-content">
                        {ReactHtmlParser(data.Lyrics)}
                    </div>
                    <div className="song-modal-footer">
                        ...
                    </div>
                </div>

            </div>
        );
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
