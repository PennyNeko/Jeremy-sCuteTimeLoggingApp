using Atlassian.Jira;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Jeremy_sCuteTimeLoggingApp
{
    public partial class App : Application
    {
        static App()
        {
            var appSettings = ConfigurationManager.AppSettings;
            _clientApp = PublicClientApplicationBuilder
            .Create(ClientId).WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
            .Build();
            _workEntryDataContext = new WorkEntryDataContext();
            _jiraClient = Jira.CreateOAuthRestClient("https://jeremyscuteloggingapp.atlassian.net/", appSettings["ConsumerKey"], appSettings["ConsumerSecret"], appSettings["AccessToken"],appSettings["TokenSecret"]);

        }

        // Below are the clientId (Application Id) of your app registration and the tenant information.
        // You have to replace:
        // - the content of ClientID with the Application Id for your app registration
        // - the content of Tenant by the information about the accounts allowed to sign-in in your application:
        //   - For Work or School account in your org, use your tenant ID, or domain
        //   - for any Work or School accounts, use `organizations`
        //   - for any Work or School accounts, or Microsoft personal account, use `common`
        //   - for Microsoft Personal account, use consumers
        private static WorkEntryDataContext _workEntryDataContext; 

        private static string ClientId = "2068be73-3d10-4717-a80b-d456f2687f7d";

        private static string Tenant = "common";

        private static Jira _jiraClient;

        private static IPublicClientApplication _clientApp;

        public static IPublicClientApplication PublicClientApp { get { return _clientApp; } }

        public static Jira JiraClient { get { return _jiraClient; } }

        public static WorkEntryDataContext WorkEntryDataContext { get => _workEntryDataContext;}
    }
}
