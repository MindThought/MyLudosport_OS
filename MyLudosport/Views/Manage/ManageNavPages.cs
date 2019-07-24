using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyLudosport.Views.Manage
{
    public static class ManageNavPages
    {
        public static string ActivePageKey { get { return "ActivePage"; } }

        public static string Index { get { return "Index"; } }

        public static string ChangePassword { get { return "ChangePassword"; } }

        public static string ExternalLogins { get { return "ExternalLogins"; } }

        public static string TwoFactorAuthentication { get { return "TwoFactorAuthentication"; } }

        public static string IndexNavClass(ViewContext viewContext) { return PageNavClass(viewContext, Index); }

        public static string ChangePasswordNavClass(ViewContext viewContext) { return PageNavClass(viewContext, ChangePassword); }

        public static string ExternalLoginsNavClass(ViewContext viewContext) { return PageNavClass(viewContext, ExternalLogins); }

        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) { return PageNavClass(viewContext, TwoFactorAuthentication); }
    
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) { viewData[ActivePageKey] = activePage; }
    }
}
