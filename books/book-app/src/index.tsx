import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';

import reportWebVitals from './reportWebVitals';
import App from './App'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Home } from './Components/Home/home';
import { BooksList } from './Components/BooksList/books-list';


ReactDOM.render(
  <React.StrictMode>
<App />
  </React.StrictMode>,
  document.getElementById('root')
);

reportWebVitals();