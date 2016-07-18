
namespace IndiaSkills.Controls
{
    /// <summary>
    /// Database Theater Object
    /// </summary>
    public class Theater
    {
        /// <summary>
        /// Hall this Theater belongs to
        /// </summary>
        public string HallCode { get; set; }
        /// <summary>
        /// Site this Theater belongs to
        /// </summary>
        public string SiteCode { get; set; }
        /// <summary>
        /// Theater seating arrangement
        /// </summary>
        public string PlanLayout { get; set; }
    }
}
