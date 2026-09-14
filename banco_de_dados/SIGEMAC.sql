/*
SIGEMAC - Sistema Gerenciador de Materias de Construção
Nome:
Gabriel Neumann de Oliveira
João Paulo Pereira Coria
Kalebe Santos Bernabe
Marcos Eduardo Ribeiro Souza
Maria Eduarda Reis
Miguel Tavares Ribeiro
*/

CREATE DATABASE SIGEMAC;
USE SIGEMAC;

CREATE TABLE Estado (
idEstado INT AUTO_INCREMENT,
nome_est VARCHAR(45),
sigla_est VARCHAR(2),
PRIMARY KEY (idEstado)
);

CREATE TABLE Cidade (
idCidade INT AUTO_INCREMENT,
nome_cid VARCHAR(45),
Estado_idEstado INT,
PRIMARY KEY (idCidade),
FOREIGN KEY (Estado_idEstado) REFERENCES Estado(idEstado)
);

CREATE TABLE Endereco (
idEndereco_end INT AUTO_INCREMENT,
numero_end INT,
logradouro_end VARCHAR(45),
bairro_end VARCHAR(45),
Cidade_idCidade INT,
PRIMARY KEY (idEndereco_end),
FOREIGN KEY (Cidade_idCidade) REFERENCES Cidade(idCidade)
);

CREATE TABLE Cliente (
idCliente_cli INT AUTO_INCREMENT,
nome_cli VARCHAR(45),
data_nasc_cli DATE,
email_cli VARCHAR(45),
telefone_cli VARCHAR(45),
observacao_cli VARCHAR(45),
cpf_cli VARCHAR(11),
Endereco_idEndereco_end INT,
PRIMARY KEY (idCliente_cli),
FOREIGN KEY (Endereco_idEndereco_end) REFERENCES Endereco(idEndereco_end)
);

CREATE TABLE Entregador (
idEntregador_entr INT AUTO_INCREMENT,
nome_entr VARCHAR(45),
telefone_entr VARCHAR(45),
data_nasc_entr DATE,
cnh_entr VARCHAR(45),
descricao_entr VARCHAR(45),
data_cadastro DATE,
PRIMARY KEY (idEntregador_entr)
);

CREATE TABLE Fornecedor (
idFornecedor_forn INT AUTO_INCREMENT,
nome_forn VARCHAR(45),
cnpj_forn VARCHAR(14),
telefone_forn VARCHAR(45),
email_forn VARCHAR(45),
PRIMARY KEY (idFornecedor_forn)
);

CREATE TABLE Produto (
idProduto_pro INT AUTO_INCREMENT,
nome_pro VARCHAR(45),
quantidade_pro INT,
preco_pro DECIMAL(10,2),
descricao_pro VARCHAR(45),
Fornecedor_idFornecedor_forn INT,
PRIMARY KEY (idProduto_pro),
FOREIGN KEY (Fornecedor_idFornecedor_forn) REFERENCES Fornecedor(idFornecedor_forn)
);

CREATE TABLE Venda (
idVenda_vend INT AUTO_INCREMENT,
data_registro_vend DATE,
descricao_vend VARCHAR(45),
Cliente_idCliente_cli INT,
Produto_idProduto_pro INT,
Entregador_idEntregador_entr INT,
PRIMARY KEY (idVenda_vend),
FOREIGN KEY (Cliente_idCliente_cli) REFERENCES Cliente(idCliente_cli),
FOREIGN KEY (Produto_idProduto_pro) REFERENCES Produto(idProduto_pro),
FOREIGN KEY (Entregador_idEntregador_entr) REFERENCES Entregador(idEntregador_entr)
);

CREATE TABLE Registro (
idRegistro_reg INT AUTO_INCREMENT,
status_reg VARCHAR(45),
Cliente_idCliente_cli INT,
Venda_idVenda_vend INT,
Entregador_idEntregador_entr INT,
PRIMARY KEY (idRegistro_reg),
FOREIGN KEY (Cliente_idCliente_cli) REFERENCES Cliente(idCliente_cli),
FOREIGN KEY (Venda_idVenda_vend) REFERENCES Venda(idVenda_vend),
FOREIGN KEY (Entregador_idEntregador_entr) REFERENCES Entregador(idEntregador_entr)
);

INSERT INTO Estado VALUES (DEFAULT, "Rondônia", "RO");
INSERT INTO Estado VALUES (DEFAULT, "Amazonas", "AM");
INSERT INTO Estado VALUES (DEFAULT, "Acre", "AC");
INSERT INTO Estado VALUES (DEFAULT, "Mato Grosso", "MT");
INSERT INTO Estado VALUES (DEFAULT, "Pará", "PA");

INSERT INTO Cidade VALUES (DEFAULT, "Ji-Paraná", 1);
INSERT INTO Cidade VALUES (DEFAULT, "Manaus", 2);
INSERT INTO Cidade VALUES (DEFAULT, "Cacoal", 1);
INSERT INTO Cidade VALUES (DEFAULT, "Tocantins", 5);
INSERT INTO Cidade VALUES (DEFAULT, "Ariquemes", 1);

