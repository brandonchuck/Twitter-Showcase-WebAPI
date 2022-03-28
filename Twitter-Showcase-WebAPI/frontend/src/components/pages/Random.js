import axios from "axios";
import React, { useEffect, useState } from "react";
import TweetsList from "../TweetsList";
import { Container, Row, Col } from "react-bootstrap";

const Random = () => {
  const [randomTweets, setRandomTweets] = useState([]);
  const [randomUsers, setRandomUsers] = useState([]);

  useEffect(() => {
    const getUsers = async () => {
      const { data } = await axios.get(
        `api/tweets/search/random/random-user-profiles`
      ); // get list of random UserDetails objects
      setRandomUsers(data);
    };
    getUsers();
  }, []);

  async function handleClick(e) {
    e.preventDefault();
    const { data } = await axios.get(
      `api/tweets/search/random?user=${e.target.value}` // pass user's username to /random endpoint in server
    );
    setRandomTweets(data);
  }

  return (
    <Container className="random-user-container">
      <Row className="random-user-header">
        {randomUsers.map((user) => {
          return (
            <Col key={user.data.id}>
              <input
                className="user"
                id={user.data.id}
                type="image"
                alt={user.data.name}
                src={user.data.profile_image_url}
                value={user.data.username}
                onClick={(e) => handleClick(e)}
              />
              <label className="user-label" htmlFor={user.data.id}>
                {user.data.username}
              </label>
            </Col>
          );
        })}
      </Row>
      <TweetsList tweets={randomTweets} />
    </Container>
  );
};

export default Random;
