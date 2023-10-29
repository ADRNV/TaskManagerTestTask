import React, { useState } from 'react'
import { Button } from 'react-bootstrap';
import Form from 'react-bootstrap/Form';
import ProjectsClient from '../../apiClients/ProjetsApiClient';
import { useFetchHook } from '../../hooks/useFetching';

export default function CreateProjectPage({projects, setProjects}) {
  
    var client = new ProjectsClient()

    var [project, setProject] = useState({id:"3fa85f64-5717-4562-b3fc-2c963f66afa6", tasks:[]})

    var [create, loading, error] = useFetchHook(async () => {
        setProjects([...projects, project])
        var data = await client.createProject(project)
        .then(result => console.log(result))
    })
    
    return (
    <div>
        <Form>
            <Form.Group className="mb-3">
            <Form.Label>Name of project</Form.Label>
            <Form.Control type="text" onChange={(e) => setProject({...project, projectName:e.target.value})} placeholder="ProjectName" />
            <Form.Label>Creation date</Form.Label>
            <Form.Control type="date" onChange={(e) => setProject({...project, createDate:e.target.value})}/>
            <Button onClick={() => create()}>Create</Button>
            </Form.Group>
        </Form>
    </div>
  )
}
