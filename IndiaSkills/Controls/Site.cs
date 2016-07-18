
namespace IndiaSkills.Controls
{
    /// <summary>
    /// Database Site Object
    /// </summary>
    public class Site
    {
        /// <summary>
        /// Site Unique Identifier
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Site Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Site Address.City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Site Address.State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Site Address.PinCode
        /// </summary>
        public string PinCode { get; set; }
    }
}
