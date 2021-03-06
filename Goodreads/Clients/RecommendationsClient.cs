﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Goodreads.Http;
using Goodreads.Models.Response;
using RestSharp;

namespace Goodreads.Clients
{
    /// <summary>
    /// API client for the recommendation endpoint.
    /// </summary>
    public class RecommendationsClient : IRecommendationsClient
    {
        private readonly IConnection Connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendationsClient"/> class.
        /// </summary>
        /// <param name="connection">A RestClient connection to the Goodreads API.</param>
        public RecommendationsClient(IConnection connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// Get information about a particular recommendation that one user made for another
        /// Includes comments and likes.
        /// </summary>
        /// <param name="id">A desire recommendation unique identifier.</param>
        /// <returns>A full information about desire recommendation.</returns>
        public async Task<Recommendation> GetRecommendation(int id)
        {
            var endpoint = $"recommendations/{id}";
            var parameters = new List<Parameter>();

            return await Connection.ExecuteRequest<Recommendation>(endpoint, parameters, null, "recommendation");
        }
    }
}
