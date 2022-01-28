import React from "react";

const TweetsList = ({ tweetResponse }) => {
  return (
    <div>
      {/* {tweetResponse &&
        tweetResponse.data.map((tweet, index) => {
          return <div key={index}>{tweet.text}</div>;
        })} */}
      {tweetResponse && console.log(tweetResponse)}
    </div>
  );
};

export default TweetsList;
