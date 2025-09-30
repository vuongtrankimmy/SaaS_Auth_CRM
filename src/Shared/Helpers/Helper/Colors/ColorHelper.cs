using System;

namespace Helpers.Helper.Colors
{
    public static class ColorHelper
    {
        public static string ToColor()
        {
            var random = new Random();
            var color = $"#{random.Next(0x1000000):X6}"; // = "#A197B9"
            return color;
        }
    }
}
