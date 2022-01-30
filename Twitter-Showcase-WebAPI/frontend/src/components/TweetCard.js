import { Card, Row, Col, Container } from "react-bootstrap";

const TweetCard = ({ tweet }) => {
  return (
    <Card className="tweet-card">
      <Container className="tweet-content-container">
        <Row>
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
              <Card.Title className="d-flex text-left">
                {tweet.ScreenName} @{tweet.Username}
                {/* {tweet.CreatedAt} */}
              </Card.Title>
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
              <div className="d-flex justify-content-start metrics-container">
                <ul className="public-metrics">
                  <li className="metric">{tweet.CommentCount}</li>
                  <li className="metric">{tweet.RetweetCount}</li>
                  <li className="metric">{tweet.LikeCount}</li>
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
