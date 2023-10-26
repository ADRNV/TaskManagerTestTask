import React from 'react'
import { Link } from 'react-router-dom'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Button } from 'react-bootstrap';

export default function LayoutPanel() {
  return (
    <Navbar expand="lg" className="bg-body-tertiary">
    <Container>
      <Link to={"/projects"}>Projects</Link>
    </Container>
  </Navbar>
  )
}
