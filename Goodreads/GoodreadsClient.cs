﻿using System;
using Goodreads.Clients;
using Goodreads.Http;
using RestSharp;
using RestSharp.Authenticators;

namespace Goodreads
{
    /// <summary>
    /// The client API class for accessing the Goodreads API.
    /// </summary>
    public class GoodreadsClient : IGoodreadsClient
    {
        private readonly string GoodreadsUrl = "https://www.goodreads.com/";

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodreadsClient"/> class.
        /// This constructor doesn't used OAuth permissions and can be used for public methods.
        /// </summary>
        /// <param name="apiKey">Your Goodreads API key.</param>
        /// <param name="apiSecret">Your Goodreads API secret.</param>
        public GoodreadsClient(string apiKey, string apiSecret) : this(apiKey, apiSecret, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodreadsClient"/> class.
        /// Use this constructor if you already have OAuth permissions for the user.
        /// </summary>
        /// <param name="apiKey">Your Goodreads API key.</param>
        /// <param name="apiSecret">Your Goodreads API secret.</param>
        /// <param name="accessToken">The user's OAuth access token.</param>
        /// <param name="accessSecret">The user's OAuth access secret.</param>
        public GoodreadsClient(string apiKey, string apiSecret, string accessToken, string accessSecret)
        {
            var client = new RestClient(new Uri(GoodreadsUrl))
            {
                UserAgent = "goodreads-dotnet"
            };

            client.AddDefaultParameter("key", apiKey, ParameterType.QueryString);
            client.AddDefaultParameter("format", "xml", ParameterType.QueryString);

            var apiCredentials = new ApiCredentials(client, apiKey, apiSecret, accessToken, accessSecret);

            // Setup the OAuth authenticator if they have passed on the appropriate tokens
            if (!string.IsNullOrWhiteSpace(accessToken) &&
                !string.IsNullOrWhiteSpace(accessSecret))
            {
                client.Authenticator = OAuth1Authenticator.ForProtectedResource(
                    apiKey, apiSecret, accessToken, accessSecret);
            }

            Connection = new Connection(client, apiCredentials);
            Authors = new AuthorsClient(Connection);
            Books = new BooksClient(Connection);
            Shelves = new ShelvesClient(Connection);
            Users = new UsersClient(Connection);
            Reviews = new ReviewsClient(Connection);
            Series = new SeriesClient(Connection);
            AuthorsFollowing = new AuthorsFollowingClient(Connection);
            Events = new EventsClient(Connection);
            Followers = new FollowersClient(Connection);
            Friends = new FriendsClient(Connection);
            Notifications = new NotificationsClient(Connection);
            Groups = new GroupClient(Connection);
            Quotes = new QuotesClient(Connection);
            UserStatuses = new UserStatusesClient(Connection);
            Updates = new UpdatesClient(Connection);
            Recommendations = new RecommendationsClient(Connection);
            ReadStatuses = new ReadStatusesClient(Connection);
        }

        /// <summary>
        /// The connection to the Goodreads API.
        /// </summary>
        public IConnection Connection { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Authors endpoint.
        /// </summary>
        public IAuthorsClient Authors { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Books endpoint.
        /// </summary>
        public IBooksClient Books { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Shelves endpoint.
        /// </summary>
        public IShelvesClient Shelves { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Users endpoint.
        /// </summary>
        public IUsersClient Users { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Reviews endpoint.
        /// </summary>
        public IReviewsClient Reviews { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Series endpoint.
        /// </summary>
        public ISeriesClient Series { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Author_following endpoint.
        /// </summary>
        public IAuthorsFollowingClient AuthorsFollowing { get; private set; }

        /// <summary>
        /// API Client for the Goodreads Events endpoint.
        /// </summary>
        public IEventsClient Events { get; private set; }

        /// <summary>
        /// API Client for the Goodreads user followers endpoint.
        /// </summary>
        public IFollowersClient Followers { get; private set; }

        /// <summary>
        /// API Client for the Goodreads user friends endpoint.
        /// </summary>
        public IFriendsClient Friends { get; private set; }

        /// <summary>
        /// API Client for the Goodreads notifications endpoint.
        /// </summary>
        public INotificationsClient Notifications { get; private set; }

        /// <summary>
        /// API Client for the Goodreads group endpoint.
        /// </summary>
        public IGroupClient Groups { get; private set; }

        /// <summary>
        /// API Client for the Goodreads group endpoint.
        /// </summary>
        public IQuotesClient Quotes { get; private set; }

        /// <summary>
        /// API Client for the Goodreads user statuses endpoint.
        /// </summary>
        public IUserStatusesClient UserStatuses { get; private set; }

        /// <summary>
        /// API Client for the Goodreads updates endpoint.
        /// </summary>
        public IUpdatesClient Updates { get; private set; }

        /// <summary>
        /// API Client for the Goodreads recommendations endpoint.
        /// </summary>
        public IRecommendationsClient Recommendations { get; private set; }

        /// <summary>
        /// API Client for the Goodreads read status endpoint.
        /// </summary>
        public ReadStatusesClient ReadStatuses { get; private set; }
    }
}
