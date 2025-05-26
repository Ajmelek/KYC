namespace STB_everywhere.Dots
{
    /// <summary>
    /// Response model for login operations
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Message indicating the result of the login operation
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// JWT token for authentication
        /// </summary>
        public string Token { get; set; }
    }
} 