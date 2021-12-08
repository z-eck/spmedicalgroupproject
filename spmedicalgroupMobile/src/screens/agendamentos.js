import React, { Component } from 'react';
import {
  FlatList,
  ImageBackground,
  StyleSheet,
  Text,
  View,
} from 'react-native';

import api from '../services/api';

// Começarei a digitar as funções e o que vier dentro em inglês, porém, manterei as anotações em PT-BR :D

export default class App extends Component {
  constructor(props){
    super(props);
    this.state = {
      listAgendamentos : [],
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
        <ImageBackground
        source={require('../../assets/img/paciente-background.png')}
        style={StyleSheet.absoluteFillObject}>
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
      </ImageBackground>
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
      <View style={styles.listDivisor} />
      <View style={styles.listDesc}>
        <View style={styles.listDescHeader}>
          <Text style={styles.listDescTitle}>Descrição</Text>
        </View>
        <View style={styles.listDescBody}>
          <Text style={styles.listDescText}>TESTE TESTE TESTE TESTE teste teste teste teste BHAHEKJBAJEHKNG,BEAJNFEABKN M,AEBN, FEAJF{item.descricao}</Text>
        </View>
        </View>
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
    borderColor: '#ff2400',
    flexDirection: 'column',
    justifyContent: 'space-between',
    width: '100%'
  },

  listList: {
    flexDirection: 'row',
    paddingTop: 10,
    justifyContent: 'space-between'
  },

  listInfo: {
    width: '49%',
    flexDirection: 'row',
    backgroundColor: '#3582FF',
  },

  listInfoHeader: {
    flexDirection: 'column',
    borderColor: '#ff200',
    justifyContent: 'space-between'
  },

  listInfoTitle: {
    fontFamily: 'Roboto Slab',
    fontWeight: 'bold',
    fontSize: 14,
    marginTop: 8,
    lineHeight: 10,
    paddingLeft: 10,
    paddingRight: 10,
    paddingBottom: 5,
    paddingTop: 5,
  },

  listInfoBody: {
    flexDirection: 'column',
    justifyContent: 'space-between'
  },

  listInfoText: {
    alignItems: 'center',
    color: '#fff',
    fontFamily: 'Roboto',
    fontSize: 14,
    fontStyle: 'italic',
    fontWeight: 'normal',
    height: 30,
    letterSpacing: 2,
    lineHeight: 11,
    marginTop: 8,
    paddingBottom: 5,
    paddingTop: 5,
    textAlign: 'left',
    width: 90,
  },

  listDivisor: {
    paddingTop: 10,
    width: '2%',
    height: '100%',
    backgroundColor: '#000'
  },

  listDesc: {
    width: '49%',
    flexDirection: 'column',
    backgroundColor: '#3582FF',
  },

  listDescHeader: {
    alignItems: 'center'
  },

  listDescTitle: {
    color: '#000',
    marginTop: 2,
  },

  listDescText: {
    color: '#fff',
    paddingLeft: 8
  },
});
