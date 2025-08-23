CREATE DATABASE NotaFiscal;
GO
USE NotaFiscal;
GO

CREATE TABLE Nota_Fiscal(
   Nro_nota INT IDENTITY(1,1) PRIMARY KEY,  -- auto_increment no SQL Server
   Nm_cliente VARCHAR(100) NOT NULL,
   Nm_vendedor VARCHAR(100) NOT NULL,
   Dt_emissao DATETIME DEFAULT GETDATE(),  -- equivalente ao current_timestamp
   Vl_total FLOAT NOT NULL
)
GO

CREATE TABLE Produto(
   Codigo INT IDENTITY(1,1) PRIMARY KEY,
   Nm_produto VARCHAR(100) NOT NULL,
   Medidas VARCHAR(20) NOT NULL,
   Valor FLOAT NOT NULL
)
GO

CREATE TABLE Item_NF(
    Nro_nota INT NOT NULL,
    Codigo INT NOT NULL,
    Qtd INT NOT NULL,
    Valor_unitario INT NOT NULL,
    Valor_total INT NOT NULL,

    CONSTRAINT FK_NotaFiscal PRIMARY KEY (Nro_nota, Codigo),

    CONSTRAINT FK_Nro_nota FOREIGN KEY (Nro_nota)
        REFERENCES Nota_Fiscal (Nro_nota),
    CONSTRAINT FK_codigo FOREIGN KEY (Codigo)
        REFERENCES Produto (Codigo)
)

INSERT INTO Nota_Fiscal(Nro_nota, Nm_cliente, Nm_vendedor, Dt_emissao, Vl_total)
values();