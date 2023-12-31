import ReactDOM from 'react-dom/client';
import './styles/globals.css';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { NotFoundPage } from './pages/NotFoundPage';
import { Home } from './pages/Home';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <Router>
    <Routes>
      <Route path="/" Component={Home} />
      <Route path="*" Component={NotFoundPage} />
    </Routes>
  </Router>
);

reportWebVitals();
