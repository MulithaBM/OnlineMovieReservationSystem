import './App.css';

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import AddMovie from './Pages/AddMovie';
import Movies from './Pages/Movies';
import Movie from './Pages/Movie';

function App() {
  return (
    <Router>
        <Routes>
            <Route path="/addmovie" element={<AddMovie />} />
            <Route path="/movies" element={<Movies />} />
            <Route path="/movies/:id" element={<Movie />} />
        </Routes>
    </Router>
  );
}

export default App;
