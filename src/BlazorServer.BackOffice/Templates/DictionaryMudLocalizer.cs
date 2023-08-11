using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Localization;
using MudBlazor;

namespace BlazorServer.BackOffice.Templates
{
    public class MyMudLocalizer : MudLocalizer
    {
        private Dictionary<string, string> _localization;

        public MyMudLocalizer()
        {
            _localization = new()
            {
                { "MudDataGrid.Save", "Sauvegarder" },
                { "MudDataGrid.Cancel", "Annuler" },
            };
        }

        public override LocalizedString this[string key]
        {
            get
            {
                var currentCulture = Thread.CurrentThread.CurrentUICulture.Parent.TwoLetterISOLanguageName;
                if (currentCulture.Equals("fr", StringComparison.InvariantCultureIgnoreCase)
                    && _localization.TryGetValue(key, out var res))
                {
                    return new(key, res);
                }
                else
                {
                    return new(key, key, true);
                }
            }
        }
    }
}



