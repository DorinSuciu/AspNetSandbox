using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspNetSandbox.Tests
{
    public class StartupTests
    {
        [Fact]
        public void CheckConversionToEFConnectionString()
        {
            //Asume
            string databaseUrl = "postgres://pwfaygvwgqjujq:764b5d558a31c711a203ef631722167e2832998c24d748ea4dcc29ef9497d09d@ec2-54-155-61-133.eu-west-1.compute.amazonaws.com:5432/d9kf2d06613b69";

            //Act
            string convertedConnectionString = Startup.ConvertConnectionString(databaseUrl);

            //Assert
            Assert.Equal("Server=ec2-54-155-61-133.eu-west-1.compute.amazonaws.com; Port=5432; Database=d9kf2d06613b69; User Id=pwfaygvwgqjujq; Password=764b5d558a31c711a203ef631722167e2832998c24d748ea4dcc29ef9497d09d; SslMode=Require; Trust Server Certificate=true", convertedConnectionString);
        }
    }
}
