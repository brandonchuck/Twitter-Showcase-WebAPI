import { useState } from "react";
import TweetsList from "../TweetsList";
import axios from "axios";
import { Container, Row, Col, Form } from "react-bootstrap";

const Search = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [searchChoice, setSearchChoice] = useState("Username");

  async function getTweets(e) {
    e.preventDefault();
    let res;

    if (searchChoice === "Username") {
      try {
        res = await axios.get(
          `api/tweets/search/username?searchTerm=${searchTerm}`
        );
      } catch (err) {
        console.log(err);
      }
    } else {
      res = await axios
        .get(`api/tweets/search/content?searchTerm=${searchTerm}`)
        .catch((err) => {
          console.log(err.response.data.message);
        });
    }
    setTweets(res.data);
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
                  className="btn btn-secondary search-selector"
                  onClick={(e) => {
                    setSearchChoice(e.target.textContent);
                  }}
                >
                  Username
                </button>
                <button
                  type="button"
                  className="btn btn-secondary search-selector"
                  onClick={(e) => {
                    setSearchChoice(e.target.textContent);
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

// {`${
//   isActive ? "active" : ""
// } btn btn-secondary search-selector`}
