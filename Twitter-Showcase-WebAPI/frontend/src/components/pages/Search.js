import { useState } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";
import { Container, Row, Col, Form } from "react-bootstrap";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [searchChoice, setSearchChoice] = useState("Username");

  const usernameBtn = document.getElementById("username-btn");
  const contentBtn = document.getElementById("content-btn");

  async function getTweets(e) {
    e.preventDefault();
    let res;

    if (searchChoice === "Username") {
      try {
        res = await axios.get(
          `api/tweets/search/username?searchTerm=${searchTerm}`
        );
        console.log(res);
      } catch (err) {
        JSON.stringify(err);
        console.log(err); // err represnts the error returned by .net web API
      }
    } else {
      try {
        res = await axios.get(
          `api/tweets/search/content?searchTerm=${searchTerm}`
        );
      } catch (err) {
        JSON.stringify(err);
        console.log(err);
      }
    }
    setTweets(res.data);
  }

  function toggleActiveStatus(e) {
    if (
      e.target.textContent === "Username" &&
      !e.target.classList.contains("active")
    ) {
      usernameBtn.classList.add("active");
      contentBtn.classList.remove("active");
    }

    if (
      e.target.textContent === "Content" &&
      !e.target.classList.contains("active")
    ) {
      contentBtn.classList.add("active");
      usernameBtn.classList.remove("active");
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
                  className="btn btn-secondary search-selector active"
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
                  className="btn btn-secondary search-selector"
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
      <TweetsList tweets={tweets} />
    </Container>
  );
};

export default Search;
