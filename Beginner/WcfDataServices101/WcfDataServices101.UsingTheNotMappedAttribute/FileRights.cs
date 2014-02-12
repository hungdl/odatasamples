using System;

namespace WcfDataServices101.UsingTheNotMappedAttribute
{
    [Flags]
    public enum FileRights
    {
        Read = 1,
        Write = 2,
        Create = 4,
        Delete = 8
    }
}