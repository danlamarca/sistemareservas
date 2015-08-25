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


--TB_USUARIO
SET IDENTITY_INSERT TB_USUARIO ON
IF NOT EXISTS(SELECT * FROM TB_USUARIO WITH(NOLOCK) WHERE Codusuario='1')
BEGIN
	insert into TB_USUARIO(Codusuario,Nome,Matricula) values('1','Danilo','123')
END
SET IDENTITY_INSERT TB_USUARIO OFF

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
--�rea de cria��o das procs:
CREATE PROCEDURE SP_SEL_TB_MENSAGEM
@cod int
As Begin
	Select descricao from TB_MENSAGEM(nolock)
	where cod=@cod
End 

GO

Print 'Finaliza��o Cria��o das procedures'

IF @@ERROR <>0
	ROLLBACK 
ELSE
	COMMIT 

-----------------------------------------------------------------------