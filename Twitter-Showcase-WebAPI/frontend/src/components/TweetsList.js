import React from "react";
import { Container } from "react-bootstrap";
import TweetCard from "./TweetCard";

const TweetsList = ({ tweets }) => {
  return (
    <Container className="tweet-feed">
      {tweets && console.log(tweets)}

      {tweets &&
        tweets.map((tweet, index) => {
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
