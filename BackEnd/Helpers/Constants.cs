namespace BackEnd.Helpers
{

    /// <summary>
    /// This class is responsible only for providing constants to all classes/methods etc. accross the application.
    /// It can be a partial class if necessary; and if so, then put the module in the root folder and additional 
    /// partials in other project folders.
    /// </summary>
    public class Constants
    {

        public static class Errors
        { 
            
            internal class EmptyBandList 
            {
                public const string ErrorCode = "empty_band_list";
                public const string ErrorDesc = "There are no bands on the list.";
            }

            internal class EmptyMembersList
            {
                public const string ErrorCode = "empty_members_list";
                public const string ErrorDesc = "The given band has no members listed.";
            }

            internal class EmptyAlbumList
            {
                public const string ErrorCode = "empty_album_list";
                public const string ErrorDesc = "The are no albums on the list.";
            }

            internal class NoAlbumFound
            {
                public const string ErrorCode = "no_album_found";
                public const string ErrorDesc = "There is no album for given Album Id.";
            }

            internal class EmptyBandAlbumsList
            {
                public const string ErrorCode = "empty_band_albums_list";
                public const string ErrorDesc = "The given band have no albums listed.";
            }

            internal class EmptySongList 
            {
                public const string ErrorCode = "empty_song_list";
                public const string ErrorDesc = "The are no songs on the list.";
            }

            internal class NoSongFound
            {
                public const string ErrorCode = "no_song_found";
                public const string ErrorDesc = "The is no song for given Song Id.";
            }

            internal class EmptyAlbumSongsList
            {
                public const string ErrorCode = "empty_album_songs_list";
                public const string ErrorDesc = "There are no songs listed for given Album Id.";
            }

        }

    }

}
