// import { render } from '@testing-library/react';
import { Component, render } from 'react';

export default class Agendamento extends Component {
    constructor(props){
        super(props);
        this.state = {
            listaAgendamentos: {},
            paciente: '',
            medico: '',
            situacao: ''
        }
    }

    componentDidMount(){
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

                            </tbody>
                        </table>
                    </section>
                </main>
            </div>
        )
    };
}