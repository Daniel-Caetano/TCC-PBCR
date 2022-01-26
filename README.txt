Projeto de TCC para o protocolo Bicicleta de Rodinhas da Aliare
Data inicio 13/01/2022

Sistema para gerar um RECIBO em PDF
LINK PROJETO

https://github.com/Daniel-Caetano/TCC-PBCR

SCRIPT para rodar o sistema
Instalar banco de dados no Docker
-1: Instalar o Docker
-2: Instalar o https://docs.docker.com/desktop/windows/wsl/
-3: Abrir o CMD e digitar o comando a baixo
-->> docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Tccpbcr123@ ' -p 1401:1433 --name TCC_PBCR -d mcr.microsoft.com/mssql/server:2017-latest  <<---
-4: Fazer conexão com IDE mssql 
-5: Abrir o Docker e colocar para rodar o container criado pelo comando do passo 3 
-6: Criar como conexão localhost, 1401 , usuario 'sa' e senha Tccpbcr123@ como na figura "conexão_mssqlserver" na pasta \TCC-PBCR\ERP.BD
-7: Rodar o script geral do banco de dados ou fazer a restauração , ambos estão em \TCC-PBCR\ERP.BD
-8: Abrir o projeto ERP.Console.sln localizado em TCC-PBCR\ERP.Back
-9: Utilizar o ERP.Api como projeto de inicialização padrão
-10: Rodar o IIES para ligar o servidor de APIs , vai abrir o swagger automático
-11: Abrir o projeto ERP.View.sln localizado em TCC-PBCR\ERP.Back localizado em ERP.Front\ERP.View
-12: Colocar o ERP.View como projeto de inicialização padrão
-13: Sistema iniciado


Grupo 1
Autores: Alan Soares
         Bruno Cesar
         Daniel Caetano
         Gerson Otavio 
         Guilherme Gomes

Credenciais

Nome: Bruno Cesar de Oliveira 
email: brunocesardeoliveira2018@gmail.com
Funções:Analista Desenvolvimento-Front-End

Nome:Alan Soares da Costa
email:alan.kostta14@gmail.com
Função:Alanlista de Desenvolvimento-Back-End

Nome:Daniel Caetano de Souza Ferreira
email:danielcaetano.sf@gmail.com
Funções:Analista de desenvolvimento-Back-End

Nome: Gerson Otavio Fernandes Moreira
email: gersonofernandes@gmail.com
Funções: Analista de Desenvolvimento-DBA

Nome: Guilherme Gomes da Silva
email: gomesguilherme.s@outlook.com
Funções: Analista de Desenvolvimento-Back-End


