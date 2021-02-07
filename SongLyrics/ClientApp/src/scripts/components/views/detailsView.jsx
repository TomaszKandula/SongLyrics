import React, { Component } from "react";
import { connect } from "react-redux";
import { ALBUMS_LIST, SONGS_LIST, SONG_LYRIC } from "../../shared/constants";
import SongLyric from "../common/songLyric";
import SongVideo from "../common/songVideo";
import ArtistDetails from "../common/artistDetails";
import AlbumsTable from "../tables/albumsTable";
import SongsTable from "../tables/songsTable";
import NavigationLinks from "../common/navigationLinks";

class DetailsView extends Component
{
    render()
    {
        let content = null;
        let header = null;
        let navlinks = null;

        if (this.props.state.artist.id > 0 && this.props.state.album.id === 0)
        {
            header = <ArtistDetails />;
            content = <AlbumsTable />;
            navlinks = <NavigationLinks selection={ALBUMS_LIST} />;
        }

        if (this.props.state.album.id > 0 && this.props.state.song.id === 0)
        {
            header = <ArtistDetails />; 
            content = <SongsTable />;
            navlinks = <NavigationLinks selection={SONGS_LIST} />;
        }

        if (this.props.state.song.id > 0 && this.props.state.album.id !== 0)
        {
            header = <SongVideo />;
            content = <SongLyric />;
            navlinks = <NavigationLinks selection={SONG_LYRIC} />;
        }

        return (
            <div className="row margin-t-5 margin-b-50">
                <div className="col s1"></div>
                <div className="col s10">
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
                <div className="col s1"></div>
            </div>
        );
    }
}

const mapStateToProps = (state) => { return { state } }
export default connect(mapStateToProps)(DetailsView)
