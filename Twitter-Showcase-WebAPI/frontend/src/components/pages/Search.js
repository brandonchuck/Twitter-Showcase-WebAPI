import { useState, useEffect } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";

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
    // const tweets = createTweetList(res.data);
    setTweetResponse(res.data);
  }

  function createTweetList(data) {
    let text;
    let createdAt;
    let retweetCount;
    let replyCount;
    let likeCount;

    let profileImageUrl;
    let username;
    let screenName;

    let videoPreviewImageUrl;
    let imageUrl;

    const tweetList = [];

    let dataArray = data.data;
    let includes = data.includes;

    for (let i = 0; i < dataArray; i++) {
      text = dataArray[i].text;
      createdAt = dataArray[i].createdAt;
      retweetCount = dataArray[i].public_metrics.retweet_count;
      replyCount = dataArray[i].public_metrics.reply_count;
      likeCount = dataArray[i].public_metrics.like_count;
      // mediaKeys = dataArray[i].attachments.media_keys; // an array

      username = includes.users[i].username;
      screenName = includes.users[i].name;
      profileImageUrl = includes.users[i].profile_image_url;

      videoPreviewImageUrl = includes.media[i];
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
