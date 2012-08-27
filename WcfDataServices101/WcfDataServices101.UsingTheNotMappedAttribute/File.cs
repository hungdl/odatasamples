using System.Collections.Generic;

namespace WcfDataServices101.UsingTheNotMappedAttribute
{
    public class File
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public ICollection<AccessControlEntry> AccessControlList { get; set; }
    }
}