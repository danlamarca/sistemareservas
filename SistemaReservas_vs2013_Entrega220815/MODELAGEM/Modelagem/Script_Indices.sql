PRINT 'Criando Database SistemaReservas'

IF NOT EXISTS(SELECT * FROM SYS.DATABASES WHERE NAME='SistemaReservas')
BEGIN
	CREATE DATABASE SistemaReservas 
END  

PRINT 'Finalização da criação da Database SistemaReservas'
 