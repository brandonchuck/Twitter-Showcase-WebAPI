import { Card, Row, Col, Container } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faHeart, faComment } from "@fortawesome/free-regular-svg-icons";
import { faRetweet } from "@fortawesome/free-solid-svg-icons";

const TweetCard = ({ tweet }) => {
  return (
    <Card className="tweet-card">
      <Container className="tweet-content-container">
        <Row className="g-0">
          <Col sm={1}>
            <Card.Body className="d-flex justify-content-center">
              <img
                className="profile-picture"
                src={tweet.ProfileImageUrl}
                alt="pfp"
              />
            </Card.Body>
          </Col>
          <Col sm={11}>
            <Card.Body>
              <Row className="tweet-info-row">
                <Col>
                  <div className="d-flex text-left screen-name">
                    <strong>{tweet.ScreenName}</strong>
                  </div>
                  <p className="username">
                    @{tweet.Username} - {tweet.CreatedAt}
                  </p>
                </Col>
              </Row>

              <Card.Text className="d-flex text-left">{tweet.Text}</Card.Text>
              {tweet.ImageUrls &&
                tweet.ImageUrls.map((img, index) => {
                  return (
                    <img
                      className="media"
                      key={index}
                      style={{ width: "100%", height: "auto" }}
                      src={img}
                      alt="pic"
                    />
                  );
                })}
              {tweet.VideoPreviewImageUrls &&
                tweet.VideoPreviewImageUrls.map((img) => {
                  return (
                    <img
                      className="media"
                      style={{ width: "100%", height: "auto" }}
                      src={img}
                      alt="vid"
                    />
                  );
                })}
              <div className="d-flex metrics-container">
                <ul className="d-flex public-metrics">
                  <li className="metric">
                    <FontAwesomeIcon
                      className="twitter-icon"
                      icon={faComment}
                    />
                    {tweet.CommentCount}
                  </li>

                  <li className="metric">
                    <FontAwesomeIcon
                      className="twitter-icon"
                      icon={faRetweet}
                    />
                    {tweet.RetweetCount}
                  </li>

                  <li className="metric">
                    <FontAwesomeIcon className="twitter-icon" icon={faHeart} />
                    {tweet.LikeCount}
                  </li>
                </ul>
              </div>
            </Card.Body>
          </Col>
        </Row>
      </Container>
    </Card>
  );
};

export default TweetCard;
