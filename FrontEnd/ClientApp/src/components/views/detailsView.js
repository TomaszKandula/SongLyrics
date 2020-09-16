import React, { Component } from "react";
import { connect } from "react-redux";
import * as Posed from "../common/posedComponents";
import * as Links from "../../constants/linkTypes";
import SongLyric from "../common/songLyric";
import SongVideo from "../common/songVideo";
import BandDetails from "../common/bandDetails";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";
import NavigationLinks from "../common/navigationLinks";

class DetailsView extends Component
{

    render()
    {

        let content  = null;
        let header   = null;
        let navlinks = null;

        if (this.props.state.band.id > 0 && this.props.state.album.id === 0)
        {
            content  = <AlbumsTable />;
            header   = <BandDetails /> 
            navlinks = <NavigationLinks selection={Links.ALBUMS_LIST} />;
        }

        if (this.props.state.album.id > 0 && this.props.state.song.id === 0)
        {
            content  = <SongsTable />;
            header   = <BandDetails /> 
            navlinks = <NavigationLinks selection={Links.SONGS_LIST} />;
        }

        if (this.props.state.song.id > 0 && this.props.state.album.id !== 0)
        {
            content  = <SongLyric />;
            header   = <SongVideo />;
            navlinks = <NavigationLinks selection={Links.SONG_LYRIC} />;
        }

        return (
            <div>

                <div className="row">

                    <div className="col s1">
                        &nbsp;
                    </div>

                    <div className="col s10">

                        <div className="row">
                            <Posed.ScaleDiv initialPose="hidden" pose="visible" className="col s8">
                                {header}
                            </Posed.ScaleDiv>
                        </div>

                        <div className="row">
                            <div className="col s8">

                                <div className="row margin-t-15"></div>

                                <nav className="z-depth-0 nav-box grey lighten-5">
                                    <div className="grey lighten-5">
                                        <div className="col s12">
                                            {navlinks}
                                        </div>
                                    </div>
                                </nav>

                                <div className="row margin-t-15"></div>

                                <Posed.FadeInDiv initialPose="hidden" pose="visible">
                                    {content}
                                </Posed.FadeInDiv>

                            </div>
                        </div>

                    </div>

                    <div className="col s1">
                        &nbsp;
                    </div>

                </div>

                <div className="row margin-t-50"></div>

            </div>
        );

    }

}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(DetailsView)
