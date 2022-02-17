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

  let profilePicture_USER1 = getProfilePictures(USER_1);

  async function getRandomTweets(e) {
    e.preventDefault();
    let res = await axios.get(
      `api/tweets/search/random?user=${e.target.value}`
    );
    setRandomTweets(res.data);
  }

  async function getProfilePictures(username) {
    let res = await axios.get(
      `api/tweets/search/random/profile-picture?username=${username}`
    );

    console.log(res.data);
    let profilePicture = res.data.includes.users[0].profile_image_url;
    console.log(profilePicture);
    console.log(typeof profilePicture);
    return profilePicture;
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
            src={profilePicture_USER1}
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
            src={getProfilePictures(USER_2)}
            // value={`${USER_2}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-2">
            {USER_2}
          </label>
        </Col>
        <Col>
          <input
            className="user"
            id="user-3"
            type="image"
            alt="user3"
            src={`${getProfilePictures(USER_3)}`}
            value={`${USER_3}`}
            onClick={(e) => getRandomTweets(e)}
          />
          <label className="user-label" htmlFor="user-3">
            {USER_3}
          </label>
        </Col>
        <Col>
          <input
            className="user"
            id="user-4"
            type="image"
            alt="user4"
            src={getProfilePictures(USER_4)}
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
            src={getProfilePictures(USER_5)}
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
