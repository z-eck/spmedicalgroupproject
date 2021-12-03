import axios from 'axios';
import { Component } from 'react';
import { parseJwt } from '../../services/auth';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : '',
            mensagemErro : '',
            isLoading : false
        };
    };

    logarLogin = (event) => {
        event.preventDefault();

        this.setState({ mensagemErro  : '', isLoading : true})

        axios.post('http://192.168.4.100:5000/api/Login', {email : this.state.email, senha: this.state.senha})

        .then(resposta => {
            if (resposta.status === 200) {

                localStorage.setItem('usuario-token', resposta.data.token)

                console.log('logado com sucesso! Token armazenado no armazenamento local!');

                this.setState({isLoading : false})

                if (parseJwt().role === '1') {
                    this.props.history.push('/dashadmin')
                }

                else {
                    this.props.history.push('/agendamentos')
                }

            }
        })
        .catch((erro) => {
            console.log('Houve uma falha. Erro:' + erro);
            this.setState({ mensagemErro : 'Email e/ou senha inválidos!!', isLoading: false})
        })
    }

    atualizarEstadoCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value})
    }

    render(){
        return(
            <div>
                <main>
                    <section>
                        <h2>Login</h2>
                        <form onSubmit={this.logarLogin}>
                            <input
                            type="email"
                            name="email"
                            value={this.state.email}
                            onChange={this.atualizarEstadoCampo}
                            placeholder="Email"/>
                            <input
                            type="password"
                            name="senha"
                            value={this.state.senha}
                            onChange={this.atualizarEstadoCampo}
                            placeholder="Senha"/>
                            {this.state.isLoading === true && <button disabled={this.state.isLoading === true}>Carregando...</button> }
                            {this.state.isLoading === false && 
                            <button 
                            type="submit" 
                            disabled={this.state.email === '' ? 'none' : '' 
                            || this.state.senha === '' ? 'none' : ''}>Logar</button>}
                            <p style={{color : '#ff2400'}}>{this.state.mensagemErro}</p>
                        </form>
                    </section>
                </main>
            </div>
        )
    }
};