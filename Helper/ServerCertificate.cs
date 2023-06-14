using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KeycloakMicroservice.Helper;
    public class ServerCertificate
    {
        public static bool ServerCertificateCustomValidation(HttpRequestMessage request, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
        {
            System.Console.WriteLine($"Requested URI: {request.RequestUri}");
            System.Console.WriteLine($"Effective date: {certificate?.GetEffectiveDateString()}");
            System.Console.WriteLine($"Exp date: {certificate?.GetExpirationDateString()}");
            System.Console.WriteLine($"Issuer: {certificate?.Issuer}");
            System.Console.WriteLine($"Subject: {certificate?.Subject}");

            System.Console.WriteLine($"Errors: {sslPolicyErrors}");

            // return sslPolicyErrors == SslPolicyErrors.None;
            return true;
        }
    }