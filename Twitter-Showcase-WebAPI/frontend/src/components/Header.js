import React from "react";
import { NavLink } from "react-router-dom";
import { Container, Nav, Navbar } from "react-bootstrap";

const Header = () => {
  return (
    <Navbar bg="primary" variant="dark" expand="lg">
      <Container>
        <Navbar.Brand href="/">Blue Bird</Navbar.Brand>

        <Navbar.Toggle aria-controls="basic-navbar-nav" />

        <Nav>
          <Nav.Link as={NavLink} to={"/"}>
            Home
          </Nav.Link>
          <Nav.Link as={NavLink} to={"/search"}>
            Search
          </Nav.Link>
          <Nav.Link as={NavLink} to={"/random"}>
            Random
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
};

export default Header;
