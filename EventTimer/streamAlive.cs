using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace StreamAlive
{
    namespace Google.Apis.YouTube.Samples
    {
        /// <summary>
        /// YouTube Data API v3 sample: search by keyword.
        /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
        /// See https://developers.google.com/api-client-library/dotnet/get_started
        /// https://github.com/youtube/api-samples/blob/07263305b59a7c3275bc7e925f9ce6cabf774022/dotnet/Search.cs
        ///
        /// Set ApiKey to the API key value from the APIs & auth > Registered apps tab of
        ///   https://cloud.google.com/console
        /// Please ensure that you have enabled the YouTube Data API for your project.
        /// </summary>
        class Search
        {

            public bool streamAlive = false;
            public bool youtubeException = false;
            public string searchString = "https://www.youtube.com/watch?v=Kd-HCiN5joA";

            public async Task Run()
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "your own App Key",
                    ApplicationName = "EventTimer"
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = "Johanneskirche Hersbruck"; /*searchString;*/ // search term.
                searchListRequest.MaxResults = 50;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();

                List<string> videos = new List<string>();
                List<string> channels = new List<string>();
                List<string> playlists = new List<string>();

                // Add each result to the appropriate list, and then display the lists of
                // matching videos, channels, and playlists.
                foreach (var searchResult in searchListResponse.Items)
                {
                    switch (searchResult.Id.Kind)
                    {
                        case "youtube#video":
                            videos.Add(String.Format("{0} ({1})", searchResult.Snippet.LiveBroadcastContent, searchResult.Id.VideoId));
                            break;

                        case "youtube#channel":
                            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.LiveBroadcastContent, searchResult.Id.ChannelId));
                            break;

                        case "youtube#playlist":
                            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                            break;
                    }
                }
                if (channels.Count > 0)
                {
                    if (channels[0].Substring(0, 4) == "live")
                    {
                        streamAlive = true;
                    }
                    else //"none" or "upcoming"
                    {
                        streamAlive = false;
                    }
                }
                //Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
                //Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
                //Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
            }
        }
    }
}
