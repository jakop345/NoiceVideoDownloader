using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Google.Apis;
using Google.YouTube;


namespace NoiceVideoDownloader
{
    public class SearchProvider
    {
        // 
        ObservableCollection<SearchResultItem> _search_results = new ObservableCollection<SearchResultItem>();
        
        // start search 
        public void StartSearch(String searchkey)
        {
            //  get the first search result
            //  
            _search_results.Clear();
            GetResults(searchkey);
        
        }

        static String youtube_api_key="AIzaSyDVdZNJix4ByadiBmVKL7VrjwtO-v429PI";

        public void GetResults(String searchkey)
        {
            // !!!!!!!!!!!!!!!!!! run in main theread

            YouTubeRequestSettings settings = new YouTubeRequestSettings("example app", "eee", youtube_api_key);
            YouTubeRequest request = new YouTubeRequest(settings);

            // Create a request for the URL. 		
            
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


        }
        

    }
}
