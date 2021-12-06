import React, { Component } from 'react';
import {
  FlatList,
  StyleSheet,
  Text,
  View,
} from 'react-native';

import api from './src/services/api';

// Começarei a digitar as funções e o que vier dentro em inglês, porém, manterei as anotações em PT-BR :D

export default class App extends Component {
  constructor(props){
    super(props);
    this.state = {
      listAgendamentos : []
    };
  };

  getAgendamentos = async () => {
    const response = await api.get('/Agendamentos'); // <== Chamada para API
    console.warn(response);
    const dataApi = response.data;
    this.setState({ listAgendamentos : dataApi});
  };

  componentDidMount(){
    this.getAgendamentos();
  };

  render() {
    return (
      <View style={styles.container}>
        {/* Cabeçalho do projeto */}
        <View style={styles.header}>
          <Text style={styles.headerText}>Agendamentos</Text>
        </View>
        {/* O corpo do projeto */}
        <View style={styles.body}>
          {/* Parte de listagem */}
          <View style={styles.list}>
            {/* Parte de informações do médico, paciente, data e situação do agendamento da listagem */}
            <View style={styles.listInfoTitle}>
              <Text>Paciente</Text>
              <Text>Médico</Text>
              <Text>Data</Text>
              <Text>Situação</Text>
              <FlatList
                contentContainerStyle={styles.listInfo}
                data={this.state.listAgendamentos}
                keyExtractor={item => item.idAgendamento} // <== ID
                renderItem={this.renderItem} />
            </View>
            {/* Parte de descrição da listagem */}
            <View style={styles.listDescTitle}>
              <Text>Descrição</Text>
              <FlatList
                contentContainerStyle={styles.listDesc}
                data={this.state.listAgendamentos}
                keyExtractor={item => item.idAgendamento} // <== ID
                renderItem={this.renderItem} />
                
          <View style={styles.listDivisor} />
            </View>
          </View>
        </View>
      </View >
    );
  }
  
  renderItem = ({ item }) => (
    <View style={styles.list}>
      <View style={styles.listInfo}>
        <Text style={styles.listInfoText}>{(item.idPacienteNavigation.nomePaciente)}</Text>
        <Text style={styles.listInfoText}>{(item.idMedicoNavigation.nomeMedico)}</Text>
        <Text style={styles.listInfoText}>{(item.idMedicoNavigation.sobrenomeMedico)}</Text>
        <Text style={styles.listInfoText}>{item.datahoraConsulta}</Text>
        <Text style={styles.listInfoText}>{(item.idSituacaoNavigation.descricao)}</Text>
      </View>
      <View style={styles.listDesc}>
        <Text style={styles.listDescText}>{item.descricao}</Text>
      </View>
    </View>

  )
};

const styles = StyleSheet.create({
  header: {
    height: 64,
    width: '100%',
    alignItems: 'center',
    backgroundColor: '#3582FF',
    justifyContent: 'center'
  },

  headerText: {
    fontSize: 30,
    fontWeight: 'bold',
    color: '#1AE0B4'
  },

  body: {
    // flex: 4,
    alignItems: 'center',
    // backgroundColor: '#000000'
  },

  list: {
    // flex: 4,
    backgroundColor: '#3582FF',
    width: '80%',
    height: '80%',
  },

  listInfo: {
    color: ''
  },

  listInfoTitle: {
    fontFamily: 'Roboto Slab',
    fontSize: 15,
    flexDirection: 'row',
    justifyContent: 'space-between',
    backgroundColor: '#fff'
  },

  listInfoText: {
    fontFamily: 'Roboto',
    fontStyle: 'italic',
    fontWeight: 'normal',
    fontSize: 13,
    lineHeight: 12,
    display: 'flex',
    alignItems: 'center',
    textAlign: 'center',
    color: '#fff',
    letterSpacing: 2,
    marginTop: 8,
    flexDirection: 'row'
  },

  listDescTitle: {
    color: '#fff',
    marginTop: 2
  },

  listDivisor: {
    paddingTop: 10,
    width: '100%',
    borderBottomColor: '#ff2400',
    borderBottomWidth: 3
  },
});
