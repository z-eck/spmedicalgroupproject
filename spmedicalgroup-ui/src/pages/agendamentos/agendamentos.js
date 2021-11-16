// import { render } from '@testing-library/react';
import { Component } from 'react';
import axios from 'axios';

export default class Agendamento extends Component {
    constructor(props){
        super(props);
        this.state = {
            listaAgendamentos: [],
            paciente: '',
            medico: '',
            situacao: ''
        }
    }

    buscarAgendamentos = () => {
        axios('http://localhost:5000/api/Agendamentos', {
      headers: {
        Authorization: 'Bearer ' + localStorage.getItem('usuario-token'),
      },
    })
      .then((resposta) => {
        if (resposta.status === 200) {
          this.setState({ listaTiposEventos: resposta.data });
          console.log(this.state.listaTiposEventos);
        }
      })
      .catch((erro) => console.log(erro));
    }

    componentDidMount(){
        this.buscarAgendamentos()


        //
    };

    render(){
        return(
            <div>
                <main>
                    <section>
                        <h2>Lista de Agendamentos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Paciente</th>
                                    <th>Médico</th>
                                    <th>Situação</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaAgendamentos.map( (oagendamento) => {
                                        return(
                                            <tr key={oagendamento.idAgendamento}>
                                                <td>{oagendamento.idAgendamento}</td>
                                                <td>{oagendamento.paciente}</td>
                                                <td>{oagendamento.medico}</td>
                                                <td>{oagendamento.situacao}</td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                </main>
            </div>
        )
    };
}