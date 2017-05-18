﻿using Xamarin.Forms;
using Telerik.XamarinForms.Input;
using SDKBrowser.Examples.DataForm.DataAnnotations.Converter;

namespace SDKBrowser.Examples.DataForm
{
    public class DataFormDataAnnotationsConverter : ContentPage
    {
        public DataFormDataAnnotationsConverter()
        {
            // >> dataform-dataannotations-converter-form
            var dataForm = new RadDataForm
            {
                Source = new Item()
            };

            dataForm.RegisterEditor("Price", EditorType.NumberPickerEditor);
            // << dataform-dataannotations-converter-form

            Content = dataForm;
        }
    }
}

