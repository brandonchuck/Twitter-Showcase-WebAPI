import { useState, useEffect } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweetsList, setTweetsList] = useState("");
  const [searchChoice, setSearchChoice] = useState("Username");

  useEffect(() => {
    console.log(tweetsList);
  }, [tweetsList]);

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
    setTweetsList(res.data);
  }

  return (
    <div>
      <h1>Search Tweets</h1>
      <form>
        <div className="form-row justify-content">
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
      <TweetsList tweetsList={tweetsList} />
    </div>
  );
};

export default Search;
