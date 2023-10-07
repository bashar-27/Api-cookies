namespace Api_cookies.Models
{
    public class SalesPerHour
    {
        public int Id { get; set; }
        public int Hour { get; set; }
        public int cookiestandId { get; set; }
        public cookiestand cookieStand { get; set; }
    }
}
