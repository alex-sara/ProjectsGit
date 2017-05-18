using System;
using System.Collections.ObjectModel;

namespace Examples.DataForm.Reservations
{
    public class MainViewModel
    {
        public ObservableCollection<Reservation> Reservations { get; set; }

        public MainViewModel()
        {
            this.Reservations = new ObservableCollection<Reservation>()
            {
                new Reservation()
                {
                    ReservationHolder = "Christian Heilmann",
                    HolderPhoneNumber = "359-55-1236",
                    ReservationDate = DateTime.Today,
                    ReservationTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    GuestNumber = 2,
                    TableNumber = 5,
                    TableSection = 0,
                    OrderOrigin = OrderOrigin.Online
                },
                new Reservation()
                {
                    ReservationHolder = "Thomas Drake",
                    HolderPhoneNumber = "359-55-1237",
                    ReservationDate = DateTime.Today,
                    ReservationTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    GuestNumber = 5,
                    TableNumber = 2,
                    TableSection = 0,
                    OrderOrigin = OrderOrigin.Online
                },
                new Reservation()
                {
                    ReservationHolder = "Aaron White",
                    HolderPhoneNumber = "359-55-1238",
                    ReservationDate = DateTime.Today,
                    ReservationTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    GuestNumber = 4,
                    TableNumber = 4,
                    TableSection = 0,
                    OrderOrigin = OrderOrigin.Phone
                },
                new Reservation()
                {
                    ReservationHolder = "Rachel Nabors",
                    HolderPhoneNumber = "359-55-1239",
                    ReservationDate = DateTime.Today,
                    ReservationTime = DateTime.Today.AddHours(20).AddMinutes(30),
                    GuestNumber = 3,
                    TableNumber = 3,
                    TableSection = 0,
                    OrderOrigin = OrderOrigin.Inperson
                },
            };
        }
    }
}