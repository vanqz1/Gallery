using System;

namespace WebAPI.Models
{
    public class Token
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiredOn { get; set; }
    }
}