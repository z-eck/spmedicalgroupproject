// import { render } from '@testing-library/react';
import { Component, render } from 'react';

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
        console.log('chamada para a API');

        fetch('http://127.0.0.1:5000/api/Agendamentos')
        
        .then(resposta => resposta.json())

        .then( dados => this.setState({listaAgendamentos: dados}))

        .catch(erro => console.log(erro))
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