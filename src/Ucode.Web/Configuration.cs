using MudBlazor.Utilities;
using MudBlazor;

namespace Ucode.Web
{
    public static class Configuration
    {
        public const string HttpClientName = "ucode";
        public static string BackendUrl { get; set; } = "http://localhost:5270";
     //   public static string FrontendUrl { get; set; } = "http://localhost:5249";

        public static MudTheme Theme = new()
        {
            Typography = new Typography
            {
                Default = new Default()
                {
                    FontFamily = ["Raleway", "sans-serif"]
                }
            },

            Palette = new PaletteLight
            {
                Primary = new MudColor("1EFA2D"), //594AE2
                PrimaryContrastText = new MudColor("#FFFFFF"),
                Secondary = Colors.LightGreen.Darken3,
                Background = Colors.Grey.Lighten4,
                AppbarBackground = new MudColor("1EFA2D"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.Black,
                DrawerBackground = Colors.Green.Darken4
            },
            PaletteDark = new PaletteDark
            {
                Primary = Colors.LightGreen.Accent3,
                Secondary = Colors.LightGreen.Darken3,
                // Background = Colors.LightGreen.Darken4,
                AppbarBackground = new MudColor("1EFA2D"),
                AppbarText = Colors.Shades.White,
                PrimaryContrastText = new MudColor("#FFFFFF")
            }

        };
            


    }

}