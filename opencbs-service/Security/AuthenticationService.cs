using OpenCBS.ArchitectureV2.Interface.Service;
using OpenCBS.Online.Service.Data.Security;
using OpenCBS.Online.Service.Models;
using OpenCBS.Online.Service.Models.Security;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenCBS.Online.Service.Security
{
    public class AuthenticationService : IAuthenticationService
    {
        private IContainer container;
        private IAuthService authService;
        private IAccessTokenCreator tokenCreator;

        public AuthenticationService(IContainer container, IAccessTokenCreator tokenCreator, IAuthService authService)
        {
            this.container = container;
            this.tokenCreator = tokenCreator;
            this.authService = authService;
        }

        public IAuthenticationResult Authenticate(string username, string password)
        {            
            // check the user via core
            var user = authService.Login(username, password);
            if (user == null)
                return LoginFailed();

            if (user.IsDeleted)
                return LoginFailed();
                        
            // create the token and store the session
            var accessToken = tokenCreator.Create(user.Id);

            var result = container.GetInstance<IAuthenticationResult>();
            result.AccessToken = accessToken.Token;
            result.IsValid = true;
            result.IssuedAt = accessToken.IssuedAt;
            result.Message = Resources.Content.AuthenticationResult_Success;
                
            // return result with access token
            return result;
        }

        private IAuthenticationResult LoginFailed()
        {
            var result = container.GetInstance<IAuthenticationResult>();
            result.AccessToken = null;
            result.IsValid = true;
            result.Message = Resources.Content.AuthenticationResult_Failed;
            result.IssuedAt = null;
            return result;
        }

        public IBadRequest InvalidRequest()
        {
            var result = container.GetInstance<IBadRequest>();
            result.Message = Resources.Content.AuthenticationResult_InvalidRequest;
            return result;
        }


        public IBadRequest ErrorRequest()
        {
            var result = container.GetInstance<IBadRequest>();
            result.Message = Resources.Content.AuthenticationResult_ErrorRequest;
            return result;
        }
    }
}