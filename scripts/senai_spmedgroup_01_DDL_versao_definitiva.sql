CREATE DATABASE SP_MEDICAL_GROUP;
GO

USE SP_MEDICAL_GROUP;
GO

-- Tabela criada para se focada a especialidades dos médicos
CREATE TABLE ESPECIALIDADE (
	
	idEspecialidade SMALLINT PRIMARY KEY IDENTITY(1,1),
	especialidade VARCHAR(50) NOT NULL UNIQUE

);
GO

-- Tabela criada para colocar as informações da clínica
CREATE TABLE CLINICA (

	idClinica TINYINT PRIMARY KEY IDENTITY(1,1),
	nomeClinica VARCHAR(50) NOT NULL UNIQUE,
	cnpj CHAR(18) NOT NULL UNIQUE,
	razaoSocial VARCHAR(50) NOT NULL,
	enderecoClinica VARCHAR(256) NOT NULL UNIQUE

);
GO

-- Tabela criada para as informações dos médicos
CREATE TABLE MEDICO (
	
	idMedico SMALLINT PRIMARY KEY IDENTITY(1,1),
	idEspecialidade SMALLINT FOREIGN KEY REFERENCES ESPECIALIDADE(idEspecialidade),
	idClinica TINYINT FOREIGN KEY REFERENCES CLINICA(idClinica),
	nomeMedico VARCHAR(30) NOT NULL,
	sobrenomeMedico VARCHAR(30) NOT NULL,
	crm CHAR(8) NOT NULL UNIQUE,

);
GO

-- Tabela criada para especificar o endereço dos pacientes, desejável ser um endereço único, e se houver repetidos, apenas utilizar a ID correspondente
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


-- Tabela criada para as informações dos pacientes. Adicionado o número de endereço nesta tabela, visto que é melhor deixar o endereço global, enquanto o número ser algo mais exato
CREATE TABLE PACIENTE (

	idPaciente INT PRIMARY KEY IDENTITY(1,1),
	idEndereco INT FOREIGN KEY REFERENCES ENDERECO(idEndereco),
	nomePaciente VARCHAR(30) NOT NULL,
	dataNascimento DATE,
	dddTelefone CHAR(2),
	numeroTelefone VARCHAR(10),
	rg CHAR(10) NOT NULL UNIQUE,
	cpf CHAR(11) NOT NULL UNIQUE,
	numeroEndereco VARCHAR(6) NOT NULL

);
GO

-- Tabela criada apenas para indicar a situação do agendamento
CREATE TABLE SITUACAO (

	idSituacao TINYINT PRIMARY KEY IDENTITY,
	descricao VARCHAR(25) NOT NULL UNIQUE

);
GO

-- Tabela criada para informar o paciente que será atendido, o médico que o atenderá, a data de quando foi ou será, e a situação se foi atendido, cancelado ou está agendada
CREATE TABLE AGENDAMENTO (

	idAgendamento INT PRIMARY KEY IDENTITY(1,1),
	idMedico SMALLINT FOREIGN KEY REFERENCES MEDICO(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
	idSituacao TINYINT FOREIGN KEY REFERENCES SITUACAO(idSituacao),
  descricao VARCHAR(300),
	datahoraConsulta DATETIME

);
GO

-- Tabela Criada para definir o tipo de usuário logado na API
CREATE TABLE TIPOUSUARIO (

	idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
	descricaoTipoUsuario VARCHAR(50) NOT NULL UNIQUE

);
GO

-- Tabela Criada para a criação de usuários no sistema, utilizando um email pessoal ou da clínica
CREATE TABLE USUARIO (

	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario TINYINT FOREIGN KEY REFERENCES TIPOUSUARIO(idTipoUsuario),
	idMedico SMALLINT FOREIGN KEY REFERENCES MEDICO(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES PACIENTE(idPaciente),
	email VARCHAR(300) UNIQUE NOT NULL,
	senha VARCHAR(16) NOT NULL CHECK(len(senha) >= 8)

);
GO
