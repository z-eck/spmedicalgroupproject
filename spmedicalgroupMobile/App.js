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
            {/* Parte de informações do médico, paciente, data, situação e descrição do agendamento da listagem */}
              <FlatList
                contentContainerStyle={styles.list}
                data={this.state.listAgendamentos}
                keyExtractor={item => item.idAgendamento} // <== ID
                renderItem={this.renderItem} />
          </View>
        </View>
      </View>
    );
  }
  
  renderItem = ({ item }) => (
    <View style={styles.list}>
      <View style={styles.listList}>
      <View style={styles.listInfo}>
        <View style={styles.listInfoHeader}>
          <Text style={styles.listInfoTitle}>Paciente:</Text>
          <Text style={styles.listInfoTitle}>Médico:</Text>
          <Text style={styles.listInfoTitle}>Data:</Text>
          <Text style={styles.listInfoTitle}>Situação:</Text>
        </View>
        <View style={styles.listInfoBody}>
          <Text style={styles.listInfoText}>{(item.idPacienteNavigation.nomePaciente)}</Text>
          <Text style={styles.listInfoText}>{(item.idMedicoNavigation.nomeMedico) + ' ' + (item.idMedicoNavigation.sobrenomeMedico)}</Text>
          <Text style={styles.listInfoText}>{item.datahoraConsulta}</Text>
          <Text style={styles.listInfoText}>{(item.idSituacaoNavigation.descricao)}</Text>
        </View>
      </View>
      <View style={styles.listDesc}>
        <View style={styles.listDescHeader}>
          <Text style={styles.listDescTitle}>Descrição</Text>
        </View>
        <View style={styles.listDescBody}>
          <Text style={styles.listDescText}>TESTE TESTE TESTE TESTE teste teste teste teste{item.descricao}</Text>
        </View>
        </View>
      </View>
      {/* <View style={styles.listDivisor} /> */}
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
    fontFamily: 'Roboto Slab',
    fontWeight: 'bold',
    color: '#1AE0B4'
  },

  body: {
    // flex: 4,
    // alignItems: 'center',
    backgroundColor: '#90ee90'
  }, 

  list: {
    // flex: 4,
    backgroundColor: '#3582FF',
    // width: '80%',
    // height: 160,
    borderColor: '#ff2400',
    flexDirection: 'column',
    justifyContent: 'space-between',
    paddingTop: 10,
    width: '100%'
  },

  listList: {
    flexDirection: 'row'
  },

  listInfo: {
    width: '50%',
    flexDirection: 'row'
  },

  listInfoHeader: {
    flexDirection: 'column',
    borderColor: '#ff200'
  },

  listInfoTitle: {
    fontFamily: 'Roboto Slab',
    fontSize: 18,
    paddingLeft: 10,
    paddingRight: 10,
    paddingBottom: 5,
    paddingTop: 5,

    // backgroundColor: '#ffff00'
  },

  listInfoBody: {
    flexDirection: 'column',
    justifyContent: 'space-between'
    // height: '20%'
  },

  listInfoText: {
    fontFamily: 'Roboto',
    fontStyle: 'italic',
    fontWeight: 'normal',
    fontSize: 13,
    lineHeight: 12,
    display: 'flex',
    alignItems: 'center',
    textAlign: 'left',
    color: '#fff',
    letterSpacing: 2,
    marginTop: 8,
    width: 90,
    height: 20
    // position: 'absolute'
  },

  listDesc: {
    width: '50%',
    flexDirection: 'column'
  },

  listDescHeader: {
    alignItems: 'center'
  },

  listDescTitle: {
    color: '#fff',
    marginTop: 2,
  },

  // listDivisor: {
  //   paddingTop: 10,
  //   width: '100%',
  //   borderBottomColor: '#ff2400',
  //   borderBottomWidth: 3
  // },
});
