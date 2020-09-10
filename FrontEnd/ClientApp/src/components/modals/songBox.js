import React, { Component } from "react";
import { connect } from "react-redux";
import ReactHtmlParser from 'react-html-parser';
import * as ActionTypes from "../../redux/actionTypes";
import * as Posed from "../common/posedComponents";
import * as mockPayLoads from "../../tempMocks/mockPayLoads";

class SongBox extends Component
{

    mockData()
    {
        let jsonResponse = mockPayLoads.song;
        let parsedJson = JSON.parse(jsonResponse);
        let objSong = parsedJson.Song;
        return objSong;
    }

    onClickEvent()
    {
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: -1 });
    }

    shouldRenderOut()
    {
        return document.body.classList.contains("modal-open");
    }

    renderIn(data)
    {
        document.body.classList.add("modal-open");
        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {this.modalContent(data)}
            </Posed.FadeInDiv>          
        );
    }

    renderOut(data)
    {
        document.body.classList.remove("modal-open");
        return (
            <Posed.FadeOutDiv initialPose="visible" pose="hidden">
                {this.modalContent(data)}
            </Posed.FadeOutDiv>
        );
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

    renderSongBox()
    {

        let content = this.shouldRenderOut() ? this.renderOut(this.mockData()) : this.renderIn(this.mockData());

        return (
            <div>
                {content}
            </div>         
        );

    }

    render()
    {

        let content = this.props.isShown ? this.renderSongBox() : null;

        return (
            <div>
                {content}
            </div>
        );

    }

}

const mapStateToProps = (state) =>
{
    let isVisible = true;
    if (state.song.id === 0) { isVisible = false; }
    return { isShown: isVisible, songId: state.song.id }
}

export default connect(mapStateToProps)(SongBox)
