﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SDKBrowser.Examples.Calendar
{
    public partial class Appointments
    {
        public Appointments()
        {
            InitializeComponent();

            DateTime dateInThePast = new DateTime(1990, 1, 1);

            cal.AppointmentsSource = new List<Appointment>()
            {
                new Appointment() { StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(2).AddTicks(-1), Title = "Mom's Birthday", Color = Xamarin.Forms.Color.Blue },
                new Appointment() { StartDate = DateTime.Today.AddDays(3).AddHours(17), EndDate = DateTime.Today.AddDays(3).AddHours(22), Title = "Big Game", Color = Xamarin.Forms.Color.Green },
                new Appointment() { StartDate = DateTime.Today.AddDays(11).AddHours(20), EndDate = DateTime.Today.AddDays(12).AddHours(4), Title = "Progress Party", Color = Xamarin.Forms.Color.Lime },

                new Appointment() { StartDate = dateInThePast.AddDays(1), EndDate = dateInThePast.AddDays(2).AddTicks(-1), Title = "Mom's Birthday", Color = Xamarin.Forms.Color.Blue },
                new Appointment() { StartDate = dateInThePast.AddDays(3).AddHours(17), EndDate = dateInThePast.AddDays(3).AddHours(22), Title = "Big Game", Color = Xamarin.Forms.Color.Green },
                new Appointment() { StartDate = dateInThePast.AddDays(11).AddHours(20), EndDate = dateInThePast.AddDays(12).AddHours(4), Title = "Progress Party", Color = Xamarin.Forms.Color.Lime },

            };
        }
    }

    public class Appointment : Telerik.XamarinForms.Input.IAppointment
    {
        public DateTime StartDate { get; set; }

        public Xamarin.Forms.Color Color { get; set; }

        public DateTime EndDate { get; set; }

        public string Title { get; set; }

        public bool IsAllDay { get; set; }

        public string Detail { get; set; }
    }
}