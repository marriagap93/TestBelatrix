# TestBelatrix

1) Crear la BD 'Test' (Respetar mayúsculas y minúsculas), en el SQL Server<br/>
2) Copiar, Pegar  y Ejecutar el siguiente Script para crear la Tabla Log<br/>
/****************************************************************************************/<br/>
USE [Test]<br/>
GO<br/>
CREATE TABLE [dbo].[Log]\(<br/>
	[Id] [int] IDENTITY\(1,1\) NOT NULL,<br/>
	[Message] [text] NULL,<br/>
	[Type] [int] NULL,<br/>
	CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED \([Id] ASC\)<br/>
\)<br/>
/****************************************************************************************/<br/>
3) Modificar en el archivo 'App.Config' las líneas 4 y 8, pertenecientes al 'LogFileDirectory' y al 'ConnectionString' respectivamente.<br/>
4) Ejecutar la aplicación y realizar las pruebas indicando 'Y' o 'N' a las preguntas de la consola.<br/>
<br/>
Michael Arriaga
