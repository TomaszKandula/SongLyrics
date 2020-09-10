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
        this.props.dispatch({ type: ActionTypes.SELECT_SONG, payload: 0 });
        document.body.classList.remove("modal-open");
    }

    renderSongBox()
    {

        let data = this.mockData();
        document.body.classList.add("modal-open");

        return (
            
            <Posed.FadeDiv initialPose="exit" pose="enter">

                <div className="song-modal">

                    <div className="song-modal-content">
                        {ReactHtmlParser(data.Lyrics)}
                        <div className="song-modal-footer">
                            ...
                        </div>
                    </div>

                </div>

            </Posed.FadeDiv>
            
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
