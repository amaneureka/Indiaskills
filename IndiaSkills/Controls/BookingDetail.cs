
namespace IndiaSkills.Controls
{
    /// <summary>
    /// Database Booking Object
    /// </summary>
    public class BookingDetail
    {
        /// <summary>
        /// Booking Movie Name Relation
        /// </summary>
        public string MovieName { get; set; }
        /// <summary>
        /// Theater Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Booked show timings
        /// </summary>
        public string Timing { get; set; }
        /// <summary>
        /// Booked snacks -- encoded string
        /// </summary>
        public string Snacks { get; set; }
        /// <summary>
        /// Booked seat index -- internally handled
        /// </summary>
        public int SeatNo { get; set; }
        /// <summary>
        /// Booking cost paid by the user
        /// </summary>
        public double PricePaid { get; set; }
        /// <summary>
        /// Ticket Number
        /// </summary>
        public int RandomHash { get; set; }
    }
}
