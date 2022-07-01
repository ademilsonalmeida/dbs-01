use dbs01;

CREATE TABLE Clientes (
	Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (100) NOT NULL,
	Cpf VARCHAR(11) NOT NULL,
	UF VARCHAR(2) NOT NULL,
	Celular VARCHAR(11) NOT NULL 
);

CREATE TABLE TiposFinanciamentos (
	Id INT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(30) NOT NULL
);

CREATE TABLE Financiamentos (
	Id INT PRIMARY KEY IDENTITY,
	IdCliente INT NOT NULL,
	IdTipoFinanciamento INT NOT NULL,
	ValorTotal NUMERIC(15,2) NOT NULL,
	DataUltimoVencimento Date NOT NULL,
	FOREIGN KEY (IdCliente) REFERENCES Clientes(Id),
	FOREIGN KEY (IdTipoFinanciamento) REFERENCES TiposFinanciamentos(Id)
);

CREATE TABLE Parcelas (
	Codigo INT PRIMARY KEY IDENTITY,
	IdFinanciamento INT NOT NULL,
	NumeroParcela INT NOT NULL,
	ValorParcela NUMERIC(15,2) NOT NULL,
	DataVencimento DATE NOT NULL,
	DataPagamento DATE,
	FOREIGN KEY (IdFinanciamento) REFERENCES Financiamentos(Id)
);

