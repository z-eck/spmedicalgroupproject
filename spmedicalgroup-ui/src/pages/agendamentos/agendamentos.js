// import { render } from '@testing-library/react';
import { Component } from 'react';
import axios from 'axios';
import { parseJwt } from '../../services/auth';

export default class Agendamento extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaAgendamentos: [],
            paciente: '',
            medico: '',
            situacao: '',
            dataHora: Date
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
                    this.setState({ listaAgendamentos: resposta.data });
                    console.log(parseJwt().idP);
                    console.log(this.state.listaAgendamentos);
                    console.log(resposta);
                }
            })
            .catch((erro) => console.log(erro));
    }

    componentDidMount() {
        this.buscarAgendamentos()


        //
    };

    render() {
        return (
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
                                    <th>Data e Hora</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaAgendamentos.map((oagendamento) => {
                                        return (
                                            <tr key={oagendamento.idAgendamento}>
                                                <td>{oagendamento.idAgendamento}</td>
                                                <td>{oagendamento.idPacienteNavigation.nomePaciente}</td>
                                                <td>{oagendamento.idMedicoNavigation.nomeMedico}</td>
                                                <td>{oagendamento.idSituacaoNavigation.descricao}</td>
                                                <td>{oagendamento.datahoraConsulta}</td>
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