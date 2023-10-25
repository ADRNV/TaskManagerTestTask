import logo from './logo.svg';
import './App.css';
import ProjectsTable from './components/ProjectsTable/ProjectsTable';
import { Button } from 'bootstrap';
import ProjectSelector from './components/ProjectSelector/ProjectSelector';
import ProjectsClient from './apiClients/ProjetsApiClient';
import { useFetchHook } from './hooks/useFetching';
import { useEffect, useState } from 'react';

function App() {
  
  var client = new ProjectsClient()

  var [projects, setProjects] = useState([])

  var [project, setProject] = useState({})

  var [fetching, loading, error] = useFetchHook(async () => {
    var data = await client.getProjects(1, 3)
    setProjects([...projects, ...data])
  })

  useEffect(() => {
      fetching()
  }, projects)
  return (
    <div className="App">
      {projects.length != 0 ? <ProjectSelector project={project} setProject={setProject} projects={projects}/> : <p>loading</p>}
      <ProjectsTable tasks={project.tasks}/>
    </div>
  );
}

export default App;
