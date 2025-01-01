﻿using System.IO;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace Service
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    [ServiceKnownType(typeof (Rss20FeedFormatter))]
    public interface IYoutubeFeed
    {
        [OperationContract]
        [WebGet(
            UriTemplate = "GetUserFeed?userId={userId}&encoding={encoding}&maxLength={maxLength}&isPopular={isPopular}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        Task<SyndicationFeedFormatter> GetUserFeedAsync(
            string userId,
            string encoding,
            int maxLength,
            bool isPopular);

        [OperationContract]
        [WebGet(
            UriTemplate =
                "GetPlaylistFeed?playlistId={playlistId}&encoding={encoding}&maxLength={maxLength}&isPopular={isPopular}",
            BodyStyle = WebMessageBodyStyle.Bare)]
        Task<SyndicationFeedFormatter> GetPlaylistFeedAsync(
            string playlistId,
            string encoding,
            int maxLength,
            bool isPopular);

        [OperationContract]
        [WebGet(UriTemplate = "Video.mp4?videoId={videoId}&encoding={encoding}")]
        Stream GetVideoAsync(string videoId, string encoding);

        [OperationContract]
        [WebGet(UriTemplate = "Audio.m4a?videoId={videoId}")]
        Task GetAudioAsync(string videoId);
    }
}