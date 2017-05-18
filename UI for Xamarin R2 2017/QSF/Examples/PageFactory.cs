using System;
using Xamarin.Forms;

namespace Examples
{
    public static class PageFactory
    {
        private const string DEFAULT_EXAMPLES_NAMESPACE = "Examples.";
        private const string DEFAULT_EXAMPLE_PAGE_NAME = ".Example";

        public static Page GetPage(string controlAndClassName)
        {
            var instance = GetInstance(controlAndClassName);
            if (instance as ContentPage != null)
            {
                return instance as ContentPage;
            }
            return instance as TabbedPage;
        }

        private static object GetInstance(string controlAndClassName)
        {
            Type type = Type.GetType(DEFAULT_EXAMPLES_NAMESPACE + controlAndClassName + DEFAULT_EXAMPLE_PAGE_NAME);
            if (type != null)
            {
                return Activator.CreateInstance(type);
            }
            throw new ArgumentException(string.Format("Could not create actual page from the string: \"{0}\"! Check if the namespace of the example is correct.", DEFAULT_EXAMPLES_NAMESPACE + controlAndClassName + DEFAULT_EXAMPLE_PAGE_NAME));
        }
    }
}