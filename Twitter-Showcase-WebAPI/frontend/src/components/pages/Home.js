import { Container, Row, Col } from "react-bootstrap";

const Home = () => {
  return (
    <Container className="welcome-container">
      <Row>
        <Col>
          <h1 className="welcome-title">Welcome to Blue Bird!</h1>
          <Container className="description-container">
            <p className="description">
              Click on the <strong>search</strong> page to search tweets by
              twitter handle and content
            </p>
            <p className="description">
              Click on the <strong>random</strong> page to view random tweets
              from 5 popular accounts in the NFT twitterverse!
            </p>
          </Container>
        </Col>
      </Row>
    </Container>
  );
};

export default Home;
