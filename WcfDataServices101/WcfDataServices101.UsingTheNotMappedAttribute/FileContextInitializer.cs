using System.Collections.Generic;
using System.Data.Entity;

namespace WcfDataServices101.UsingTheNotMappedAttribute
{
    public class FileContextInitializer : DropCreateDatabaseIfModelChanges<FileContext>
    {
        protected override void Seed(FileContext context)
        {
            base.Seed(context);
            context.Files.Add(new File
                              {
                                  Path = @"C:\file1.txt",
                                  AccessControlList = new List<AccessControlEntry>
                                                      {
                                                          new AccessControlEntry
                                                          {
                                                              FileRights =
                                                                  FileRights.Read | FileRights.Create
                                                          },
                                                          new AccessControlEntry
                                                          {
                                                              FileRights = FileRights.Write
                                                          }
                                                      }
                              });
            context.Files.Add(new File
                              {
                                  Path = @"C:\file2.txt",
                                  AccessControlList = new List<AccessControlEntry>
                                                      {
                                                          new AccessControlEntry
                                                          {
                                                              FileRights =
                                                                  FileRights.Delete
                                                          },
                                                          new AccessControlEntry
                                                          {
                                                              FileRights = FileRights.Create | FileRights.Write
                                                          }
                                                      }
                              });
        }
    }
}