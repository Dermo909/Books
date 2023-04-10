import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import { BooksList } from './Components/BooksList/books-list';
import { BottomNav } from './Components/Navigation/bottom-nav';
import { TopNav } from './Components/Navigation/top-nav';
import { ReadingList } from './Components/ReadingList/reading-list';


export function App() {
    return (
        <>
            <TopNav />

            <Router>
                <Routes>
                    <Route path="/" element={<BooksList />} />
                    <Route path='/booksList' element={<BooksList />} />
                    <Route path='/readingList' element={<ReadingList />} />
                </Routes>
            </Router>

            <BottomNav/>
        </>

    );
};

export default App;
