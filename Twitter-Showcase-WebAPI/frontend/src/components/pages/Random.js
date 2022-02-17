import axios from "axios";
import React, { useState } from "react";
import TweetsList from "../TweetsList";
import { Container, Row, Col } from "react-bootstrap";

const Random = () => {
  const [randomTweets, setRandomTweets] = useState([]);

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

  async function getProfilePictures(username) {
    let res = await axios.get(`api/tweets/search/random?username=${username}`);
    return res.data;
  }

  return (
    <Container className="random-user-container">
      <Row className="random-user-header">
        <Col>
          <input
            className="user"
            id="user-1"
            type="image"
            alt="user1"
            src="https://pbs.twimg.com/profile_images/1268176490979561472/aorwOh3s_normal.jpg"
            value={`${USER_1}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-1">
            Gary V
          </label>
        </Col>
        <Col>
          <input
            className="user"
            id="user-2"
            type="image"
            alt="user2"
            src="https://pbs.twimg.com/profile_images/1470891016790052865/9Bat2HMQ_normal.jpg"
            value={`${USER_2}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-2">
            Shan
          </label>
        </Col>
        <Col>
          <input
            className="user"
            id="user-3"
            type="image"
            alt="user3"
            src="https://pbs.twimg.com/profile_images/1484414951032868867/6pUgEraw_normal.jpg"
            value={`${USER_3}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-3">
            Dysto Apez
          </label>
        </Col>
        <Col>
          <input
            className="user"
            id="user-4"
            type="image"
            alt="user4"
            src="https://pbs.twimg.com/profile_images/1486998994371121153/7frJOAEP_normal.jpg"
            value={`${USER_4}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-4">
            Project Godjira
          </label>
        </Col>
        <Col>
          <input
            className="user"
            id="user-5"
            type="image"
            alt="user5"
            src="https://pbs.twimg.com/profile_images/1489709799206014979/0-m4LrvL_normal.jpg"
            value={`${USER_5}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-5">
            AbsoluteSaltETH
          </label>
        </Col>
      </Row>
      <TweetsList tweets={randomTweets} />
    </Container>
  );
};

export default Random;
