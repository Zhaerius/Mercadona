﻿using MudBlazor;

namespace BlazorWasm.Templates
{
    public static class MudCustomTemplate
    {
        public static MudTheme GetTemplate()
        {
            return new MudTheme()
            {
                Palette = new PaletteLight()
                {
                    Primary = "#00A773",
                    Secondary = "#E07A5F",
                    Tertiary = "#ECBA82",
                    AppbarBackground = "#00A773",
                    Background = "#F7FAFC"
                    //Background = "#00a7730a"
                },
                LayoutProperties = new LayoutProperties()
                {
                    DrawerWidthLeft = "260px"
                }
            };
        }
    }
}
