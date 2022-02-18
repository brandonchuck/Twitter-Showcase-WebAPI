import axios from "axios";
import React, { useEffect, useState } from "react";
import TweetsList from "../TweetsList";
import { Container, Row, Col } from "react-bootstrap";

const Random = () => {
  const [randomTweets, setRandomTweets] = useState([]);
  const [user1Pfp, setUser1Pfp] = useState("");
  const [user2Pfp, setUser2Pfp] = useState("");
  const [user3Pfp, setUser3Pfp] = useState("");
  const [user4Pfp, setUser4Pfp] = useState("");
  const [user5Pfp, setUser5Pfp] = useState("");

  const USER_1 = "garyvee";
  const USER_2 = "shanicucic96";
  const USER_3 = "DystoApez";
  const USER_4 = "PGodjira";
  const USER_5 = "AbsoluteSaltETH";

  useEffect(() => {
    const pfp1 = async (user) => {
      let pfp = await getProfilePictures(user);
      setUser1Pfp(pfp);
    };

    const pfp2 = async (user) => {
      let pfp = await getProfilePictures(user);
      setUser2Pfp(pfp);
    };

    const pfp3 = async (user) => {
      let pfp = await getProfilePictures(user);
      setUser3Pfp(pfp);
    };

    const pfp4 = async (user) => {
      let pfp = await getProfilePictures(user);
      setUser4Pfp(pfp);
    };

    const pfp5 = async (user) => {
      let pfp = await getProfilePictures(user);
      setUser5Pfp(pfp);
    };

    pfp1(USER_1);
    pfp2(USER_2);
    pfp3(USER_3);
    pfp4(USER_4);
    pfp5(USER_5);
  }, []);

  async function getRandomTweets(e) {
    e.preventDefault();
    let res = await axios.get(
      `api/tweets/search/random?user=${e.target.value}`
    );
    setRandomTweets(res.data);
  }

  async function getProfilePictures(username, usernameState) {
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
            src={user1Pfp}
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
            src={user2Pfp}
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
            src={user3Pfp}
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
            src={user4Pfp}
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
            src={user5Pfp}
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
