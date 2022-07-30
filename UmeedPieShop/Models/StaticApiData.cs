using Newtonsoft.Json;

namespace UmeedPieShop.Models
{
    public class StaticApiData
    {
        public static async Task<IEnumerable<Pie>> GetApiData(string ApiAddress)
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            return pies;
        }
    }
}
