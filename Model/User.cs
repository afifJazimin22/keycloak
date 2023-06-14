using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeycloakMicroservice.Model
{
    public class User: access
    {
        public string id { get; set; }
        public int CreatedTimestamp { get; set; }
        public string username { get; set; }
        public bool enabled { get; set; }
        public bool totp { get; set; }
        public bool emailVerified { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string[] disableableCredentialTypes { get; set; }
        public string[] requiredActions { get; set; }
        public int notBefore { get; set; }
        public access manageGroupMembership { get; set; }
        public access view { get; set; }
        public access mapRoles { get; set; }
        public access impersonate { get; set; }
        public access manage { get; set; }
    }

    public class access{
        public bool manageGroupMembership { get; set; }
        public bool view { get; set; }
        public bool mapRoles { get; set; }
        public bool impersonate { get; set; }
        public bool manage { get; set; }

    }
}