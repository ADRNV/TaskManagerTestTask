import React from 'react'
import Table  from 'react-bootstrap/Table';

export default function ProjectsTable(projects) {
  return (
    <Table striped bordered hover>
      <thead>
        <tr>
          <th>#</th>
          <th>Times</th>
          <th>Ticket</th>
          <th>Description</th>
          <th>Start</th>
          <th>End</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>1</td>
          <td>11:06</td>
          <td>Create react app</td>
          <td>Create react app with for api</td>
          <td>22:00</td>
          <td>22:01</td>
        </tr>
      </tbody>
    </Table>
  )
}
