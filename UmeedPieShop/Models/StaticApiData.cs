using Newtonsoft.Json;

namespace UmeedPieShop.Models
{
    public class StaticApiData
    {
        public static async Task<IEnumerable<Pie>> GetApiPieData(string ApiAddress)
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

        public static async Task<IEnumerable<Category>> GetApiCategoryData(string ApiAddress)
        {
            IEnumerable<Category> category = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(ApiAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<IEnumerable<Category>>(apiResponse);
                }
            }
            return category;
        }
    }
}
