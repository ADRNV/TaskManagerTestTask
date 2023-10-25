import React, { useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown';

export default function ProjectSelector({projects, project, setProject}) {

  return (
    <Dropdown>
      <Dropdown.Toggle variant="success" id="dropdown-basic">{project.projectName !== undefined ? project.projectName : "Select project" }</Dropdown.Toggle>
      <Dropdown.Menu>
        {projects.map((p) => 
        <Dropdown.Item key={p.id} onClick={() => setProject(p)}>{p.projectName}</Dropdown.Item>)}
      </Dropdown.Menu>
    </Dropdown>
  )
}
