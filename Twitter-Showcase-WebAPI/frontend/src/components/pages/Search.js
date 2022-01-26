import { useState, useEffect } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";
import { TweetObject } from "../../TweetObject";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweetResponse, setTweetResponse] = useState("");
  const [searchChoice, setSearchChoice] = useState("Username");

  async function getTweets(e) {
    e.preventDefault();
    let res;

    if (searchChoice === "Username") {
      res = await axios.get(
        `api/tweets/search/username?searchTerm=${searchTerm}`
      );
    } else {
      res = await axios.get(
        `api/tweets/search/content?searchTerm=${searchTerm}`
      );
    }
    setTweetResponse(res.data);
    createTweetList(res.data);
  }

  function createTweetList(data) {
    let text;
    let createdAt;
    let retweetCount;
    let replyCount;
    let likeCount;
    let mediaKeys;

    let profileImageUrl;
    let username;
    let screenName;

    let videoPreviewImageUrl;
    let imageUrl;

    const tweetList = [];

    let dataArray = data.data;
    let includes = data.includes;

    for (let i = 0; i < dataArray.length; i++) {
      text = dataArray[i].text;
      createdAt = dataArray[i].created_at;
      retweetCount = dataArray[i].public_metrics.retweet_count;
      replyCount = dataArray[i].public_metrics.reply_count;
      likeCount = dataArray[i].public_metrics.like_count;

      if (dataArray[i].attachments !== null) {
        mediaKeys = dataArray[i].attachments.media_keys;
      }

      let currentUserInfo = includes.users.find((user) => {
        return user.id === dataArray[i].author_id;
      });
      username = currentUserInfo.username;
      profileImageUrl = currentUserInfo.profile_image_url;
      screenName = currentUserInfo.name;

      // let tweet = new TweetObject(
      //   text,
      //   username,
      //   screenName,
      //   createdAt,
      //   retweetCount,
      //   replyCount,
      //   likeCount,
      //   profileImageUrl,
      //   videoPreviewImageUrl,
      //   imageUrl
      // );

      // add tweet to tweetlist
      // tweetList.push(tweet);

      console.log(mediaKeys);
      console.log(retweetCount);
      console.log(likeCount);
      console.log(replyCount);
      console.log(text);
      console.log(createdAt);
      console.log(screenName);
      console.log(username);
      console.log(profileImageUrl);
    }
  }

  return (
    <div>
      <h1>Search Tweets</h1>
      <form>
        <div className="form-row">
          <div className="col-auto">
            <input
              className="form-control"
              type="text"
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </div>
          <div className="col-auto">
            <button
              className="btn btn-primary form-control"
              type="submit"
              onClick={(e) => getTweets(e)}
              disabled={!searchTerm}
            >
              Search
            </button>
          </div>
          <div className="btn-group" role="group">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={(e) => setSearchChoice(e.target.textContent)}
            >
              Username
            </button>
            <button
              type="button"
              className="btn btn-secondary"
              onClick={(e) => setSearchChoice(e.target.textContent)}
            >
              Content
            </button>
          </div>
        </div>
      </form>
      <div>
        <TweetsList tweetResponse={tweetResponse} />
      </div>
    </div>
  );
};

export default Search;
