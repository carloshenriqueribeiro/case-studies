CREATE DATABASE [INOVECR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'INOVECR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\INOVECR.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'INOVACR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\INOVECR_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )

USE [INOVECR]

CREATE TABLE [dbo].[Clientes] (
    [ClienteId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [Nome] [varchar](45),
    [CPF] [varchar](20),
    [Endereco] [varchar](100),
    [Email] [varchar](50)
)
CREATE TABLE [dbo].[Pedidos] (
    [PedidoId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [Descricao] [nvarchar](45),
    [TipoPedido] [int] NOT NULL,
    [Cliente_Id] [int] NOT NULL,
	CONSTRAINT fk_Pedido_Cliente_idx FOREIGN KEY (Cliente_Id) REFERENCES Clientes(ClienteId)
)


CREATE TABLE [dbo].[PedidoItem] (
    [PedidoItemId] [int] PRIMARY KEY NOT NULL IDENTITY,
    [Descricao] [nvarchar](45),
    [Valor] [decimal](18, 2) NOT NULL,
    [Pedido_PedidoId] [int],
	[Pedido_ClienteId] [int],
	CONSTRAINT fk_PedidoItem_Pedido1_idx FOREIGN KEY (Pedido_PedidoId) REFERENCES Pedidos(PedidoId)
)