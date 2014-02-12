using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WcfDataServices101.UsingTheNotMappedAttribute
{
    public class AccessControlEntry
    {
        public int Id { get; set; }

        // An Enum property cannot be mapped to an OData feed, so it must be
        // explicitly excluded with the [NotMapped] attribute.
        [NotMapped]
        public FileRights FileRights { get; set; }

        // This property provides a means to serialize the value of the FileRights
        // property in an OData-compatible way.
        public string Rights
        {
            get { return FileRights.ToString(); }
            set { FileRights = (FileRights)Enum.Parse(typeof(FileRights), value); }
        }
    }
}