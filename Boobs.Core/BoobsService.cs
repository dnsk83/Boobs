using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Boobs.Core
{
    public enum OrderBy
    {
        Id, 
        RankAsc,
        RankDesc, 
        InterestAsc, 
        InterestDesc, 
        Random
    }

    public class BoobsService
    {
        const string BASE_URL = "http://api.oboobs.ru";

        public async Task<IEnumerable<BoobsDto>> GetBoobsAsync(int offset, int count, OrderBy orderBy = OrderBy.Random)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri($"{BASE_URL}/boobs/{offset}/{count}/{OrderByToString(orderBy)}/");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContent responseContent = response.Content;
                    var json = await responseContent.ReadAsStringAsync();
                    var ret = JsonConvert.DeserializeObject<IEnumerable<BoobsDto>>(json);
                    return ret;
                }
            }
            catch (Exception e )
            {
                throw;
            }
            return null;
        }

        string OrderByToString(OrderBy orderBy)
        {
            // id,rank,-rank,interest,-interest,random
            switch(orderBy)
            {
                case OrderBy.Id:
                    return "id";
                case OrderBy.RankAsc:
                    return "rank";
                case OrderBy.RankDesc:
                    return "-rank";
                case OrderBy.InterestAsc:
                    return "interest";
                case OrderBy.InterestDesc:
                    return "-interest";
                case OrderBy.Random:
                    return "random";
                default:
                    return "random";
            }
        }
    }
}
