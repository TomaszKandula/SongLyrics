using Serilog;

namespace SongLyrics.Logger
{
    public sealed class AppLogger : IAppLogger
    {
        public void LogDebug(string AMessage) => Log.Debug("{AMessage}", AMessage);

        public void LogInfo(string AMessage) => Log.Information("{AMessage}", AMessage);

        public void LogWarn(string AMessage) => Log.Warning("{AMessage}", AMessage);

        public void LogError(string AMessage) => Log.Error("{AMessage}", AMessage);

        public void LogFatality(string AMessage) => Log.Fatal("{AMessage}", AMessage);
    }
}
