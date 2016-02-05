using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;

namespace TVS.WebApp.ViewModels.Manage
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
