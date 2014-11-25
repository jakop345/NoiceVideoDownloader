using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Google.Apis;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;


namespace NoiceVideoDownloader
{
    public class SearchProvider
    {
        // 

        private ObservableCollection<SearchResultItem> _search_results = new ObservableCollection<SearchResultItem>();
        public ObservableCollection<SearchResultItem> SearchResult
        {
            get { return _search_results;}
        }
        
        // start search 
        public void StartSearch(String searchkey)
        {
            //  get the first search result
            //  
            _search_results.Clear();
            GetResults(searchkey);
        
        }

        //static String youtube_api_key="AIzaSyDVdZNJix4ByadiBmVKL7VrjwtO-v429PI";

        public void GetResults(String searchkey)
        {

           
            new SearchProvider().Run().Wait();
            /*
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "Google"; // Replace with your search term.
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
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        break;

                    case "youtube#channel":
                        channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                        break;

                    case "youtube#playlist":
                        playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                        break;
                }
            }

            Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
            Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
            Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));

            // !!!!!!!!!!!!!!!!!! run in main theread

            YouTubeRequestSettings settings = new YouTubeRequestSettings("example app", "eee", youtube_api_key);
            YouTubeRequest request = new YouTubeRequest(settings);

            // Create a request for the URL. 		
            /*
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            */

        }


        // http://gdata.youtube.com/feeds/api/videos/qHDDcpO4V_A
        public async Task Run()
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyDVdZNJix4ByadiBmVKL7VrjwtO-v429PI",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = "boobs car"; // Replace with your search term.
            searchListRequest.MaxResults = 50;
            try
            {
                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = await searchListRequest.ExecuteAsync();
                foreach (var searchResult in searchListResponse.Items)
                {
                    if (searchResult.Id.Kind == "youtube#video")
                    {
                        var sResult = new SearchResultItem();
                        sResult.ThumbnailURL = searchResult.Snippet.Thumbnails.Default.Url;
                        sResult.Title        = searchResult.Snippet.Title;
                        sResult.Discripion   = searchResult.Snippet.Description;
                        App.SearchProvider.SearchResult.Add(sResult);
                        //SearchResult.Add(sResult);
                    }
                }
/*


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
                            videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                            break;

                        case "youtube#channel":
                            channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                            break;

                        case "youtube#playlist":
                            playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                            break;
                    }
                }
                Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
                Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
                Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
 */
            }
            catch (Exception e)
            {
                
            }

         
        }
    }
}
