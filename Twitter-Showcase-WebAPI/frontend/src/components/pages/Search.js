import { useState } from "react";
import TweetsList from "../TweetsList";
import ErrorCard from "../ErrorCard";
import axios from "axios";
import { Container, Row, Col, Form } from "react-bootstrap";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [searchChoice, setSearchChoice] = useState("Username");
  const [errorMessage, setErrorMessage] = useState("");
  const [usernameBtnClass, setUsernameBtnClass] = useState("active");
  const [contentBtnClass, setContentBtnClass] = useState("");

  async function getTweets(e) {
    e.preventDefault();

    if (searchChoice === "Username") {
      await axios
        .get(`api/tweets/search/username?searchTerm=${searchTerm}`)
        .then((res) => setTweets(res.data))
        .catch((err) => {
          if (err.response.status >= 400) {
            console.log(err.response);
            setErrorMessage(err.response.data);
          }
        });
    } else {
      await axios
        .get(`api/tweets/search/content?searchTerm=${searchTerm}`)
        .then((res) => setTweets(res.data))
        .catch((err) => {
          if (err.response.status >= 400) {
            console.log(err.response);
            setErrorMessage(err.response.data);
          }
        });
    }
  }

  function toggleActiveStatus(e) {
    if (
      e.target.textContent === "Username" &&
      !e.target.classList.contains("active")
    ) {
      setUsernameBtnClass("active");
      setContentBtnClass("");
    }

    if (
      e.target.textContent === "Content" &&
      !e.target.classList.contains("active")
    ) {
      setUsernameBtnClass("");
      setContentBtnClass("active");
    }
  }

  return (
    <Container className="search-container">
      <h1 className="search-title">Search Tweets</h1>
      <Container className="form-container">
        <Form>
          <Row>
            <Col className="search-bar-col">
              <input
                className="form-control search-bar"
                type="text"
                onChange={(e) => setSearchTerm(e.target.value)}
                placeholder="Search"
              />
              <button
                className="btn btn-primary form-control search-btn"
                type="submit"
                onClick={(e) => getTweets(e)}
                disabled={!searchTerm}
              >
                Search
              </button>
              <div className=" btn btn-group" role="group">
                <button
                  type="button"
                  className={`btn btn-secondary search-selector ${usernameBtnClass}`}
                  id="username-btn"
                  onClick={(e) => {
                    setSearchChoice(e.target.textContent);
                    toggleActiveStatus(e);
                  }}
                >
                  Username
                </button>
                <button
                  type="button"
                  className={`btn btn-secondary search-selector ${contentBtnClass}`}
                  id="content-btn"
                  onClick={(e) => {
                    setSearchChoice(e.target.textContent);
                    toggleActiveStatus(e);
                  }}
                >
                  Content
                </button>
              </div>
            </Col>
          </Row>
        </Form>
      </Container>
      {errorMessage ? (
        <ErrorCard errorMessage={errorMessage} />
      ) : (
        <TweetsList tweets={tweets} />
      )}
    </Container>
  );
};

export default Search;
