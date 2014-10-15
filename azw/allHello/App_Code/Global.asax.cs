﻿// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HelloAllWorlds
{
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            string name = "DefaultApi";
            string text = "api/{controller}/{id}";
            object defaults = new
            {
                id = RouteParameter.Optional
            };
            routes.MapHttpRoute(name, text, defaults);
            name = "Default";
            text = "{controller}/{action}/{id}";
            defaults = new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional
            };
            routes.MapRoute(name, text, defaults);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            MvcApplication.RegisterGlobalFilters(GlobalFilters.Filters);
            MvcApplication.RegisterRoutes(RouteTable.Routes);
            BundleTable.Bundles.RegisterTemplateBundles();
        }
    }
}