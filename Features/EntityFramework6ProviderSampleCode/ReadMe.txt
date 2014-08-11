This sample includes 2 WCF Data services based on Entity Framework 6.
1. CodeFirstSample  ~/CodeFirstSampleService.svc/
   Need enable migrations(http://msdn.microsoft.com/en-us/data/jj591621.aspx) if data model is changed.
2. DataBaseFirstSample  ~/DataBaseFirstSampleService.svc/
   Need set up NorthWind database first:
       Download sql file from https://northwinddatabase.codeplex.com/releases/view/71634
       Create a database named NorthWind in sql server, and execute sql file