import React, { useState } from 'react'
import Table  from 'react-bootstrap/Table';
import Form from 'react-bootstrap/Form';
import TimePicker from 'react-time-picker'
import 'react-time-picker/dist/TimePicker.css';
import { Button } from 'bootstrap';

export default function ProjectsTable({tasks, setTasks}) {
  
  var [sortingTime, setSortingTime] = useState()
  
  function sortByDate(){
    var sortedTasks = [...tasks].sort((a, b) => {
      return sortingTime - a.createDate
    })

    setTasks(sortedTasks)
  }

  return (
    <div>
      <div>
      <Form.Label>Sort by date</Form.Label>
      <TimePicker onChange={(value) => setSortingTime(value)}/>
      <button onClick={() => sortByDate(sortingTime)}>Sort</button>
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
            <th>Amount time</th>
          </tr>
        </thead>
        <tbody>
            {tasks.map((t, i) => {
            return <tr>
            <td>{i+1}</td>
              <td>{t.createDate.substring(11, 16)}</td>
              <td>{t.taskName}</td>
              <td>{t.taskName}</td>
              <td>{t.startDate.substring(11, 16)}</td>
              <td>{t.cancelDate.substring(11, 16)}</td>
              <td>{`${
                (new Date(t.cancelDate).getHours() - (new Date(t.startDate).getHours()))}:
                ${Math.abs((new Date(t.cancelDate).getMinutes() - (new Date(t.startDate).getMinutes())))}`
                }</td>
            </tr>
            })}
        </tbody>
        </Table> : <h1>Not projects yet</h1>
          }
      </div>
    </div>
  </div>
     
  )
}
