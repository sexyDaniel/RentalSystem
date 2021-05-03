using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using PapsCourse.Client.Attributes;
using PapsCourse.Client.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Client.RouteViews
{
    public class AppRouteView:RouteView
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAccountSession Session { get; set; }

        protected override void Render(RenderTreeBuilder builder)
        {            
            var authorize = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AuthorizeAttribute)) != null;
            var admin = Attribute.GetCustomAttribute(RouteData.PageType, typeof(AdminAttribute)) != null;
            if (authorize && !Session.IsAuthenticated)
                NavigationManager.NavigateTo("/account/login");
            else if (admin && (!Session.IsAuthenticated || !bool.Parse(Session.GetValue("isAdmin"))))
                NavigationManager.NavigateTo("/");
            else
                base.Render(builder);
        }
    }
}
