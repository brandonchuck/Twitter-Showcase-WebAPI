import React from "react";
import { Container } from "react-bootstrap";
import TweetCard from "./TweetCard";

const TweetsList = ({ tweetResponse }) => {
  return (
    <Container>
      {tweetResponse && console.log(tweetResponse)}

      {tweetResponse &&
        tweetResponse.map((tweet, index) => {
          return (
            <div className="tweet-card-container" key={index}>
              <TweetCard tweet={tweet} />
            </div>
          );
        })}
    </Container>
  );
};

export default TweetsList;
