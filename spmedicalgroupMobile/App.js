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
    const response = await api.get('/especialidades'); // <==
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
            <FlatList
              contentContainerStyle={styles.listInfo}
              data={this.state.listAgendamentos}
              keyExtractor={item => item.idEspecialidade} // <==
              renderItem={this.renderItem} />
            {/* Parte de descrição da listagem */}
            <FlatList
              contentContainerStyle={styles.listDesc}
              data={this.state.listAgendamentos}
              keyExtractor={item => item.idEspecialidade} // <==
              renderItem={this.renderItem} />
            <View style={styles.listDivisor} />
          </View>
        </View>
      </View >
    );
  }
  
  renderItem = ({ item }) => (
    <View style={styles.listInfo}>
      <Text style={styles.listInfoText}>{item.especialidade1}</Text>
      {/* <Text style={styles.listInfoText}>{item.nomeMedico}</Text>
      <Text style={styles.listInfoText}>{item.sobrenomeMedico}</Text>
      <Text style={styles.listInfoText}>{item.data}</Text>
      <Text style={styles.listInfoText}>{item.situacao}</Text>
    </View>
    <View style={styles.listDesc}>
      <Text style={styles.listDescText}>{item.descricao}</Text> */}
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
    alignItems: 'center',
    backgroundColor: '#000000'
  },

  listInfoTitle: {
    fontFamily: 'Roboto Slab',
    fontSize: 15
  },

  listInfoText: {
    fontFamily: 'Roboto',
    fontStyle: 'italic',
    fontWeight: 'normal',
    fontSize: 10,
    lineHeight: 12,
    display: 'flex',
    alignItems: 'center',
    textAlign: 'center',
    color: '#fff'
  },

  listDivisor: {
    paddingTop: 10,
    width: 360,
    borderBottomColor: '#000',
    borderBottomWidth: 3
  },
});
