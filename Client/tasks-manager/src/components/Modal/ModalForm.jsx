import React from 'react'
import { useState } from 'react';
import { useFetchHook } from '../../hooks/useFetching';
import ProjectsClient from '../../apiClients/ProjetsApiClient';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Modal from 'react-bootstrap/Modal';
import Utils from '../../utils/Utils'

export default function ModalForm({project, setProject, tasks, setTasks}) {

    var [task, setTask] = useState({id:Utils.generate_uuidv4(),comments:[]})

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    var client = new ProjectsClient()

    var [update, loading, error] = useFetchHook(async () => {
        setProject({...project, tasks:tasks})
        var data = await client.updateProject(project)
        .then(result => console.log(result))
    })

  return (
    <>
      <Button variant="primary" onClick={handleShow}>
        Create task  
      </Button>
    <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Modal heading</Modal.Title>
        </Modal.Header>
        <Modal.Body>
            <Form>
                <Form.Group className="mb-3">
                    <Form.Label>Name</Form.Label>
                    <Form.Control type="text" onChange={(e) => setTask({...task, taskName:e.target.value})} placeholder="Task name" />
                    <Form.Label>Create date</Form.Label>
                    <Form.Control type="date" onChange={(e) => setTask({...task, createDate:e.target.value})}/>
                    <Form.Label>Start date</Form.Label>
                    <Form.Control type="date" onChange={(e) => setTask({...task, startDate:e.target.value})}/>
                    <Form.Label>Update date</Form.Label>
                    <Form.Control type="date" onChange={(e) => setTask({...task, updateDate:e.target.value})}/>
                    <Form.Label>Cancel date</Form.Label>
                    <Form.Control type="date" onChange={(e) => setTask({...task, cancelDate:e.target.value})}/>
                    <Button onClick={() => update()}>Create</Button>
                </Form.Group>
            </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={() => {
            update()
            handleClose()
            }}>
            Close
          </Button>
          <Button variant="primary" onClick={() => {
            setTasks([...tasks, task])
            setProject({...project, tasks:tasks})
            }}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  )
}
