using System;
using System.Collections.Generic;
using System.Linq;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class FormatTweetService : IFormatTweetService
    {

        public List<TweetObject> GetTweets(UserTimeline timeline)
        {
            var tweets = timeline.data.Select(x => {

                TweetObject tweet = new TweetObject
                {
                    Text = x.text,
                    CreatedAt = x.created_at,
                    LikeCount = x.public_metrics.like_count,
                    RetweetCount = x.public_metrics.retweet_count,
                    CommentCount = x.public_metrics.reply_count,
                };

                UserData currentUser = this.GetCurrentUser(timeline, x);

                // set ScreenName and Username for tweet object
                tweet.ScreenName = currentUser.name;
                tweet.Username = currentUser.username;
                tweet.ProfileImageUrl = currentUser.profile_image_url;

                // set vidoePreviewImageUrls and ImageUrls
                this.SetVideoAndImageUrls(timeline, x, tweet);
            });

            return tweets;
        }

        public UserData GetCurrentUser(UserTimeline timeline, TweetData currentTweet)
        {
            UserData currentUser = timeline.includes.users.First(user =>
            {
                return user.id == currentTweet.id;
            });

            return currentUser;
        }


        public void SetVideoAndImageUrls(UserTimeline timeline, TweetData data, TweetObject tweet)
        {
            if (data.attachments != null)
            {
                // loop through each media_key in attachments.media_keys
                foreach (string key in data.attachments.media_keys)
                {
                    // loop through each media_key in includes.media
                    foreach (MediaData m in timeline.includes.media)
                    {
                        // check if these keys match for the current tweet object
                        if (m.media_key == key)
                        {
                            if (m.type == "photo")
                            {
                                tweet.ImageUrls.Add(m.url);
                            }

                            if (m.type == "video")
                            {
                                tweet.VideoPreviewImageUrls.Add(m.preview_image_url);
                            }
                        }
                    }
                }
            }
            else
            {
                tweet.ImageUrls.Add(string.Empty);
                tweet.VideoPreviewImageUrls.Add(string.Empty);
            }
        }
    }
}
