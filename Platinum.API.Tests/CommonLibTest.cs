using CommonLibrary;

namespace Platinum.API.Tests
{
    public class CommonLibTest
    {
        [Fact]
        public void Hash_HelloWorld2023()
        {
            string inp = "Hello, World! 2023";
            string expected = "hLW7s9FsUUiZU3Xoy+86MA==";
            string actual = Hash.GetHash(inp);
            Assert.Equal(expected, actual);
        }
    }
}