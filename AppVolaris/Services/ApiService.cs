using AppVolaris.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppVolaris.Services
{
    internal class ApiService
    {
        private string ApiUrl = "https://webapivuelo.azurewebsites.net/passager";

        public async Task<ApiResponse> GetDataAsync(string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(ApiUrl)
                };
                var response = await client.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(result);
                }

                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

        public async Task<ApiResponse> PostDataAsync(string controller, object data)
        {
            try
            {
                var serialize = JsonConvert.SerializeObject(data);
                var content = new StringContent(serialize, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(ApiUrl)
                };
                var response = await client.PostAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var json = JsonConvert.DeserializeObject<ApiResponse>(result);
                }

                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = result
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }
        public async Task<ApiResponse> PutDataAsync(string controller, object data)
        {
            try
            {
                var serialize = JsonConvert.SerializeObject(data);
                var content = new StringContent(serialize, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(ApiUrl)
                };
                var response = await client.PutAsync(controller, content);
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(result);
                }

                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse> DeleteDataAsync(string controller, int id)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(ApiUrl)
                };
                var response = await client.DeleteAsync($"{controller}/{id}");
                var result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(result);
                }

                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

    }
}
