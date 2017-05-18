﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SDKBrowser.Examples.Rating
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configurator : ContentPage
    {
        public Configurator()
        {
            InitializeComponent();
        }

        private void ItemFillPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rating.ItemFill = this.GetColor(this.itemFillPicker);
        }

        private void ItemStrokePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rating.ItemStroke = this.GetColor(this.itemStrokePicker);
        }

        private void SelectedItemFillSelectedPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rating.SelectedItemFill = this.GetColor(this.selectedItemFillPicker);
        }

        private void SelectedItemStrokeSelectedPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.rating.SelectedItemStroke = this.GetColor(this.selectedItemStrokePicker);
        }

        private Color GetColor(Picker picker)
        {
            return (Color)new ColorTypeConverter().ConvertFromInvariantString(picker.SelectedItem.ToString());
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.rating.ItemStrokeThickness = e.NewValue;
        }

        private void Slider_ValueChanged_1(object sender, ValueChangedEventArgs e)
        {
            this.rating.SelectedItemStrokeThickness = e.NewValue;
        }
    }
}