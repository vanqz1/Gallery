using System;

namespace DataSource.Model
{
    public class TokenModel
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiredOn { get; set; }
    }
}