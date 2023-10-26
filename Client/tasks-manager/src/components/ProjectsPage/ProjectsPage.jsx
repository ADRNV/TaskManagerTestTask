import React from 'react'
import ProjectsTable from '../ProjectsTable/ProjectsTable';
import ProjectSelector from '../ProjectSelector/ProjectSelector';
import ProjectsClient from '../../apiClients/ProjetsApiClient';
import { useFetchHook } from '../../hooks/useFetching';
import { useEffect, useState } from 'react';
import Spinner from 'react-bootstrap/Spinner';
import { Link } from 'react-router-dom';

export default function ProjectsPage() {
  
  var client = new ProjectsClient()

  var [projects, setProjects] = useState([])

  var [project, setProject] = useState({})

  var [tasks, setTasks] = useState([])

  var [fetching, loading, error] = useFetchHook(async () => {
    var data = await client.getProjects(1, 3)
    setProjects([...projects, ...data])
  })

  useEffect(() => {
      fetching()
  }, projects)

  return (
    <div>
      {!loading ? 
      <div>
        <ProjectSelector project={project} setProject={setProject} projects={projects}/> 
        </div>: <Spinner animation="border" role="status"></Spinner>}
      <ProjectsTable tasks={project.tasks} setTasks={setProject}/>
    </div>
  );
}
