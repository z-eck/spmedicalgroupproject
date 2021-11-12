import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom'

import './index.css';

import Home from './pages/home/App';
import Login from './pages/login/login';
import Agendamentos from './pages/agendamentos/agendamentos';
import NotFound from './pages/notfound/NotFound';
import Especialidades from './pages/especialidades/especialidades';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/agendamentos" component={Agendamentos}/>
        <Route path="/login" component={Login} />
        <Route path="/notfound" component={NotFound} />
        <Route path="/especialidades" component={Especialidades} />
        <Redirect to="/notfound" />
      </Switch>
    </div>
  </Router>

)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
