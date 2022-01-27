import React from "react";
// import axios from "axios";

const TweetsList = ({ tweetResponse }) => {
  return (
    <div>
      {tweetResponse &&
        tweetResponse.data.map((tweet, index) => {
          return <div key={index}>{tweet.text}</div>;
        })}
      {console.log(tweetResponse)}
    </div>
  );
};

export default TweetsList;
