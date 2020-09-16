import React, { Component } from "react";
import { connect } from "react-redux";
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
            header   = <BandDetails /> 
            content  = <AlbumsTable />;
            navlinks = <NavigationLinks selection={Links.ALBUMS_LIST} />;
        }

        if (this.props.state.album.id > 0 && this.props.state.song.id === 0)
        {
            header   = <BandDetails /> 
            content  = <SongsTable />;
            navlinks = <NavigationLinks selection={Links.SONGS_LIST} />;
        }

        if (this.props.state.song.id > 0 && this.props.state.album.id !== 0)
        {
            header   = <SongVideo />;
            content  = <SongLyric />;
            navlinks = <NavigationLinks selection={Links.SONG_LYRIC} />;
        }

        return (
            <div>

                <div className="row">

                    <div className="col s2">
                        &nbsp;
                    </div>

                    <div className="col s8">

                        <div className="row">
                            <div className="col s12">
                                {header}
                            </div>
                        </div>

                        <div className="row">
                            <div className="col s12">

                                <nav className="nav-box white hoverable">
                                    <div className="grey lighten-5">
                                        <div className="col s12">
                                            {navlinks}
                                        </div>
                                    </div>
                                </nav>

                                {content}

                            </div>
                        </div>

                    </div>

                    <div className="col s2">
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
