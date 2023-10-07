using Api_cookies.DTO;

namespace Api_cookies.Models.Interface
{
    public interface Icookiestand
    {
        Task<List<cookieStandDTO>> GetAll();
        Task<cookieStandDTO> GetById(int id);
        Task<cookieStandDTO> Create(CreateCookieDTO stand);
        Task<cookieStandDTO> Update(int id, CreateCookieDTO stand);
        Task Delete(int id);
        public List<SalesPerHour> GenerateRandom(cookiestand stand);
    }
}
