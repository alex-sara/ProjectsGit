namespace Examples.DataForm.Reservations
{
    public class DataFormViewModel
    {
        public DataFormViewModel(Reservation source)
        {
            if (source == null)
            {
                source = new Reservation();
                this.PageTitle = "New Reservation";
            }
            else
            {
                this.PageTitle = "Edit Reservation";
            }

            this.FormSource = source;
        }

        public Reservation FormSource { get; set; }
        public string PageTitle { get; set; }
    }
}