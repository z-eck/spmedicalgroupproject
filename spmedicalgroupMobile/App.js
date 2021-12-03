import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  View,
} from 'react-native';

export default class App extends Component {
  render() {
    return (
      <View style={styles.container}>
        <View style={styles.header}>
          <Text style={styles.headerText}>Agendamentos</Text>
        </View >
      </View >
    );
  }
};

const styles = StyleSheet.create({
  header: {
    alignItems: 'center'
  },
  
  main: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center'    
  },

  headerText: {
    fontSize: 30,
    fontWeight: 'bold',
    color: 'blue'
  }
});
