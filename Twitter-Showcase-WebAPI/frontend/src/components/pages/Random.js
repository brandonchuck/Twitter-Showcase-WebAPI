import axios from "axios";
import React, { useState } from "react";
import TweetsList from "../TweetsList";
import { Container, Row, Col } from "react-bootstrap";

const Random = () => {
  const [randomTweets, setRandomTweets] = useState([]);

  // NFT Accounts
  // Make function for grabbing pfp also if you want to change?
  const USER_1 = "garyvee";
  const USER_2 = "shanicucic96";
  const USER_3 = "DystoApez";
  const USER_4 = "PGodjira";
  const USER_5 = "AbsoluteSaltETH";

  async function getRandomTweets(e) {
    e.preventDefault();
    let res = await axios.get(
      `api/tweets/search/random?user=${e.target.value}`
    );
    setRandomTweets(res.data);
  }

  return (
    <Container>
      <Row>
        <Col>
          <input
            className="user"
            type="image"
            alt="user1"
            src="https://pbs.twimg.com/profile_images/1268176490979561472/aorwOh3s_normal.jpg"
            value={`${USER_1}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <input
            className="user"
            type="image"
            alt="user2"
            src="https://pbs.twimg.com/profile_images/1470891016790052865/9Bat2HMQ_normal.jpg"
            value={`${USER_2}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <input
            className="user"
            type="image"
            alt="user3"
            src="https://pbs.twimg.com/profile_images/1484414951032868867/6pUgEraw_normal.jpg"
            value={`${USER_3}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <input
            className="user"
            type="image"
            alt="user4"
            src="https://pbs.twimg.com/profile_images/1486998994371121153/7frJOAEP_normal.jpg"
            value={`${USER_4}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <input
            className="user"
            type="image"
            alt="user5"
            src="https://pbs.twimg.com/profile_images/1486137594467471364/3IAXbv9Z_normal.jpg"
            value={`${USER_5}`}
            onClick={(e) => getRandomTweets(e)}
          />
        </Col>
      </Row>
      <TweetsList tweets={randomTweets} />
    </Container>
  );
};

export default Random;
