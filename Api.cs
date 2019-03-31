using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.DTO;
using Newtonsoft.Json;
using Xunit;
// using Cucr.CucrSaas.App.DTO;

namespace pmsTest {
    /// <summary>
    /// 测试配置
    /// </summary>
    public class Api {
        private HttpClient httpClient { get; set; } = new HttpClient ();

        public Task<string> get () {
            return this.httpClient.GetStringAsync ($"{Config.IP}");
        }

        public Task<HttpResponseMessage> post (HttpContent httpContent) {
            return this.httpClient.PostAsync ($"{Config.IP}", httpContent);
        }

        [Fact]
        public async void testAppUserLogin () {
            var loginInput = new AppUserLoginInput ();
            loginInput.loginPassword = "string";
            loginInput.phone = "string";
            loginInput.mechineId = "string";
            var json = JsonConvert.SerializeObject (loginInput);
            var content = new StringContent (json.ToString (), Encoding.UTF8, "application/json");
            //$"{Config.IP}/api​/CucrSaas​/App​/Auth​/appLogin"
            var res = await this.httpClient.PostAsync (Config.IP + "/api/CucrSaas/App/Auth/appLogin", content);
            var str = await res.Content.ReadAsStringAsync ();
            var commonRtn = JsonConvert.DeserializeObject<CommonRtn> (str);

            Assert.True (commonRtn.success);
        }

    }
}