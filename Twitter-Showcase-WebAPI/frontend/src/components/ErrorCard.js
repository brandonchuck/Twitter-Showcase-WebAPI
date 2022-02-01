import React from "react";
import { Card, Container, Row, Col } from "react-bootstrap";

const ErrorCard = ({ tweetResponse }) => {
  return (
    <Card className="tweet-card">
      <Container className="tweet-content-container">
        <Row>
          <Col>
            <Card.Body className="d-flex justify-content-center">
              {/* <Card.Text>{tweetResponse.error.value}not found!</Card.Text> */}
              <Card.Text> Error not found!</Card.Text>
            </Card.Body>
          </Col>
        </Row>
      </Container>
    </Card>
  );
};

export default ErrorCard;
