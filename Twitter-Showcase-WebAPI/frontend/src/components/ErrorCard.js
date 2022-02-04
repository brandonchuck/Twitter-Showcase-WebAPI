import React from "react";
import { Card, Container, Row, Col } from "react-bootstrap";

const ErrorCard = ({ errorMessage }) => {
  // debugger;
  if (errorMessage === "") {
    return <></>;
  }

  return (
    <Container className="tweet-feed">
      <Card className="tweet-card">
        <Container className="tweet-content-container">
          <Row>
            <Col>
              <Card.Body className="d-flex justify-content-center">
                <Card.Text className="error-text"> {errorMessage} </Card.Text>
              </Card.Body>
            </Col>
          </Row>
        </Container>
      </Card>
    </Container>
  );
};

export default ErrorCard;
