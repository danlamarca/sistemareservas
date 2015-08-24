BEGIN TRANSACTION
USE SistemaReservas
Print 'Carga inicial nas tabelas'  

--TB_MENSAGEM
IF NOT EXISTS(SELECT * FROM TB_MENSAGEM WITH(NOLOCK) WHERE COD='0')
BEGIN
	insert into TB_MENSAGEM values(0,'Atenção!')
END

IF NOT EXISTS(SELECT * FROM TB_MENSAGEM WITH(NOLOCK) WHERE COD='01')
BEGIN
	insert into TB_MENSAGEM values(01,'Deseja confirmar reservar?(S/N)')
END

----------------------------------------------------------------------
--TB_USUARIO
SET IDENTITY_INSERT TB_USUARIO ON
IF NOT EXISTS(SELECT * FROM TB_USUARIO WITH(NOLOCK) WHERE Codusuario='1')
BEGIN
	insert into TB_USUARIO(Codusuario,Nome,Matricula) values('1','Danilo','123')
END
SET IDENTITY_INSERT TB_USUARIO OFF

Print 'Finalização Carga inicial nas tabelas'

IF @@ERROR<>0
	ROLLBACK
ELSE
	COMMIT 
	  


