import React from 'react'
import Table  from 'react-bootstrap/Table';

export default function ProjectsTable({tasks}) {

  return (
    <div>
    {tasks !== undefined ? <Table striped bordered hover>
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
          {tasks.map((t, i) => {
          return <>
          <td>{i+1}</td>
          <td>{t.createDate}</td>
          <td>{t.taskName}</td>
          <td>{t.taskName}</td>
          <td>{t.startDate}</td>
          <td>{t.cancelDate}</td>
          </>
          })}
      
        </tr>
      </tbody>
    </Table> : <h1>Not projects yet</h1>
    }
   </div> 
  )
}
