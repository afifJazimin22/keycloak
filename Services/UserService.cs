using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Keycloak.AuthServices.Sdk.Admin.Models;
using KeycloakMicroservice.Helper;
using Newtonsoft.Json;

namespace KeycloakMicroservice.Services
{
    public class UserService : ServerCertificate, IUserService
    {
        private readonly IConnectService _connectService;

        public UserService(IConnectService connectService)
        {
            _connectService = connectService;
        }

        public async Task<List<User>> GetUser()
        {
            var user = new List<User>();
            var token = await _connectService.Connect();

            string tokenJ = token.access_token;

            // System.Console.WriteLine($"Thi:  ", tokenJ);

            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = ServerCertificateCustomValidation;

            HttpClient httpclient = new HttpClient(clienthandler);

            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJ);

            string apiurl = "https://sso.sarawakskills.my:8443/admin/realms/User-Directory/users";

            HttpResponseMessage response = await httpclient.GetAsync(apiurl);

            var result = await response.Content.ReadAsStringAsync();

            user = JsonConvert.DeserializeObject<List<User>>(result);


            System.Console.WriteLine(user.ToString());

            return user;

        }
    }
}