﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PersentationLayer.Models
{
    public class RestClient : IDisposable
    {
        /// <summary>
        /// The client
        /// </summary>
        private HttpClient client;
        public const string ApiUri = "http://localhost:52133/";
        /// <summary>
        /// Media type used for send data in API
        /// </summary>
        public const string MediaTypeJson = "application/json";

        /// <summary>
        /// Media type used for send data in API
        /// </summary>
        public const string MediaTypeXML = "application/XML";

        public const string RequestMsg = "Request has not been processed";
        public static string ReasonPhrase { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestClient"/> class.
        /// </summary>
        public RestClient()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(ApiUri);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeJson));
        }

        /// <summary>
        /// Runs the asynchronous get all.
        /// </summary>
        /// <typeparam name="T">The Entity input type</typeparam>
        /// <typeparam name="U">The Entity return type</typeparam>
        /// <param name="uri">The URI.</param>
        /// <returns>The List.</returns>
        /// <exception cref="ApplicationException">throw exception</exception>
        /// <exception cref="Exception">throw exception
        /// </exception>
        public async Task<List<U>> RunAsyncGetAll<T, U>(dynamic uri)
        {
            HttpResponseMessage response = await this.client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<U>>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }

            throw new Exception(RequestMsg);
        }

        /// <summary>
        /// Runs the asynchronous get.
        /// </summary>
        /// <typeparam name="T">The Entity input type</typeparam>
        /// <typeparam name="U">The Entity return type</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="data">The data.</param>
        /// <returns>The List.</returns>
        /// <exception cref="ApplicationException">throw exception</exception>
        /// <exception cref="Exception">throw exception
        /// </exception>
        public async Task<List<U>> RunAsyncGet<T, U>(dynamic uri, dynamic data)
        {
            HttpResponseMessage response = await this.client.GetAsync(uri + "/" + data);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<U>>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }

            throw new Exception(RequestMsg);
        }

        /// <summary>
        /// Runs the asynchronous post.
        /// </summary>
        /// <typeparam name="T">The Entity input type</typeparam>
        /// <typeparam name="U">The Entity return type</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>The Type.</returns>
        /// <exception cref="ApplicationException">throw exception</exception>
        /// <exception cref="Exception">throw exception
        /// </exception>
        public async Task<U> RunAsyncPost<T, U>(string uri, T entity)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(uri, entity).Result;
            ReasonPhrase = response.ReasonPhrase;
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<U>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }

            throw new Exception(RequestMsg);
        }

        /// <summary>
        /// Runs the asynchronous put.
        /// </summary>
        /// <typeparam name="T">The Entity input type</typeparam>
        /// <typeparam name="U">The Entity return type</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>The Type.</returns>
        /// <exception cref="ApplicationException">throw exception</exception>
        /// <exception cref="Exception">throw exception
        /// </exception>
        public async Task<U> RunAsyncPut<T, U>(string uri, T entity)
        {
            HttpResponseMessage response = await this.client.PutAsJsonAsync(uri, entity);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<U>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }

            throw new Exception(RequestMsg);
        }

        /// <summary>
        /// Runs the asynchronous delete.
        /// </summary>
        /// <typeparam name="T">The Entity input type</typeparam>
        /// <typeparam name="U">The Entity return type</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The type.</returns>
        /// <exception cref="ApplicationException">throw exception</exception>
        /// <exception cref="Exception">throw exception
        /// </exception>
        public async Task<U> RunAsyncDelete<T, U>(string uri, dynamic id)
        {
            HttpResponseMessage response = await this.client.DeleteAsync(uri + "/" + id);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<U>();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadGateway)
            {
                throw new Exception(response.ReasonPhrase);
            }

            throw new Exception(RequestMsg);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //// dispose managed resources
                this.client.Dispose();
            }
            //// free native resources
        }
    }
}