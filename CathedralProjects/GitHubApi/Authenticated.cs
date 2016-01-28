using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Octokit;

namespace CathedralProjects.GitHubApi
{
        //    Client ID
        //1b94452678961f919d63
        //Client Secret
        //197f44d4b48295a8d0014b858612b7e571639694
    public class Authenticated
    {
        public const string ClientId = "1b94452678961f919d63";
        public const string ClientSecret = "197f44d4b48295a8d0014b858612b7e571639694";
        public GitHubClient Client = new GitHubClient(new ProductHeaderValue("CathedralPojects"));

        public void GetAccessToken()
        {
            string csrf = Membership.GeneratePassword(24, 1);
            //Session["CSRF:State"] = csrf;

            var request = new OauthLoginRequest(ClientId)
            {
                Scopes = { "user", "notifications" },
                State = csrf
            };

            // NOTE: user must be navigated to this URL
            var oauthLoginUrl = Client.Oauth.GetGitHubLoginUrl(request);
            //.

        }

    }
}