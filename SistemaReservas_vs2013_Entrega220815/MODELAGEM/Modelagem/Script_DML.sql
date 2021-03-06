USE SistemaReservas

BEGIN TRANSACTION
Print 'Carga inicial nas tabelas'  

--TB_MENSAGEM 
IF NOT EXISTS(SELECT * FROM TB_MENSAGEM WITH(NOLOCK) WHERE COD='0')
BEGIN
	insert into TB_MENSAGEM values(0,'Aten��o!')
END

IF NOT EXISTS(SELECT * FROM TB_MENSAGEM WITH(NOLOCK) WHERE COD='01')
BEGIN
	insert into TB_MENSAGEM values(01,'Deseja confirmar reservar?(S/N)') 
END

IF NOT EXISTS(SELECT * FROM TB_MENSAGEM WITH(NOLOCK) WHERE COD='02')
BEGIN
	insert into TB_MENSAGEM values(2,'Erro no Processamento da P�gina, favor informar o codigo do erro ao respons�vel: Danilo Moreira, tel.: 11-953648750,email: danilo.lamarca@hotmail.com. Codigo do ERRO: [PARAM1]') 
END


--TB_USUARIO
SET IDENTITY_INSERT TB_USUARIO ON
IF NOT EXISTS(SELECT * FROM TB_USUARIO WITH(NOLOCK) WHERE Codusuario='1')
BEGIN
	insert into TB_USUARIO(Codusuario,Nome,Matricula,Endereco) values('1','Danilo','123','Maria do Carmo 820')
END
SET IDENTITY_INSERT TB_USUARIO OFF


--TB_ACOMPANHAMENTO_ITEM
IF NOT EXISTS(SELECT * FROM TB_ACOMPANHAMENTO_ITEM WITH(NOLOCK) WHERE item='Caf� + a�ucar')
BEGIN
	insert into TB_ACOMPANHAMENTO_ITEM(item,descricao) values('Caf� + a�ucar','Caf� com a�ucar')
END

IF NOT EXISTS(SELECT * FROM TB_ACOMPANHAMENTO_ITEM WITH(NOLOCK) WHERE item='Caf� + ado�ante')
BEGIN
	insert into TB_ACOMPANHAMENTO_ITEM(item,descricao) values('Caf� + ado�ante','Caf� com ado�ante')
END

IF NOT EXISTS(SELECT * FROM TB_ACOMPANHAMENTO_ITEM WITH(NOLOCK) WHERE item='Ch� + ado�ante')
BEGIN
	insert into TB_ACOMPANHAMENTO_ITEM(item,descricao) values('Ch� + ado�ante','Ch� com ado�ante')
END

IF NOT EXISTS(SELECT * FROM TB_ACOMPANHAMENTO_ITEM WITH(NOLOCK) WHERE item='Ch� + a�ucar')
BEGIN
	insert into TB_ACOMPANHAMENTO_ITEM(item,descricao) values('Ch� + a�ucar','Ch� com a�ucar')
END

IF NOT EXISTS(SELECT * FROM TB_ACOMPANHAMENTO_ITEM WITH(NOLOCK) WHERE item='Leite')
BEGIN
	insert into TB_ACOMPANHAMENTO_ITEM(item,descricao) values('Leite','Leite')
END

--TB_FILIAL
IF NOT EXISTS(SELECT * FROM tb_filial WITH(NOLOCK) WHERE CODFILIAL='1')
BEGIN
	insert into tb_filial(descricao,LOCALIDADE) values('FIL-SP','S�o Paulo')
END

IF NOT EXISTS(SELECT * FROM tb_filial WITH(NOLOCK) WHERE CODFILIAL='2')
BEGIN
	insert into tb_filial(descricao,LOCALIDADE) values('FIL-MG','Minas Gerais')
END

--tb_sala
IF NOT EXISTS(SELECT * FROM tb_sala WITH(NOLOCK) WHERE CODSALA='1')
BEGIN
	insert into tb_sala(CODFILIAL,DESCRICAO) values('1','SL-S�o Paulo')
END

IF NOT EXISTS(SELECT * FROM tb_sala WITH(NOLOCK) WHERE CODSALA='2')
BEGIN
	insert into tb_sala(CODFILIAL,DESCRICAO) values('2','SL-Minas Gerais')
END 

Print 'Finaliza��o Carga inicial nas tabelas'

IF @@ERROR<>0
	ROLLBACK
ELSE
	COMMIT 
	  

-----------------------------------------------------------------------    

Print 'Cria��o das procedures' 

BEGIN TRANSACTION 

--�rea de dele��o das procs:
IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_SEL_TB_MENSAGEM') 
BEGIN	
	drop PROCEDURE dbo.SP_SEL_TB_MENSAGEM	
END

GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_TB_USUARIO_SEL') 
BEGIN	
	drop PROCEDURE dbo.SP_TB_USUARIO_SEL	
END

GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_INS_TB_RESERVA_TEMP') 
BEGIN	
	drop PROCEDURE dbo.SP_INS_TB_RESERVA_TEMP	
END

GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_TB_RESERVA_TEMP_INS') 
BEGIN	
	drop PROCEDURE dbo.SP_TB_RESERVA_TEMP_INS	
END

GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_TB_RESERVA_TEMP_SEL') 
BEGIN	
	drop PROCEDURE dbo.SP_TB_RESERVA_TEMP_SEL	
END

GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_TB_RESERVA_TEMP_DEL') 
BEGIN	
	drop PROCEDURE dbo.SP_TB_RESERVA_TEMP_DEL	
END

GO

IF EXISTS(SELECT * FROM SYS.PROCEDURES WHERE NAME = 'SP_TB_RESERVA_INS') 
BEGIN	
	drop PROCEDURE dbo.SP_TB_RESERVA_INS	
END

GO
--�rea de cria��o das procs:
CREATE PROCEDURE SP_SEL_TB_MENSAGEM
@cod int
As Begin
	Select descricao from TB_MENSAGEM(nolock)
	where cod=@cod
End 

GO

CREATE PROCEDURE SP_TB_USUARIO_SEL
@CODUSUARIO int

As Begin
	Select * from TB_USUARIO with(nolock)
	where CODUSUARIO=@CODUSUARIO
End

GO

CREATE PROCEDURE SP_INS_TB_RESERVA_TEMP
@CODSALA INT,
@CODUSUARIO INT,
@DATAINICIO DATETIME,
@DATAFIM DATETIME,
@DESCRICAO VARCHAR(1000)

  As Begin

	declare @numreserva int
	 --Cria pedido tempor�rio:
	 select @numreserva=SCOPE_IDENTITY () 	 

	 SET IDENTITY_INSERT TB_RESERVA_TEMP ON

	 Insert into TB_RESERVA_TEMP (CODRESERVATEMP,CODSALA,CODUSUARIO,DATAINICIO,DATAFIM,DESCRICAO)
	 values(@numreserva,@CODSALA,@CODUSUARIO,@DATAINICIO,@DATAFIM,@DESCRICAO)

	 SET IDENTITY_INSERT TB_RESERVA_TEMP OFF
	   
	  --return
	  select @numreserva[numped]

  End

 GO


CREATE PROCEDURE SP_TB_RESERVA_TEMP_INS
@acompanhamento int,
@sala int,
@user int,
@data varchar(10),
@horaini varchar(10),
@horafim varchar(10),
@descricao varchar(1000)

/*
set @acompanhamento =1
set @sala =1
set @user =1
set @data ='15-09-2015'
set @horaini ='08:00'
set @horafim ='09:00'
set @descricao =''
*/

As Begin    
	Insert into TB_RESERVA_TEMP(CODSALA,CODUSUARIO,DATAINICIO,DATAFIM,DESCRICAO,CODACOMPANHAMENTOITEM)
	VALUES(@sala, @user, convert(datetime,@data+' '+@horaini,103), convert(datetime,@data+' '+@horafim,103), @descricao, @acompanhamento)	
	
	select SCOPE_IDENTITY()[codreservatemp]
End

GO

CREATE PROCEDURE SP_TB_RESERVA_TEMP_SEL
@codreserva int

As Begin
	Select b.DESCRICAO[sala],
	       c.DESCRICAO[acompanhamento],
		   a.DATAINICIO[dtini],
		   a.DATAFIM[dtfim] 
	from tb_reserva_temp a with(nolock)
	inner join tb_sala b with(nolock)
	  on b.CODSALA = a.CODSALA
    inner join TB_ACOMPANHAMENTO_ITEM c with(nolock)
	  on c.CODACOMPANHAMENTOITEM = a.CODACOMPANHAMENTOITEM
    where a.CODRESERVATEMP= @codreserva
End

GO

CREATE PROCEDURE SP_TB_RESERVA_TEMP_DEL	
@codreserva int

As Begin
	DELETE from tb_reserva_temp where codreservatemp=@codreserva
End

GO

CREATE PROCEDURE SP_TB_RESERVA_INS
@codreserva int

As Begin
	set identity_insert tb_reserva on

	Insert into tb_reserva(CODRESERVA,CODSALA,CODUSUARIO,DATAINICIO,DATAFIM,DESCRICAO,CODACOMPANHAMENTOITEM)
		select @codreserva,CODSALA,CODUSUARIO,DATAINICIO,DATAFIM,DESCRICAO,CODACOMPANHAMENTOITEM
		from TB_RESERVA_TEMP with(nolock)
		where CODRESERVATEMP= @codreserva 
	
	set identity_insert tb_reserva off
End

GO
Print 'Finaliza��o Cria��o das procedures'

IF @@ERROR <>0
	ROLLBACK 
ELSE
	COMMIT 

-----------------------------------------------------------------------