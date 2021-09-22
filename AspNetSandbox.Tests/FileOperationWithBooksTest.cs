using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class FileOperationWithBooksTest
    {
        [Fact]
        public void EnumerateFilesTest()
        {
            System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(".");
            var files = directoryInfo.EnumerateFiles();
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }
        }

        [Fact]
        public void CreateFileTest()
        {
            File.WriteAllText("newSettings.json", @"{
    ""ConnectionStrings"": {
    ""LocalPostgresConnection"": ""Server=127.0.0.1;Port=5432;Database=aspNetSandbox-dorin;User Id=postgres;Password=0eb55f5004111d434b7967c45ad9b780;"",
    ""SqlConnection"": ""Server=(localdb)\\mssqllocaldb;Database=aspnet-AspNetSandbox-EE9A05D4-6579-4FB7-86C4-043D2F4A39E8;Trusted_Connection=True;MultipleActiveResultSets=true"",
    ""Heroku"": ""Server=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; Database=d9kf2d06613b69; User Id=pwfaygvwgqjujq; Password=764b5d558a31c711a203ef631722167e2832998c24d748ea4dcc29ef9497d09d; SslMode=Require; Trust Server Certificate=true"",
    ""HerokuRaw"": ""postgres://pwfaygvwgqjujq:764b5d558a31c711a203ef631722167e2832998c24d748ea4dcc29ef9497d09d@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d9kf2d06613b69"",
    ""DefaultConnection"": ""Port=5432; Database=SandboxDb; Host=localhost; User Id=postgres;Password=0eb55f5004111d434b7967c45ad9b780; Trust Server Certificate=true""
            },
    ""Logging"": {
        ""LogLevel"": {
            ""Default"": ""Information"",
            ""Microsoft"": ""Warning"",
            ""Microsoft.Hosting.Lifetime"": ""Information""
    }
  },
  ""AllowedHosts"": ""*""
}
");
        }

        [Fact]
        public void ReadFileTest()
        {
           // fs - file stream
            using (var fs = File.OpenRead("newSettings.json"))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    var returnedString = temp.GetString(b);
                    Console.WriteLine(returnedString);
                }
            }
        }
    }
}
