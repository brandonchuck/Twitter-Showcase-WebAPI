﻿using System;
using System.Collections.Generic;
using System.Linq;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class FormatTweetService : IFormatTweetService
    {

        public List<TweetObject> GetTweets(UserTimeline timeline)
        {
            List<TweetObject> tweets = timeline.data.Select(x =>
            {
                UserData currentUser = this.GetCurrentUser(timeline, x);

                List<string> images = new List<string>();
                List<string> videos = new List<string>();

                this.SetVideoAndImageUrls(timeline, x, images, videos);

                TweetObject tweet = new TweetObject(x.text, FormatDate(x.created_at), x.public_metrics.like_count, x.public_metrics.reply_count, x.public_metrics.retweet_count, currentUser.profile_image_url, currentUser.name, currentUser.username, images, videos);
                return tweet;
            }).ToList();

            return tweets;
        }

        public UserData GetCurrentUser(UserTimeline timeline, TweetData currentTweet)
        {
            UserData currentUser = timeline.includes.users.First(user => user.id == currentTweet.author_id);
            return currentUser;
        }


        public void SetVideoAndImageUrls(UserTimeline timeline, TweetData data, List<string> images, List<string> videos)
        {
            if (data.attachments != null)
            {
                foreach (string key in data.attachments.media_keys)
                {
                    foreach (MediaData m in timeline.includes.media)
                    {
                        if (m.media_key == key)
                        {
                            if (m.type == "photo")
                            {
                                images.Add(m.url);
                            }

                            if (m.type == "video")
                            {
                                videos.Add(m.preview_image_url);
                            }
                        }
                    }
                }
            }
            else
            {
                images = null;
                videos = null;
            }
        }

        public List<TweetObject> GetRandomTweets(UserTimeline timeline)
        {
            List<TweetObject> randomTweets = new List<TweetObject>();

            List<TweetObject> tweets = this.GetTweets(timeline);

            while (randomTweets.Count != 15)
            {
                Random rand = new Random();
                int randomInt = rand.Next(0, tweets.Count);

                if (!randomTweets.Contains(tweets[randomInt]))
                {
                    randomTweets.Add(tweets[randomInt]);
                }
            }

            return randomTweets;

        }

        public string FormatDate(DateTime createdAt)
        {
            return createdAt.ToString("g");
        }
    }
}
