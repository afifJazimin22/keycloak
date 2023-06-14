using System.Security.Principal;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeycloakMicroservice.Model;
using Newtonsoft.Json;
using KeycloakMicroservice.Helper;

namespace KeycloakMicroservice.Services
{
    public class ConnectService : ServerCertificate, IConnectService 
    {
        private readonly IConfiguration config;


        // public static HttpClientHandler handler = new HttpClientHandler();
        // public readonly HttpClient clients= new HttpClient();

        public ConnectService(IConfiguration config) 
        {
            this.config = config;
            // this.clients = clients;
        }
        public async Task <Token> Connect()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = ServerCertificateCustomValidation;
            HttpClient clients = new HttpClient(handler);

            // System.Console.WriteLine();
            var apiurl = config.GetValue<string>("Keycloak:apiurl");
            var clientId = config.GetValue<string>("Keycloak:client_id");
            var clientSecret = config.GetValue<string>("Keycloak:client_secret");
            var request = new HttpRequestMessage(HttpMethod.Post,
                apiurl);
            var collection = new List<KeyValuePair<string,string>>();
                collection.Add(new ("client_id", clientId));
                collection.Add(new ("client_secret", clientSecret));
                collection.Add(new ("grant_type", "client_credentials"));
            var content = new FormUrlEncodedContent(collection);

            request.Content = content;
            HttpResponseMessage response = await clients.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            
            var json = JsonConvert.DeserializeObject<Token>(result);

            Token token = new Token();
            // {
            //     access_token = json.access_token,
            //     expires_in = json.expires_in,
            //     refresh_expires_in = json.refresh_expires_in,
            //     token_type = json.token_type,
            //     not_before_policy = json.not_before_policy,
            //     scope = json.scope
            // };

            token.access_token = json.access_token;
            token.expires_in = json.expires_in;
            token.not_before_policy = json.not_before_policy;
            token.token_type = json.token_type;
            token.refresh_expires_in = json.refresh_expires_in;
            token.scope = json.scope;

            System.Console.WriteLine(token.access_token);
            
            handler.Dispose();
            clients.Dispose();
            return token;

        }

        // public static bool ServerCertificateCustomValidation(HttpRequestMessage request, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
        // {
        //     System.Console.WriteLine($"Requested URI: {request.RequestUri}");
        //     System.Console.WriteLine($"Effective date: {certificate?.GetEffectiveDateString()}");
        //     System.Console.WriteLine($"Exp date: {certificate?.GetExpirationDateString()}");
        //     System.Console.WriteLine($"Issuer: {certificate?.Issuer}");
        //     System.Console.WriteLine($"Subject: {certificate?.Subject}");

        //     System.Console.WriteLine($"Errors: {sslPolicyErrors}");

        //     // return sslPolicyErrors == SslPolicyErrors.None;
        //     return true;
        // }

    }
}