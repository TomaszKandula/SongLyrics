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
        return document.body.classList.contains("songBox-open");
    }

    renderIn(data)
    {
        document.body.classList.add("songBox-open");
        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">
                {this.modalContent(data)}
            </Posed.FadeInDiv>          
        );
    }

    renderOut(data)
    {

        let isModalOpened = document.body.classList.contains("songBox-open");

        if (isModalOpened)
        {

            document.body.classList.remove("songBox-open");

            return (
                <Posed.FadeOutDiv initialPose="visible" pose="hidden">
                    {this.modalContent(data)}
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

        let content = this.props.isShown ? this.renderIn(this.mockData()) : this.renderOut(this.mockData());

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
