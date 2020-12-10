CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Naziv] CHAR(20) NOT NULL, 
    [Opis] NCHAR(50) NOT NULL, 
    [Kategorija] NCHAR(20) NOT NULL, 
    [Proizvodjac] NCHAR(20) NOT NULL, 
    [Dobavljac] NCHAR(20) NOT NULL, 
    [Cena] INT NOT NULL
)