INSERT INTO Endereco VALUES (DEFAULT, 256, "Perto da Igreja", "jardim dos Migrantes", 1);
INSERT INTO Endereco VALUES (DEFAULT, 1234, "Na frente do Irmãos Gonçalves", "Arara Azul", 3);
INSERT INTO Endereco VALUES (DEFAULT, 923, "Em cima da Americanas", "Passáro branco", 1);
INSERT INTO Endereco VALUES (DEFAULT, 632, "Na frente da farmácia", "Quadrado Redondo", 1);
INSERT INTO Endereco VALUES (DEFAULT, 677, "Perto da quadra", "Machado de Assis", 2);

INSERT INTO Cliente VALUES (DEFAULT, "Maria das Abobrinhas", "2002-06-12", "maria@email.com", "6993730889", "Cliente frequente", "14538220620", 1);
INSERT INTO Cliente VALUES (DEFAULT, "Joao da Silva", "1999-03-25", "joao@email.com", "69981234567", "Cliente novo", "12345678901", 2);
INSERT INTO Cliente VALUES (DEFAULT, "Ana Souza", "2001-11-08", "ana@email.com", "69987654321", "Cliente frequente", "98765432100", 3);
INSERT INTO Cliente VALUES (DEFAULT, "Carlos Oliveira", "1998-07-19", "carlos@email.com", "69992345678", "Cliente antigo", "45678912300", 4);
INSERT INTO Cliente VALUES (DEFAULT, "Juliana Santos", "2003-01-30", "juliana@email.com", "69993456789", "Cliente frequente", "32165498700", 5);

INSERT INTO Entregador VALUES (DEFAULT, "Pedro Almeida", "69991112222", "1995-04-15", "RO1234567", "Entregador experiente", "2026-08-01");
INSERT INTO Entregador VALUES (DEFAULT, "Lucas Ferreira", "69992223333", "1998-09-20", "RO2345678", "Entregador novo", "2026-08-02");
INSERT INTO Entregador VALUES (DEFAULT, "Rafael Costa", "69993334444", "1996-02-10", "RO3456789", "Entregador rapido", "2026-08-03");
INSERT INTO Entregador VALUES (DEFAULT, "Bruno Martins", "69994445555", "1997-12-05", "RO4567890", "Entregador experiente", "2026-08-04");
INSERT INTO Entregador VALUES (DEFAULT, "Gabriel Souza", "69995556666", "2000-06-25", "RO5678901", "Entregador novo", "2026-08-05");

INSERT INTO Fornecedor VALUES (DEFAULT, "Fornecedor Amazonia", "12345678000101", "69991111111", "contato@amazonia.com");
INSERT INTO Fornecedor VALUES (DEFAULT, "Distribuidora Brasil", "23456789000102", "69992222222", "contato@distribuidorabrasil.com");
INSERT INTO Fornecedor VALUES (DEFAULT, "Mercantil Norte", "34567890000103", "69993333333", "contato@mercantilnorte.com");
INSERT INTO Fornecedor VALUES (DEFAULT, "Produtos Rondônia", "45678901000104", "69994444444", "contato@produtosro.com");
INSERT INTO Fornecedor VALUES (DEFAULT, "Comercial Central", "56789012000105", "69995555555", "contato@comercialcentral.com");

INSERT INTO Produto VALUES (DEFAULT, "Arroz", 50, 25.90, "Arroz tipo 1", 1);
INSERT INTO Produto VALUES (DEFAULT, "Feijão", 40, 8.50, "Feijão carioca", 2);
INSERT INTO Produto VALUES (DEFAULT, "Macarrão", 60, 5.99, "Macarrão espaguete", 3);
INSERT INTO Produto VALUES (DEFAULT, "Açúcar", 35, 4.75, "Açúcar cristal", 4);
INSERT INTO Produto VALUES (DEFAULT, "Café", 45, 16.90, "Café tradicional", 5);

INSERT INTO Venda VALUES (DEFAULT, "2026-08-01", "Venda de arroz", 1, 1, 1);
INSERT INTO Venda VALUES (DEFAULT, "2026-08-02", "Venda de feijão", 2, 2, 2);
INSERT INTO Venda VALUES (DEFAULT, "2026-08-03", "Venda de macarrão", 3, 3, 3);
INSERT INTO Venda VALUES (DEFAULT, "2026-08-04", "Venda de açúcar", 4, 4, 4);
INSERT INTO Venda VALUES (DEFAULT, "2026-08-05", "Venda de café", 5, 5, 5);

INSERT INTO Registro VALUES (DEFAULT, "Entregue", 1, 1, 1);
INSERT INTO Registro VALUES (DEFAULT, "Em transporte", 2, 2, 2);
INSERT INTO Registro VALUES (DEFAULT, "Preparando", 3, 3, 3);
INSERT INTO Registro VALUES (DEFAULT, "Entregue", 4, 4, 4);
INSERT INTO Registro VALUES (DEFAULT, "Em transporte", 5, 5, 5);