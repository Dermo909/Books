import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import { BooksList } from './Components/BooksList/books-list';
import { Home } from './Components/Home/home';

export function App() {

    return (
        <>
            <Router>
                <Routes>
                    <Route path="/" element={<Home/>} />
                    <Route path="/home" element={<Home/>} />
                    <Route path='/booksList' element={<BooksList/>} />
                </Routes>
            </Router>
        </>

    );
};

export default App;
