using Api_cookies.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_cookies.Data
{
    public class CookieSalmonDbContext :DbContext
    {
        public CookieSalmonDbContext(DbContextOptions<CookieSalmonDbContext>option):base(option) {
        
        }
    
      public  DbSet<cookiestand> CookiesStand {  get; set; } 
        public  DbSet<SalesPerHour> SalesHour {  get; set; }
    }
}
