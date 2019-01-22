using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.ViewModels.Consent
{
    public class ProcessConsentResult
    {
        public bool IsRedirect => ReturnUrl != null;
        public string ReturnUrl { get; set; }

        public string ClientId { get; set; }

        public ConsentViewModel ConsentViewModel { get; set; }
        public bool ShowView => ConsentViewModel != null;

        public bool HasValidationError => ValidationError != null;
        public string ValidationError { get; set; }
    }
}
