
namespace StdfFileSummaryCreator
{
    internal class Level
    {
        internal byte code;
        internal string ShortName;
        internal string FullName;
        internal Dictionary<byte, Level> subLevels = new Dictionary<byte, Level>();

#nullable enable
        internal Level(byte _code, string _shortName, string? _fullName = null)
        {
            code = _code;
            ShortName = _shortName;
            if (_fullName != null)
                FullName = _fullName;
            else
                FullName = _shortName;
        }
#nullable disable
    }
}
