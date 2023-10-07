namespace Api_cookies.DTO
{
    public class cookieStandDTO
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Max_Customer_Per_Hour { get; set; }
        public int Min_Customer_Pre_Hour { get; set; }
        public double Average_Cookies_Per_Sale { get; set; }
        public string Owner { get; set; }
        public List<int> Hour {  get; set; }
    }
}
