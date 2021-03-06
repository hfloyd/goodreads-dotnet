﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;
using Goodreads.Extensions;

namespace Goodreads.Models.Response
{
    /// <summary>
    /// This class models areas of the API where Goodreads returns
    /// information about events.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class GoodreadsEvent : ApiResponse
    {
        /// <summary>
        /// The Goodreads Event Id.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// The Goodreads User Id.
        /// </summary>
        public int UserId { get; protected set; }

        /// <summary>
        /// The event title.
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// The event address.
        /// </summary>
        public string Address { get; protected set; }

        /// <summary>
        /// The event city.
        /// </summary>
        public string City { get; protected set; }

        /// <summary>
        /// The event postal code.
        /// </summary>
        public int? PostalCode { get; protected set; }

        /// <summary>
        /// The event country code.
        /// </summary>
        public string CountryCode { get; protected set; }

        /// <summary>
        /// The event start date.
        /// </summary>
        public DateTime? StartDate { get; protected set; }

        /// <summary>
        /// The event updated date.
        /// </summary>
        public DateTime? UpdatedDate { get; protected set; }

        /// <summary>
        /// The event created date.
        /// </summary>
        public DateTime? CreatedDate { get; protected set; }

        /// <summary>
        /// The event state code.
        /// </summary>
        public string StateCode { get; protected set; }

        /// <summary>
        /// The event resource Id.
        /// </summary>
        public int ResourceId { get; protected set; }

        /// <summary>
        /// The event resource type.
        /// </summary>
        public string ResourceType { get; protected set; }

        /// <summary>
        /// Determine an event public or not.
        /// </summary>
        public bool IsPublic { get; protected set; }

        /// <summary>
        /// The event venue.
        /// </summary>
        public string Venue { get; protected set; }

        /// <summary>
        /// The event access.
        /// </summary>
        public string Access { get; protected set; }

        /// <summary>
        /// The event source.
        /// </summary>
        public string Source { get; protected set; }

        /// <summary>
        /// The event source url.
        /// </summary>
        public string SourceUrl { get; protected set; }

        /// <summary>
        /// The event responses count.
        /// </summary>
        public int ResponsesCount { get; protected set; }

        /// <summary>
        /// The event attending count.
        /// </summary>
        public int AttendingCount { get; protected set; }

        /// <summary>
        /// Determine ability for inviting to event.
        /// </summary>
        public bool CanInvite { get; protected set; }

        /// <summary>
        /// The event reminder date.
        /// </summary>
        public DateTime? ReminderDate { get; protected set; }

        /// <summary>
        /// The event type.
        /// </summary>
        public string EventType { get; protected set; }

        /// <summary>
        /// The event RSVP date.
        /// </summary>
        public DateTime? RsvpDate { get; protected set; }

        /// <summary>
        /// The event end date.
        /// </summary>
        public DateTime? EndDate { get; protected set; }

        /// <summary>
        /// The cover image for this event.
        /// </summary>
        public string ImageUrl { get; protected set; }

        /// <summary>
        /// The Url to the event page.
        /// </summary>
        public string Link { get; protected set; }

        /// <summary>
        /// The event description.
        /// </summary>
        public string Description { get; protected set; }

        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "EventId: Id: {0}, Title: {1},",
                    Id,
                    Title);
            }
        }

        internal override void Parse(XElement element)
        {
            Id = element.ElementAsInt("id");
            UserId = element.ElementAsInt("user_id");
            Title = element.ElementAsString("title");
            Address = element.ElementAsString("address");
            City = element.ElementAsString("city");
            PostalCode = element.ElementAsNullableInt("postal_code");
            CountryCode = element.ElementAsString("country_code");
            StartDate = element.ElementAsDateTime("start_at");
            UpdatedDate = element.ElementAsDateTime("updated_at");
            CreatedDate = element.ElementAsDateTime("created_at");
            StateCode = element.ElementAsString("state_code");
            ResourceId = element.ElementAsInt("resource_id");
            ResourceType = element.ElementAsString("resource_type");
            IsPublic = element.ElementAsInt("public_flag") == 1;
            Venue = element.ElementAsString("venue");
            Access = element.ElementAsString("access");
            Source = element.ElementAsString("source");
            SourceUrl = element.ElementAsString("source_url");
            ResponsesCount = element.ElementAsInt("event_responses_count");
            AttendingCount = element.ElementAsInt("event_attending_count");
            CanInvite = element.ElementAsBool("can_invite_flag");
            ReminderDate = element.ElementAsDateTime("reminder_at");
            RsvpDate = element.ElementAsDateTime("rsvp_end_at");
            EndDate = element.ElementAsDateTime("end_at");
            ImageUrl = element.ElementAsString("image_url");
            Link = element.ElementAsString("link");
            Description = element.ElementAsString("description");
        }
    }
}
