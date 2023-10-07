using Api_cookies.Data;
using Api_cookies.DTO;
using System.Linq;
using Api_cookies.Models.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api_cookies.Models.Service
{
    public class cookiestandService : Icookiestand
    {
        private readonly CookieSalmonDbContext _db;
        public cookiestandService(CookieSalmonDbContext db)
        {
            _db = db;
        }
        public async Task<cookieStandDTO> Create(CreateCookieDTO standDTO)
        {
            cookiestand stand = new cookiestand() { 
            Location = standDTO.Location,
            Description = standDTO.Description,
            Max_Customer_Per_Hour = standDTO.Max_Customer_Per_Hour,
            Min_Customer_Pre_Hour = standDTO.Min_Customer_Pre_Hour,
            Average_Cookies_Per_Sale = standDTO.Average_Cookies_Per_Sale,
            Owner = standDTO.Owner,
           };
            _db.CookiesStand.Add(stand);
            await _db.SaveChangesAsync();

            stand.Hour = GenerateRandom(stand);
            
            _db.Entry(stand).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            var  GetHour = _db.SalesHour.Where(x => x.cookiestandId == stand.Id).Select(x => x.Hour).ToList();
            cookieStandDTO newStandDTO = new cookieStandDTO()
            {
                Id =stand.Id,
                Location = standDTO.Location,
                Description = standDTO.Description,
                Hour = GetHour,
                Max_Customer_Per_Hour = standDTO.Max_Customer_Per_Hour,
                Min_Customer_Pre_Hour = standDTO.Min_Customer_Pre_Hour,
                Average_Cookies_Per_Sale = standDTO.Average_Cookies_Per_Sale,
                Owner = standDTO.Owner
            };
            return newStandDTO;
            
        }


        public async Task<List<cookieStandDTO>> GetAll()
        {
            List<cookieStandDTO> CookieStandDTOList = new List<cookieStandDTO>();
            var cookieStands = _db.CookiesStand.Include(X => X.Hour).ToList();
            foreach (var stand in cookieStands)
            {
                var hour = _db.SalesHour.Where(x => x.cookiestandId == stand.Id).Select(x => x.Hour).ToList();

                var cookiestanddto = new cookieStandDTO
                {
                    Id = stand.Id,
                    Location = stand.Location,
                    Description = stand.Description,
                    Max_Customer_Per_Hour = stand.Max_Customer_Per_Hour,
                    Min_Customer_Pre_Hour = stand.Min_Customer_Pre_Hour,
                    Average_Cookies_Per_Sale = stand.Average_Cookies_Per_Sale,
                    Owner = stand.Owner,
                    Hour = hour
                };

                CookieStandDTOList.Add(cookiestanddto);
                
            }
            return CookieStandDTOList;
        }

        public async Task<cookieStandDTO> GetById(int id)
        {
            var stand = _db.CookiesStand.Find(id);
            if (stand == null)
                return null;

        var hourStand = _db.SalesHour.Where(x=>x.cookiestandId == stand.Id).Select(x=>x.Hour).ToList();
            var cookieDTO = new cookieStandDTO
            {
                Id = stand.Id,
                Location = stand.Location,
                Description = stand.Description,
                Max_Customer_Per_Hour = stand.Max_Customer_Per_Hour,
                Min_Customer_Pre_Hour = stand.Min_Customer_Pre_Hour,
                Average_Cookies_Per_Sale = stand.Average_Cookies_Per_Sale,
                Owner = stand.Owner,
                Hour = hourStand
            };


           return  cookieDTO;
        }
        public List<SalesPerHour>  GenerateRandom(cookiestand stand)
        {
          
             Random random = new Random();
            List<SalesPerHour> hourlySales = new List<SalesPerHour>();

            for (int hour = 1; hour <= 12; hour++)
            {
                SalesPerHour sale = new SalesPerHour();
                sale.cookiestandId = stand.Id;
                sale.Hour = random.Next(stand.Min_Customer_Pre_Hour, stand.Max_Customer_Per_Hour + 1);
                hourlySales.Add(sale);
            }

            return hourlySales;
        }

        public async Task<cookieStandDTO> Update(int id, CreateCookieDTO stand)
        {
            var updateStand = _db.CookiesStand.Include(x => x.Hour).Where(a => a.Id == id).FirstOrDefault();

            if (updateStand == null)
            {
                return null; 
            }

            updateStand.Description = stand.Description;
            updateStand.Location = stand.Location;
            updateStand.Owner = stand.Owner;
            updateStand.Min_Customer_Pre_Hour = stand.Min_Customer_Pre_Hour;
            updateStand.Max_Customer_Per_Hour = stand.Max_Customer_Per_Hour;
            updateStand.Hour = GenerateRandom(updateStand);

            _db.Entry(updateStand).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            var HourSale = _db.SalesHour
                .Where(x => x.cookiestandId == updateStand.Id)
                .Select(x => x.Hour)
                .ToList();

            var cookiesDTO = new cookieStandDTO
            {
                Id = updateStand.Id,
                Location = updateStand.Location,
                Description = updateStand.Description,
                Max_Customer_Per_Hour = updateStand.Max_Customer_Per_Hour,
                Min_Customer_Pre_Hour = updateStand.Min_Customer_Pre_Hour,
                Average_Cookies_Per_Sale = updateStand.Average_Cookies_Per_Sale,
                Owner = updateStand.Owner,
                Hour = HourSale
            };

            return cookiesDTO;
        }

        public Task Delete(int id)
        {
            var stand = _db.CookiesStand.Find(id);
            if (stand == null)
                return null;
            _db.CookiesStand.Remove(stand);
            _db.SaveChanges();
            return Task.CompletedTask;

        }
    }
    }

