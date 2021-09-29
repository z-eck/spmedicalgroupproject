CREATE DATABASE SP_MEDICAL_GROUP;
GO

USE SP_MEDICAL_GROUP;
GO

-- Tabela criada para se focada a especialidades dos m�dicos
CREATE TABLE ESPECIALIDADE (
	
	idEspecialidade SMALLINT PRIMARY KEY IDENTITY(1,1),
	especialidade VARCHAR(50) NOT NULL UNIQUE

);
GO

-- Tabela criada para colocar as informa��es da cl�nica
CREATE TABLE CLINICA (

	idClinica TINYINT PRIMARY KEY IDENTITY(1,1),
	nomeClinica VARCHAR(50) NOT NULL UNIQUE,
	cnpj CHAR(18) NOT NULL UNIQUE,
	razaoSocial VARCHAR(50) NOT NULL,
	enderecoClinica VARCHAR(256) NOT NULL UNIQUE

);
GO

-- Tabela criada para as informa��es dos m�dicos
CREATE TABLE MEDICO (
	
	idMedico SMALLINT PRIMARY KEY IDENTITY(1,1),
	idEspecialidade SMALLINT FOREIGN KEY REFERENCES ESPECIALIDADE(idEspecialidade),
	idClinica TINYINT FOREIGN KEY REFERENCES CLINICA(idClinica),
	nomeMedico VARCHAR(30) NOT NULL,
	sobrenomeMedico VARCHAR(30) NOT NULL,
	crm CHAR(8) NOT NULL UNIQUE,
	email VARCHAR(300) NOT NULL UNIQUE

);
GO

-- Tabela criada para especificar o endere�o dos pacientes, desej�vel ser um endere�o �nico, e se houver repetidos, apenas utilizar a ID correspondente
CREATE TABLE ENDERECO (

	idEndereco INT PRIMARY KEY IDENTITY(1,1),
	lugadouro VARCHAR(15),
	endereco VARCHAR(250) NOT NULL,
	bairro VARCHAR(100),
	cidade VARCHAR(50) NOT NULL,
	uf CHAR(2) NOT NULL,
	cep CHAR(9) NOT NULL UNIQUE

);
GO


-- Tabela criada para as informa��es dos pacientes. Adicionado o n�mero de endere�o nesta tabela, visto que � melhor deixar o endere�o global, enquanto o n�mero ser algo mais exato
CREATE TABLE PACIENTE (

	idPaciente INT PRIMARY KEY IDENTITY(1,1),
	idEndereco INT FOREIGN KEY REFERENCES ENDERECO(idEndereco),
	nomePaciente VARCHAR(30) NOT NULL,
	dataNascimento DATE,
	email VARCHAR(300) NOT NULL UNIQUE,
	dddTelefone CHAR(2),
	numeroTelefone VARCHAR(10),
	rg CHAR(10) NOT NULL UNIQUE,
	cpf CHAR(11) NOT NULL UNIQUE,
	numeroEndereco VARCHAR(6) NOT NULL

);
GO

-- Tabela criada apenas para indicar a situa��o do agendamento
CREATE TABLE SITUACAO (

	idSituacao TINYINT PRIMARY KEY IDENTITY,
	descricao VARCHAR(25) NOT NULL UNIQUE

);
GO

-- Tabela criada para informar o paciente que ser� atendido, o m�dico que o atender�, a data de quando foi ou ser�, e a situa��o se foi atendido, cancelado ou est� agendada
CREATE TABLE AGENDAMENTO (

	idAgendamento INT PRIMARY KEY IDENTITY(1,1),
	idMedico SMALLINT FOREIGN KEY REFERENCES MEDICO(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
	idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao),
	datahoraConsulta DATETIME

);
GO

-- PARTES ADICIONADAS PARA A SPRINT 2 (BACK-END)

-- Remo��o da parte de email na tabela de MEDICO e de PACIENTE
ALTER TABLE MEDICO
DROP COLUMN email
GO

ALTER TABLE PACIENTE
DROP COLUMN email
GO

-- Tabela Criada para definir o tipo de usu�rio logado na API
CREATE TABLE TIPOUSUARIO (

	idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
	descricaoTipoUsuario VARCHAR(50) NOT NULL UNIQUE

);
GO

-- Tabela Criada para a cria��o de usu�rios no sistema, utilizando um email pessoal ou da cl�nica
CREATE TABLE USUARIO (

	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	idMedico SMALLINT FOREIGN KEY REFERENCES MEDICO(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
	nomeUsuario VARCHAR(100) NOT NULL,
	email VARCHAR(300) UNIQUE NOT NULL,
	senha VARCHAR(16) NOT NULL CHECK(len(senha) >= 8)

);
GO