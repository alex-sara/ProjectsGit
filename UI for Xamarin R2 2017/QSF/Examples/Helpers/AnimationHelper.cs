using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Examples.Helpers
{
    public static class AnimationHelper
    {
        private static double x;
        private static double y;
        private static double scale;
        private static double opacity;

        public static async Task<bool> NavigateFrom(VisualElement page)
        {
            SaveState(page);
            await page.FadeTo(0, 150, Easing.Linear);
            await page.TranslateTo(Examples.Helpers.DeviceHelper.ScreenWidth * 0.7, 0, 250, Easing.Linear);
            RestoreState(page);
            return false;
        }

        public static async Task<bool> NavigateTo(VisualElement page)
        {
            SetInitialVisualization(page);
            await page.TranslateTo(0, 0, 0, Easing.Linear);
            await page.FadeTo(1, 550, Easing.Linear);
            return false;
        }

        private static void SaveState(VisualElement page)
        {
            opacity = page.Opacity;
            x = page.TranslationX;
            y = page.TranslationY;
            scale = page.Scale;
        }

        async public static void Animate(VisualElement obj, TargetPlatform os)
        {
            double startX = obj.TranslationX;
            double startY = obj.TranslationY;
            double delta = 2.0;
            uint animationSpeed = 100;
            Easing easing = Easing.CubicInOut;

            switch (os)
            {
                case TargetPlatform.Android:
                case TargetPlatform.Windows:
                    await obj.TranslateTo(startX, startY + delta, animationSpeed, easing);
                    await Task.Delay(500);
                    obj.IsVisible = true;

                    await obj.ScaleTo(0.9, animationSpeed, easing);
                    await obj.ScaleTo(1.6, animationSpeed, easing);
                    await obj.ScaleTo(1.0, animationSpeed, easing);
                    await obj.ScaleTo(1.2, animationSpeed, easing);
                    await obj.ScaleTo(0.9, animationSpeed, easing);
                    await obj.ScaleTo(1.0, animationSpeed, easing);

                    break;
                case TargetPlatform.iOS:

                    startX = 0;
                    await Task.Delay(300);
                    obj.IsVisible = true;

                    await obj.TranslateTo(startX - 9, startY, animationSpeed, easing);
                    await obj.TranslateTo(startX - 3, startY, animationSpeed, easing);
                    await obj.TranslateTo(startX - 12, startY, animationSpeed, easing);
                    await obj.TranslateTo(startX - 6, startY, animationSpeed, easing);
                    await obj.TranslateTo(startX - 9, startY, animationSpeed, easing);
                    break;
                default:
                    break;
            }
        }

        private static void RestoreState(VisualElement page)
        {
            page.TranslationY = y;
            page.TranslationX = x;
            page.Scale = scale;
            page.Opacity = opacity;
        }

        async internal static void AnimateScale(VisualElement obj)
        {
            await Task.Delay(800);
            obj.Scale = 0.3;
            obj.IsVisible = true;
            await obj.ScaleTo(1, 100, Easing.CubicInOut);
        }

        private static void SetInitialVisualization(VisualElement page)
        {
            page.TranslationX = DeviceHelper.ScreenWidth * 0.3;
            page.Opacity = 0;
        }
    }
}