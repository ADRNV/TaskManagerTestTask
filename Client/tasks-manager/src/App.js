import logo from './logo.svg';
import './App.css';
import ProjectsTable from './components/ProjectsTable/ProjectsTable';
import { Button } from 'bootstrap';
import ProjectSelector from './components/ProjectSelector/ProjectSelector';
import ProjectsClient from './apiClients/ProjetsApiClient';
import { useFetchHook } from './hooks/useFetching';
import { useEffect, useState } from 'react';
import Spinner from 'react-bootstrap/Spinner';

function App() {
  
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
    <div className="App">
      {projects.length != 0 ? <ProjectSelector project={project} setProject={setProject} projects={projects}/> : <Spinner animation="border" role="status"></Spinner>}
      <ProjectsTable tasks={project.tasks} setTasks={setProject}/>
    </div>
  );
}

export default App;
