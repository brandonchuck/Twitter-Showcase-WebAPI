import { useState, useEffect } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweetResponse, setTweetResponse] = useState();
  const [searchChoice, setSearchChoice] = useState("Username");

  useEffect(() => {
    console.log(tweetResponse);
  }, [tweetResponse]);

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
    // console.log(typeof res.data.includes);
    setTweetResponse(res.data); // passing the axios "data"
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
