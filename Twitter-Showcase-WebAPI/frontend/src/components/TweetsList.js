import React from "react";
import TweetCard from "./TweetCard";
// import axios from "axios";

const TweetsList = ({ tweetsList }) => {
  // search endpoint should return an object that has the following data:
  // 1. screen name
  // 2. user name
  // 3. profile pic
  // 4. create_at
  // 5. text
  // 6. attachments (url(photos), or preview_image_url(videos))
  // 7. # comments, retweets, likes

  // 1. Send searchTerm to the backendvia url parmeters
  // 2. Get user_id using https://api.twitter.com/2/users/by/username?username=${searchTerm}
  // 3. If this returns and error code of 400, then make the search/recent/ api call instead
  // 4. Make api call for recent content using https://api.twitter.com/2/tweets/search/recent/?query=${searchTerm}
  // 5. Otherwise, if no errors, get 10 tweets from timeline using https://api.twitter.com/2/users/id?=${user_id}/tweets

  return (
    <div style={{ background: "red" }}>
      {/* <h1> I will return 10 relevant Tweet Cards!</h1>
      {tweetsList.map((tweetObject) => {
        {
          <TweetCard />;
        }
      })} */}
    </div>
  );
};

export default TweetsList;
