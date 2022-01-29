import { Card, Row, Col, Container } from "react-bootstrap";

const TweetCard = ({ tweet }) => {
  return (
    <Card>
      <Container>
        <Row>
          <Col xs={1}>
            <Card.Body>
              <img src={tweet.ProfileImageUrl} alt="pfp" />
            </Card.Body>
          </Col>
          <Col>
            <Card.Body>
              <Card.Title className="d-flex justify-content-start">
                {tweet.ScreenName} @{tweet.Username}
              </Card.Title>
              <Card.Text className="d-flex justify-content-start">
                {tweet.Text}
              </Card.Text>
              {tweet.ImageUrls &&
                tweet.ImageUrls.map((img, index) => {
                  return (
                    <img
                      className="image-url"
                      key={index}
                      style={{ width: "50%", height: "50%" }}
                      src={img}
                      alt="pic"
                    />
                  );
                })}
              {tweet.VideoPreviewImageUrls &&
                tweet.VideoPreviewImageUrls.map((img) => {
                  return (
                    <img
                      className="video-preview-url"
                      style={{ width: "40%", height: "40%" }}
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
