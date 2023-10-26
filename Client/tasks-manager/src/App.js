import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import ProjectsPage from './components/ProjectsPage/ProjectsPage';
import { Nav } from 'react-bootstrap';
import LayoutPanel from './components/Layout/LayoutPanel';
import { Button } from 'react-bootstrap';
import CreateProjectPage from './components/CreateProjectPage/CreateProjectPage';

function App() {
  
  return (
    <div className="App">
      <ProjectsPage/>
    </div>
  );
}

export default App;
