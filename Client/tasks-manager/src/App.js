import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import ProjectsPage from './components/ProjectsPage/ProjectsPage';
import { Nav } from 'react-bootstrap';
import LayoutPanel from './components/Layout/LayoutPanel';
import { Button } from 'react-bootstrap';
import CreateProjectPage from './components/CreateProjectPage/CreateProjectPage';
import { useState } from 'react';

function App() {
  
  
var [projects, setProjects] = useState([])
  

  return (
    <div>
       <ProjectsPage project={projects} setProject={setProjects}/>
       <CreateProjectPage projects={projects} setProjects={setProjects}/>
    </div>
  );
}

export default App;
