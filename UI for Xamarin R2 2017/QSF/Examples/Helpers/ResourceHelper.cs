using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Examples.Helpers
{
    internal static class ResourceHelper
    {
        public static Stream GetResourceStream(string fileName)
        {
            var assembly = GetCurrentAssembly();
            var resourceName = assembly.GetManifestResourceNames().Where(p => p.Contains(fileName)).First();
            var resourceStream = assembly.GetManifestResourceStream(resourceName);

            return resourceStream;
        }

        public static long GetResourceSize(string fileName)
        {
            using (var stream = GetResourceStream(fileName))
            {
                return stream.Length;
            }
        }

        public static IEnumerable<string> GetResourceNamesFromFolder(string folderName)
        {
            var assembly = GetCurrentAssembly();
            var resourceNames = assembly.GetManifestResourceNames().Where(p => p.Contains(folderName)).Select(p => GetFileName(folderName, p));

            return resourceNames;
        }

        private static Assembly GetCurrentAssembly()
        {
            var assemblyName = typeof(ResourceHelper).GetTypeInfo().Assembly.GetName();
            return Assembly.Load(new AssemblyName(assemblyName.Name));
        }

        private static string GetFileName(string folderName, string resourceName)
        {
            int index = resourceName.IndexOf(folderName);
            return resourceName.Substring(index + folderName.Length + 1);
        }
    }
}