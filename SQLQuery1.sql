Create Database CadastroClientes

Create Table tbcadusuarios (
id int identity(1,1),
nome varchar(50),
telefone varchar(20),
Primary Key (id)
)

use CadastroClientes

select * from tbcadusuarios