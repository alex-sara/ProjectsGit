using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace Examples
{
    public class ExamplesLoader
    {
        private IEnumerable<QSFControl> controls;

        public ExamplesLoader(string sourceFile)
        {
            this.ReadXmlFile(sourceFile);
        }

        private void ReadXmlFile(string sourceFile)
        {
            var assembly = typeof(ExamplesLoader).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream(sourceFile);

            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<QSFControl>));
                this.controls = (List<QSFControl>)serializer.Deserialize(reader);
            }
        }

        internal IEnumerable<QSFControl> GetAvailableControls()
        {
            var availableControls = new List<QSFControl>();
            foreach (QSFControl control in this.controls)
            {
                if (control.ExcludeFrom != null || !string.IsNullOrEmpty(control.ExcludeFrom))
                {
                    var excludeFlags = this.NormalizeExcludeFlags(control.ExcludeFrom);

                    foreach (string flag in excludeFlags)
                    {
                        if (this.IsFlagMatchedWithPlatform(flag))
                        {
                            control.IsExcludedFromCurrentOS = true;
                            continue;
                        }
                    }

                    if (!control.IsExcludedFromCurrentOS)
                    {
                        availableControls.Add(control);
                    }
                }
                else
                {
                    availableControls.Add(control);
                }
            }
            return availableControls;
        }

        private bool IsFlagMatchedWithPlatform(string flag)
        {
            bool result = false;
            if(flag.Equals("P") && Device.OS == TargetPlatform.WinPhone)
                result = true;
            if (flag.Equals("A") && Device.OS == TargetPlatform.Android)
                result = true;
            if (flag.Equals("iOS") && Device.OS == TargetPlatform.iOS)
                result = true;
            if (flag.Equals("U") && Device.OS == TargetPlatform.Windows)
                result = true;
            return result;
        }

        internal IEnumerable<string> NormalizeExcludeFlags(string excludeFlags)
        {
            if (excludeFlags.Contains(","))
            {
                List<string> flags = excludeFlags.Split(',').ToList<string>();
                return flags;
            }
            return new List<string>() { excludeFlags };
        }

        internal IEnumerable<Example> GetFeaturedExamples()
        {
            var featuredExamples = new List<Example>();
            foreach (QSFControl control in this.controls)
            {
                List<Example> excludedExamples = new List<Example>();
                if (control.IsExcludedFromCurrentOS)
                {
                    continue;
                }

                foreach (Example example in control.Examples)
                {
                    if (example.ExcludeFrom != null)
                    {
                        var excludeFlags = this.NormalizeExcludeFlags(example.ExcludeFrom);
                        foreach (string flag in excludeFlags)
                        {
                            if (this.IsFlagMatchedWithPlatform(flag))
                            {
                                excludedExamples.Add(example);
                                continue;
                            }
                            if (example.IsFeatured)
                            {
                                AddExample(featuredExamples, control, example);
                            }
                        }
                    }
                    else
                    {
                        AddExample(featuredExamples, control, example);
                    }
                }

                if (excludedExamples.Count != 0)
                {
                    foreach (Example excludedExample in excludedExamples)
                    {
                        control.Examples.Remove(excludedExample);
                    }
                }
            }
            return featuredExamples;
        }

        private static void AddExample(List<Example> featuredExamples, QSFControl control, Example example)
        {
            if (string.IsNullOrEmpty(example.Control))
            {
                example.Control = control.Name;
            }
            featuredExamples.Add(example);
        }

        internal string GetExamplePageName(string controlName, string exampleTitle)
        {
            foreach (QSFControl control in this.controls)
            {
                if (control.Name.Equals(controlName))
                {
                    foreach (Example example in control.Examples)
                    {
                        if (example.Title.Equals(exampleTitle))
                        {
                            if (example.PageName != null || !string.IsNullOrEmpty(example.PageName))
                            {
                                return example.PageName;
                            }
                            else
                            {
                                return example.Title;
                            }
                        }
                        continue;
                    }
                }
                continue;
            }
            throw new ArgumentException("Could not find PageName for {0} example.", exampleTitle);
        }
    }
}