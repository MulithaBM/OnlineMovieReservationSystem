import './App.css';

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import AddMovie from './Pages/AddMovie';
import Movies from './Pages/Movies';

function App() {
  return (
    <Router>
        <Routes>
            <Route path="/addmovie" element={<AddMovie />} />
            <Route path="/movies" element={<Movies />} />
        </Routes>
    </Router>
  );
}

export default App;
