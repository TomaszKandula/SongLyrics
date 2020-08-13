using System.Security.Cryptography.X509Certificates;

namespace BackEnd.Helpers
{

    /// <summary>
    /// This class is responsible only for providing constants to all classes/methods etc. accross the application.
    /// It can be a partial class if necessary; and if so, then put the module in the root folder and additional 
    /// partials in other project folders.
    public class Constants
    {

        public static class Errors
        { 
            
            internal class EmptyBandList 
            {
                public const string ErrorCode = "empty_band_list";
                public const string ErrorDesc = "There are no bands listed.";
            }

            internal class EmptyMembersList
            {
                public const string ErrorCode = "empty_members_list";
                public const string ErrorDesc = "The given band has no members listed.";
            }






        }

    }

}
