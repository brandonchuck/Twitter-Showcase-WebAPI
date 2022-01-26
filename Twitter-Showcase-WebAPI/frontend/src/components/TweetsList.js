import React from "react";
// import axios from "axios";

const TweetsList = ({ tweetResponse }) => {
  return (
    <>
      <div>{tweetResponse && console.log(tweetResponse)}</div>
      <div>
        {tweetResponse &&
          tweetResponse.data.map((tweet) => {
            return <div key={tweet.id}>{tweet.text}</div>;
          })}

        {tweetResponse &&
          tweetResponse.includes.users.map((tweet, index) => {
            return <div key={index}>{tweet.username}</div>;
          })}
      </div>
    </>
  );
};

export default TweetsList;
