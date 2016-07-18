
namespace IndiaSkills.Controls
{
    /// <summary>
    /// Database Show object
    /// </summary>
    public class Show
    {
        /// <summary>
        /// Movie belongs to this show object
        /// </summary>
        public string MovieName { get; set; }
        /// <summary>
        /// Show Start timing
        /// </summary>
        public string StartTiming { get; set; }
        /// <summary>
        /// Show End timing
        /// </summary>
        public string EndTiming { get; set; }
        /// <summary>
        /// Show Hall Relation
        /// </summary>
        public string MovieHall { get; set; }
        /// <summary>
        /// Show Price
        /// </summary>
        public double Price { get; set; }
    }
}
