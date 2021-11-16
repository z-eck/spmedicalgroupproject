import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom'
import { parseJwt, usuarioAutenticado } from './services/auth';

import './index.css';

import Home from './pages/home/App';
import Login from './pages/login/login';
import Agendamentos from './pages/agendamentos/agendamentos';
import NotFound from './pages/notfound/NotFound';
import Especialidades from './pages/especialidades/especialidades';
import Admin from './pages/dashadmin/admin';

import reportWebVitals from './reportWebVitals';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoUsuario = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && (parseJwt().role === '2'  || parseJwt().role === '3') ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <PermissaoUsuario path="/agendamentos" component={Agendamentos}/>
        <Route path="/login" component={Login} />
        <Route path="/notfound" component={NotFound} />
        <Route path="/especialidades" component={Especialidades} />
        <PermissaoAdm path="/dashadmin" component={Admin} />
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
