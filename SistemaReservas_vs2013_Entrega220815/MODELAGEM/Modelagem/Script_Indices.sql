PRINT 'Criando Database SistemaReservas'

IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME='SistemaReservas')
BEGIN
	CREATE DATABASE SistemaReservas 
END  

PRINT 'Finaliza��o da cria��o da Database SistemaReservas'
 