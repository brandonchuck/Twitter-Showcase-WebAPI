import { useState } from "react";
import TweetsList from "../TweetsList";
import ErrorCard from "../ErrorCard";
import axios from "axios";
import { Container, Row, Col, Form } from "react-bootstrap";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [searchChoice, setSearchChoice] = useState("Handle");
  const [errorMessage, setErrorMessage] = useState("");
  const [userHandleBtnClass, setUserHandleBtnClass] = useState("active");
  const [contentBtnClass, setContentBtnClass] = useState("");

  async function getTweets(e) {
    e.preventDefault();

    if (searchChoice === "Handle") {
      await axios
        .get(`api/tweets/search/username?searchTerm=${searchTerm}`)
        .then((res) => {
          setTweets(res.data);
          setErrorMessage("");
        })
        .catch((err) => {
          if (err.response.status >= 400) {
            setErrorMessage(err.response.data);
          }
        });
    } else {
      await axios
        .get(`api/tweets/search/content?searchTerm=${searchTerm}`)
        .then((res) => {
          setTweets(res.data);
          setErrorMessage("");
        })
        .catch((err) => {
          if (err.response.status >= 400) {
            setErrorMessage(err.response.data);
          }
        });
    }
    setSearchTerm("");
  }

  function toggleActiveStatus(e) {
    if (
      e.target.textContent === "Handle" &&
      !e.target.classList.contains("active")
    ) {
      setUserHandleBtnClass("active");
      setContentBtnClass("");
    }

    if (
      e.target.textContent === "Content" &&
      !e.target.classList.contains("active")
    ) {
      setUserHandleBtnClass("");
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
                value={searchTerm}
                placeholder="Search"
              />
              <button
                className="btn btn-primary form-control"
                id="search-btn"
                type="submit"
                onClick={(e) => getTweets(e)}
                disabled={!searchTerm}
              >
                Search
              </button>
              <div className="btn-group">
                <button
                  type="button"
                  className={`btn btn-secondary search-selector ${userHandleBtnClass}`}
                  id="username-btn"
                  onClick={(e) => {
                    setSearchChoice(e.target.textContent);
                    toggleActiveStatus(e);
                  }}
                >
                  Handle
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
