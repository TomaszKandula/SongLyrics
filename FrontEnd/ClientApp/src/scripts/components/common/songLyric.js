import React, { Component } from "react";
import ReactHtmlParser from 'react-html-parser';
import { connect } from "react-redux";
import { GetData } from "../../ajax/simpleRest";
import * as Api from "../../ajax/apiUrls";
import * as Posed from "../common/posedComponents";

class SongLyric extends Component
{

    constructor(props)
    {
        super(props);
        this.dispatch = this.props.dispatch.bind(this);
        this.songData = this.updateSong.bind(this);
        this.state =
        {
            song: { },
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
            song: payload.Song,
            loading: false
        });

        return true;

    }

    render()
    {

        return (
            <Posed.FadeInDiv initialPose="hidden" pose="visible">

                <div className="row margin-t-10"></div>

                <div className="card hoverable">

                    <div className="card-content gray-text darken-4">
                        <span className="card-title">{this.state.song.Name} from album "{this.state.song.AlbumName}"</span>
                        <div className="row margin-t-10"></div>
                        {ReactHtmlParser(this.state.song.Lyrics)}
                    </div>

                </div>

            </Posed.FadeInDiv>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(SongLyric)
