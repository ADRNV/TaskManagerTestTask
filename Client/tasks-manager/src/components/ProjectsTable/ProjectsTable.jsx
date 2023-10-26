import React, { useEffect, useState } from 'react'
import Table  from 'react-bootstrap/Table';
import Form from 'react-bootstrap/Form';
import TimePicker from 'react-time-picker'
import 'react-time-picker/dist/TimePicker.css';
import { useFetchHook } from '../../hooks/useFetching';
import ProjectsClient from '../../apiClients/ProjetsApiClient';

export default function ProjectsTable({tasks, setTasks}) {
  
  var [sortingTime, setSortingTime] = useState('')

  var client = new ProjectsClient()

  var [times, setTimes] = useState([])

  var [fetching, loading, error] = useFetchHook(async () => {
      await tasks.map(async (t,i) => {
        await client.getAmountTime(t.startDate, t.cancelDate)
        .then(c => {
          setTimes((times) => [...times, c])
          console.log(c)
        })
      })
  })

  useEffect(() => { 
    fetching()
  }, tasks)

  function sortByDate(){
    var sortedTasks = tasks.sort((a, b) => Number(new Date(b.createDate)) - Number(new Date(a.createDate)))
    setTasks(sortedTasks)
  }

  return (
    <div>
      <div>
      <Form.Label>Sort by date</Form.Label>
      <TimePicker onChange={(value) => setSortingTime(value)}/>
      <button onClick={() => sortByDate()}>Sort</button>
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
            <th>Amount</th>
          </tr>
        </thead>
        <tbody>
            {
            tasks.map((t, i) => {
            return <tr>
            <td>{i+1}</td>
              <td>{t.createDate.substring(11, 16)}</td>
              <td>{t.taskName}</td>
              <td>{t.taskName}</td>
              <td>{t.startDate.substring(11, 16)}</td>
              <td>{t.cancelDate.substring(11, 16)}</td>
              <td>{times[i]}</td>
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
