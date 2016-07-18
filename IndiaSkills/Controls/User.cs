
namespace IndiaSkills.Controls
{
    /// <summary>
    /// Database user object
    /// </summary>
    public class User
    {
        /// <summary>
        /// Username of this user object
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Encrypted password for user object
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Access level of user object
        /// </summary>
        public int UserLevel { get; set; }
    }
}
