-- Listagem das Especialidades
SELECT especialidade [Especialidade] FROM ESPECIALIDADE
GO

-- Listagem dos M�dicos
SELECT	crm [CRM], 
		nomeMedico [Nome], 
		sobrenomeMedico [Sobrenome], 
		email [Email], 
		especialidade [Especialidade], 
		nomeClinica [Cl�nica] , 
		cnpj [CNPJ], 
		razaoSocial [Raz�o Social], 
		enderecoClinica [Endere�o] 
FROM MEDICO M
INNER JOIN ESPECIALIDADE E ON (M.idEspecialidade = E.idEspecialidade)
INNER JOIN CLINICA C ON (M.idClinica = C.idClinica)

-- Listagem dos Prontu�rios
SELECT	nomePaciente [Nome],
		email [Email],
		dataNascimento [Data_Nascimento],
		dddTelefone [DDD],
		numeroTelefone [Telefone],
		rg [RG],
		cpf [CPF],
		lugadouro [Lugadouro],
		endereco [Endere�o],
		numeroEndereco [N�mero],
		bairro [Bairro],
		cidade [Cidade],
		uf [Estado],
		cep [CEP]
FROM PACIENTE P
LEFT JOIN ENDERECO E ON (P.idEndereco = E.idEndereco)

-- Listagem das Consultas
SELECT	nomePaciente [Prontu�rio],
		nomeMedico [Medico],
		sobrenomeMedico [--],
		datahoraConsulta [Data_Consulta],
		descricao [Situa��o]
FROM AGENDAMENTO A
INNER JOIN PACIENTE P ON (A.idPaciente = P.idPaciente)
INNER JOIN MEDICO M ON (A.idMedico = M.idMedico)
INNER JOIN SITUACAO S ON (A.idSituacao = S.idSituacao)