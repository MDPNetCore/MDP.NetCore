﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MDP.AspNetCore.Authentication
{
    public static partial class LocalAuthenticationExtensions
    {
        // Methods
        public static AuthenticationBuilder AddLocal(this AuthenticationBuilder builder, Action<CookieAuthenticationOptions>? configureOptions = null)
        {
            #region Contracts

            if (builder == null) throw new ArgumentException($"{nameof(builder)}=null");

            #endregion

            // AuthenticationOptions
            if (configureOptions == null)
            {
                builder.AddCookie(LocalAuthenticationDefaults.AuthenticationScheme);
            }
            else
            {
                builder.AddCookie(LocalAuthenticationDefaults.AuthenticationScheme, null, configureOptions);
            }

            // Return
            return builder;
        }
    }

    public static partial class LocalAuthenticationExtensions
    {
        // Methods
        public static Task<AuthenticateResult> LocalAuthenticateAsync(this HttpContext httpContext)
        {
            #region Contracts

            if (httpContext == null) throw new ArgumentException(nameof(httpContext));

            #endregion

            // AuthenticateAsync
            return httpContext.AuthenticateAsync(LocalAuthenticationDefaults.AuthenticationScheme);
        }

        public static Task LocalSignInAsync(this HttpContext httpContext, ClaimsPrincipal principal)
        {
            #region Contracts

            if (httpContext == null) throw new ArgumentException($"{nameof(httpContext)}=null");
            if (principal == null) throw new ArgumentException($"{nameof(principal)}=null");

            #endregion

            // SignInAsync
            return httpContext.SignInAsync(LocalAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public static Task LocalSignOutAsync(this HttpContext httpContext)
        {
            #region Contracts

            if (httpContext == null) throw new ArgumentException($"{nameof(httpContext)}=null");

            #endregion

            // SignOutAsync
            return httpContext.SignOutAsync(LocalAuthenticationDefaults.AuthenticationScheme);
        }
    }
}