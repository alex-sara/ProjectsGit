using System;
using Xamarin.Forms;

namespace Examples.Helpers
{
    public static class ExampleHelper
    {
        public static bool SetImageButtonOnTop(ref Grid rootGrid)
        {
            ImageButton back = null;
            ImageButton info = null;

            foreach (var element in rootGrid.Children)
            {
                var button = element as ImageButton;
                if (button != null)
                {
                    if (button.Type == ButtonType.Back)
                    {
                        back = button;
                    }

                    if (button.Type == ButtonType.Info)
                    {
                        info = button;
                    }
                }
            }

            if (Device.OS == TargetPlatform.iOS)
            {
                if (back != null)
                {
                    rootGrid.Children.Remove(back);
                    rootGrid.Children.Add(back);
                    AnimationHelper.Animate(back, Device.OS);
                }

                if (info != null)
                {
                    rootGrid.Children.Remove(info);
                    rootGrid.Children.Add(info);
                    AnimationHelper.AnimateScale(info);
                }

                return true;
            }
            else if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.Windows)
            {
                if (info != null)
                {
                    rootGrid.Children.Remove(info);
                    rootGrid.Children.Add(info);
                    AnimationHelper.Animate(info, Device.OS);

                    return true;
                }
            }

            return false;
        }
    }
}