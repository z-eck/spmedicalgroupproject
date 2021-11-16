import axios from 'axios';
import { Component } from 'react';

export default class Especialidades extends Component {
    constructor(props){
        super(props);
        this.state = {
            listaEspecialidades: [],
            especialidade: '',
            idEspecialidadeAlterada: 0
        }
    }

    buscarEspecialidades = () => {
        console.log('Chamada para API -->');
        fetch('http://127.0.0.1:5000/api/Especialidades')

        .then((resposta) => resposta.json())

        .then((dados) => this.setState({listaEspecialidades: dados}))

        .catch(erro => console.log(erro))

    }

    componentDidMount(){
        this.buscarEspecialidades()


        //
    };

    atualizaEstadoEspecialidade = async (event) => {
        console.log('Atualização de Estado')
        await this.setState({ especialidade: event.target.value});
        console.log(this.state.especialidade);
    };

    cadastrarEspecialidade = (event) => {
        event.preventDefault();

        if (this.state.idEspecialidadeAlterada !== 0) {
            console.log('Atualização');
            axios.put('http://127.0.0.1:5000/api/Especialidades/' + this.state.idEspecialidadeAlterada, {especialidade1 : this.state.especialidade} )

            .then(resposta => {
                if (resposta.status === 204) {
                    console.log('A especialidade ' + this.state.idEspecialidadeAlterada + ' foi alterada para ' + this.state.especialidade);
                }
            })

            .then(this.buscarEspecialidades)
        }

        else {
            console.log('Cadastro');
            fetch('http://127.0.0.1:5000/api/Especialidades', {
                method: 'POST',
                body: JSON.stringify({ especialidade1 : this.state.especialidade}),
                headers:{ "Content-Type" :"application/json"}
            })

            .then(console.log("Especialidade Enviada!"))

            .catch(erro => console.log(erro))

            .then(this.buscarEspecialidades)
             }
    }

    buscarEspecialidadesID = (aespecialidade) => {
        this.setState({
            idEspecialidadeAlterada : aespecialidade.idEspecialidade,
            especialidade : aespecialidade.especialidade1},
            () => {
                console.log('A especialidade ' + aespecialidade.idEspecialidade + 
                ' foi selecionada, sendo no state na alteração a ' + this.state.idEspecialidadeAlterada + 
                ' e sua nomenclatura é: ' + this.state.especialidade)
            })
    }

    render(){
        return(
            <div>
                <main>
                    <section>
                        <h2>Lista de Especialidades</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Especialidade</th>
                                    <th>Ações</th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaEspecialidades.map( (aespecialidade) => {
                                        return(
                                            <tr key={aespecialidade.idEspecialidade}>
                                                <td>{aespecialidade.idEspecialidade}</td>
                                                <td>{aespecialidade.especialidade1}</td>

                                                <td><button onClick={() => this.buscarEspecialidadesID(aespecialidade)}>Editar</button></td>
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>
                        </table>
                    </section>
                    <section>
                                <h2>Cadastro de Especialidade</h2>
                                <form onSubmit={this.cadastrarEspecialidade}>
                                    <div>
                                        <input type="text"
                                        value={this.state.especialidade}
                                        placeholder="Especialidade"
                                        onChange={this.atualizaEstadoEspecialidade}
                                        />
                                        <button type="submit">Cadastrar</button>
                                    </div>
                                </form>
                    </section>
                </main>
            </div>
        )
    };
}