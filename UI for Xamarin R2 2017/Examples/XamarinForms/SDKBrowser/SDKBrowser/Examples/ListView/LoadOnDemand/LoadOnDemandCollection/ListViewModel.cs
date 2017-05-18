﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.DataControls.ListView;

namespace SDKBrowser.Examples.ListView.LoadOnDemand.LoadOnDemandCollection
{
    // >> listview-loadondemand-loadondemandcollection-viewmodel
    public class ListViewModel
    {
        public ListViewLoadOnDemandCollection Source { get; set; }
        private int lodTriggerCount;
        public ListViewModel()
        {
            this.Source = new ListViewLoadOnDemandCollection((cancelationToken) =>
            {
                List<string> result = new List<string>();

                try
                {
                    //simulates connection latency
                    Task.Delay(4000, cancelationToken).Wait();

                    this.lodTriggerCount++;
                    foreach (string item in Enum.GetNames(typeof(DayOfWeek)))
                    {
                        result.Add(string.Format("LOD: {0} - {1}", lodTriggerCount, item));
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    //exception is thrown when the task is canceled. Returning null does not affect the ItemsSource.
                    return null;
                }
            });

            for (int i = 0; i < 14; i++)
            {
                Source.Add(string.Format("Item {0}", i));
            }
        }
    }
    // << listview-loadondemand-loadondemandcollection-viewmodel
}
