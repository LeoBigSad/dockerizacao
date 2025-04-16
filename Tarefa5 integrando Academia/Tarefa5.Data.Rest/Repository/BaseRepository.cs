﻿using Microsoft.AspNetCore.Http.HttpResults;
using RestSharp;

namespace Tarefa5.Data.Rest.Repository
{
    public class BaseRepository
    {
        private readonly RestClient _client;

        public BaseRepository(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }
        public async Task<T> GetAsync<T>(string endpoint) where T : new()
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful || response.Data == null)
                throw new Exception($"Request failed: {response.ErrorMessage}");

            return response.Data;
        }
        public async Task<T> PostAsync<T>(string endpoint, object body) where T : new()
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(body);
            var response = await _client.ExecuteAsync<T>(request);
            if (!response.IsSuccessful || response.Data == null)
                throw new Exception($"Request failed: {response.ErrorMessage}");
            return response.Data;
        }
        public async Task<T> PutAsync<T>(string endpoint, object body) where T : new()
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(body);
            var response = await _client.ExecuteAsync<T>(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Request failed: {response.ErrorMessage}");
            return response.Data;
        }
        public async Task<bool> DeleteAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            var response = await _client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                throw new Exception($"Request failed: {response.ErrorMessage}");
            return response.IsSuccessful;
        }
    }
}
