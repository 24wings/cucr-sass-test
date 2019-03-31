using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using pmsTest;
using Xunit;
namespace Test.App.Controllers {

    public class AuthControllerTest {
        public HttpClient httpClient { get; set; } = new HttpClient ();

        /// <summary>
        /// 测试h
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async void Index_ReturnsAViewResult_WithAListOfBrainstormSessions () {
            var res = await this.httpClient.GetAsync ($"{Config.IP}/api/datasource/");
            Console.WriteLine (res.Content.ReadAsStringAsync ());

            Assert.Equal (2, 2);
        }
    }
}