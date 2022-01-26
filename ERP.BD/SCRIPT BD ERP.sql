
CREATE TABLE CODIGOS_POSTAIS (
                CODI_ID_PK INT IDENTITY (1,1) NOT NULL,
                CODI_CEP VARCHAR(8) NOT NULL,
                CODI_LOG VARCHAR(100) NOT NULL,
                CODI_BAI VARCHAR(50) NOT NULL,
                CODI_LOC VARCHAR(50) NOT NULL,
                CODI_UF VARCHAR(2) NOT NULL,
                CONSTRAINT CODIGOS_POSTAIS_PK PRIMARY KEY (CODI_ID_PK)
);
--___________________________________________________________________________________________--

--2_INSERINDO REGISTROS NA TABELA CODIGOS_POSTAIS

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'75528275',
	'Rua Maria Jesu�na Tavares',
	'Zenon Borges Guimar�es',
	'Itumbiara',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74650100',
	'Rua Dona Stela',
	'Negr�o de Lima',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74672400',
	'Avenida Caiap�',
	'Santa Genoveva',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74530030',
	'Rua 205',
	'Setor Coimbra',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'75084470',
	'Travessa Um',
	'S�o Carlos',
	'An�polis',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'78031045',
	'Rua Padre Rolim',
	'Cidade Alta',
	'Cuiab�',
	'MT'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74680740',
	'Rua GB6',
	'Jardim Guanabara II',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'79800023',
	'Avenida Weimar Gon�alves Torres',
	'Centro',
	'Dourados',
	'MS'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'38307115',
	'Rua Jos� Rodrigues Furtado',
	'Alvorada',
	'Ituiutaba',
	'MG'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74450440',
	'Avenida Borba Gato',
	'Capuava',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'77015611',
	'Quadra 405',
	'Plano Diretor Sul',
	'Palmas',
	'TO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'78735753',
	'Rua Maria Izami Pereira Campos',
	'Jardim Atl�ntico',
	'Rondon�polis',
	'MT'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74653212',
	'Avenida Quinta Avenida',
	'Setor Nova Vila',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74495610',
	'Rua VC 84',
	'Conjunto Vera Cruz',
	'Goi�nia',
	'GO'
);

INSERT INTO CODIGOS_POSTAIS (
	CODI_CEP,
	CODI_LOG,
	CODI_BAI,
	CODI_LOC,
	CODI_UF
) VALUES (
	'74595254',
	'Rua FL 17',
	'Parque das Flores',
	'Goi�nia',
	'GO'
);
--___________________________________________________________________________________________--

CREATE TABLE ENDERECOS (
                ENDE_ID_PK INT IDENTITY (1,1) NOT NULL,
                ENDE_NUM VARCHAR(20) NOT NULL,
                ENDE_COM VARCHAR(100) NOT NULL,
                ENDE_CODI_ID_FK INT NOT NULL,
                CONSTRAINT ENDERECOS_PK PRIMARY KEY (ENDE_ID_PK)
);

--INCLUINDO RELACIONAMENTO DE CHAVE ESTRANGEIRA

ALTER TABLE ENDERECOS ADD CONSTRAINT CODIGOS_POSTAIS_ENDERECOS_fk
FOREIGN KEY (ENDE_CODI_ID_FK)
REFERENCES CODIGOS_POSTAIS (CODI_ID_PK)
ON DELETE NO ACTION
ON UPDATE NO ACTION
--___________________________________________________________________________________________--

--4_INSERINDO REGISTROS NA TABELA ENDERECOS

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'689',
	'',
	1
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'181',
	'Cond. Vila Rica Ap. 1507A',
	2
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'279',
	'Pr�ximo ao antigo aeroporto',
	3
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'956',
	'',
	4
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'822',
	'',
	5
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'144',
	'Lot Jd Independ�ncia',
	6
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'983',
	'',
	7
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'874',
	'',
	8
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'931',
	'',
	9
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'218',
	'',
	10
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'500',
	'Sul Avenida LO 9',
	11
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'672',
	'',
	12
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'723',
	'',
	13
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'561',
	'',
	14
);

INSERT INTO ENDERECOS (
	ENDE_NUM,
	ENDE_COM,
	ENDE_CODI_ID_FK
) VALUES (
	'391',
	'',
	15
);
--___________________________________________________________________________________________--

CREATE TABLE EMPRESAS (
                EMPR_ID_PK INT IDENTITY (2000,1) NOT NULL,
                EMPR_CNPJ VARCHAR(14) NOT NULL,
                EMPR_RAZ VARCHAR(100) NOT NULL,
                EMPR_ENDE_ID_FK INT NOT NULL,
                CONSTRAINT EMPRESAS_PK PRIMARY KEY (EMPR_ID_PK)
);

--INCLUINDO RELACIONAMENTO E CHAVE ESTRANGEIRA

ALTER TABLE EMPRESAS ADD CONSTRAINT ENDERECOS_EMPRESAS_fk
FOREIGN KEY (EMPR_ENDE_ID_FK)
REFERENCES ENDERECOS (ENDE_ID_PK)
ON DELETE NO ACTION
ON UPDATE NO ACTION
--___________________________________________________________________________________________--

--6_INCLUINDO REGISTROS NA TABELA EMPRESAS

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'73658564000190',
	'Grupo MPC',
	3
);

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'09341993000130',
	'Sementeira Dois Irm�os',
	4
);

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'84774111000145',
	'Transportadora Maciel',
	11
);

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'74844920000122',
	'Laborat�rio �gua e Terra',
	12
);

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'15062950000118',
	'Osvaldo e S�rgio P�es e Doces Ltda',
	14
);

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'07674108000109',
	'Mac Filmagens Ltda',
	15
);
--___________________________________________________________________________________________--

CREATE TABLE PESSOAS (
                PESS_ID_PK INT IDENTITY (1000,1) NOT NULL,
                PESS_CPF VARCHAR(11) NOT NULL,
                PESS_NOM VARCHAR(100) NOT NULL,
                PESS_ENDE_ID_FK INT NOT NULL,
                CONSTRAINT PESSOAS_PK PRIMARY KEY (PESS_ID_PK)
);

--INCLUINDO RELACIONAMENTO DE CHAVE ESTRANGEIRA

ALTER TABLE PESSOAS ADD CONSTRAINT ENDERECOS_PESSOAS_fk
FOREIGN KEY (PESS_ENDE_ID_FK)
REFERENCES ENDERECOS (ENDE_ID_PK)
ON DELETE NO ACTION
ON UPDATE NO ACTION

--___________________________________________________________________________________________--

--8_INSERINDO REGISTROS NA TABELA PESSOAS

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'60333616103',
	'Liz Sueli da Luz',
	1
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'00474913880',
	'Matheus Pereira Castro',
	2
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'87281180144',
	'Cau� Antonio Farias',
	5
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'59958715104',
	'Renata Ros�ngela das Neves',
	6
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'71610136152',
	'Vicente Henrique Matheus Rodrigues',
	7
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'42172038105',
	'Jorge Leandro Ian Foga�a',
	8
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'73560814669',
	'Ricardo Jo�o Lopes',
	9
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'65990298170',
	'M�rio Nelson Osvaldo de Paula',
	10
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'75024838106',
	'Elo� Agatha Apar�cio',
	13
);
--___________________________________________________________________________________________--

CREATE TABLE RECIBOS (
                RECI_ID_PK INT IDENTITY (1,1) NOT NULL,
                RECI_TIP VARCHAR(9) NOT NULL,
                RECI_REC VARCHAR(100) NOT NULL,
                RECI_REC_DOC VARCHAR(14) NOT NULL,
                RECI_REC_END VARCHAR(100) NOT NULL,
                RECI_REC_NUM VARCHAR(20) NOT NULL,
                RECI_REC_COM VARCHAR(100) NOT NULL,
                RECI_REC_CEP VARCHAR(8) NOT NULL,
                RECI_REC_BAI VARCHAR(50) NOT NULL,
                RECI_REC_CID VARCHAR(50) NOT NULL,
                RECI_REC_UF VARCHAR(2) NOT NULL,
                RECI_PAG VARCHAR(100) NOT NULL,
                RECI_PAG_DOC VARCHAR(14) NOT NULL,
                RECI_VAL MONEY NOT NULL,
                RECI_VAL_EXT VARCHAR(255) NOT NULL,
                RECI_OBS VARCHAR(100) NOT NULL,
                RECI_CID VARCHAR(100) NOT NULL,
                RECI_UF VARCHAR(2) NOT NULL,
                RECI_DAT DATE,
                CONSTRAINT RECIBOS_PK PRIMARY KEY (RECI_ID_PK)
);

--INSERINDO REGISTROS NA TABELA RECIBOS

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Matheus Pereira Castro',
	'00474913880',
	'Rua Dona Stela',
	'181',
	'Cond. Vila Rica Ap. 1507A',
	'74650100',
	'Negr�o de Lima',
	'Goi�nia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'6000.00',
	'seis mil reais',
	'Servi�o Prestado como Tratorista',
	'Goi�nia',
	'GO',
	'2022-01-20'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Grupo MPC',
	'73658564000190',
	'Avenida Caiap�',
	'279',
	'Pr�ximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goi�nia',
	'GO',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'150000.00',
	'cento e cinquenta mil reais',
	'Venda de Gr�os',
	'Goi�nia',
	'GO',
	'2022-01-20'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Liz Sueli da Luz',
	'60333616103',
	'Rua Maria Jesu�na Tavares',
	'689',
	'',
	'75528275',
	'Zenon Borges Guimar�es',
	'Itumbiara',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'2750.50',
	'dois mil setecentos e cinquenta reais e cinquenta centavos',
	'Servi�o Prestado como Cozinheira',
	'Goi�nia',
	'GO',
	'2022-01-21'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goi�nia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'9999.99',
	'nove mil novecentos e noventa e nove reais e noventa e nove centavos',
	'Representa��o Comercial',
	'Goi�nia',
	'GO',
	'2022-01-21'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goi�nia',
	'GO',
	'Matheus Pereira Castro',
	'00474913880',
	'1625.75',
	'mil seiscentos e vinte e cinco reais e setenta e cinco centavos',
	'Venda de Insumos Agr�colas',
	'Goi�nia',
	'GO',
	'2022-01-21'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goi�nia',
	'GO',
	'Liz Sueli da Luz',
	'60333616103',
	'4667.89',
	'quatro mil seiscentos e sessenta e sete reais e oitenta e nove centavos',
	'Venda de Sementes',
	'Goi�nia',
	'GO',
	'2022-01-21'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Grupo MPC',
	'73658564000190',
	'Avenida Caiap�',
	'279',
	'Pr�ximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goi�nia',
	'GO',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'8664.99',
	'oito mil seiscentos e sessenta e quatro reais e noventa e nove centavos',
	'Intermedia��o de Contratos',
	'Goi�nia',
	'GO',
	'2022-01-21'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Cau� Antonio Farias',
	'87281180144',
	'Travessa Um',
	'822',
	'',
	'75084470',
	'S�o Carlos',
	'An�polis',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'2568.78',
	'dois mil quinhentos e sessenta e oito reais e setenta e oito centavos',
	'Honor�rios Cont�beis',
	'Goi�nia',
	'GO',
	'2022-01-22'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Cau� Antonio Farias',
	'87281180144',
	'Travessa Um',
	'822',
	'',
	'75084470',
	'S�o Carlos',
	'An�polis',
	'GO',
	'Sementeira Dois Irm�os',
	'09341993000130',	
	'1650.99',
	'mil seiscentos e cinquenta reais e noventa e nove centavos',
	'Honor�rios Cont�beis',
	'Goi�nia',
	'GO',
	'2022-01-22'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Grupo MPC',
	'73658564000190',
	'Avenida Caiap�',
	'279',
	'Pr�ximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goi�nia',
	'GO',
	'Renata Ros�ngela das Neves',
	'59958715104',
	'5685.76',
	'cinco mil seiscentos e oitenta e cinco reais e setenta e seis centavos',
	'Venda de Defensivos Agr�colas',
	'Goi�nia',
	'GO',
	'2022-01-22'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goi�nia',
	'GO',
	'Renata Ros�ngela das Neves',
	'59958715104',
	'3825.40',
	'tr�s mil oitocentos e vinte e cinco reais e quarenta centavos',
	'Venda de Defensivos Agr�colas',
	'Goi�nia',
	'GO',
	'2022-01-22'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Vicente Henrique Matheus Rodrigues',
	'71610136152',
	'Rua GB6',
	'983',
	'',
	'74680740',
	'Jardim Guanabara II',
	'Goi�nia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'600.00',
	'seiscentos reais',
	'Servi�o Prestado como Jardineiro',
	'Goi�nia',
	'GO',
	'2022-01-22'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goi�nia',
	'GO',
	'Jorge Leandro Ian Foga�a',
	'42172038105',
	'7500.85',
	'sete mil e quinhentos reais e oitenta e cinco centavos',
	'Venda de Sementes',
	'Goi�nia',
	'GO',
	'2022-01-24'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Grupo MPC',
	'73658564000190',
	'Avenida Caiap�',
	'279',
	'Pr�ximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goi�nia',
	'GO',
	'Ricardo Jo�o Lopes',
	'73560814669',
	'4889.60',
	'quatro mil oitocentos e oitenta e nove reais e sessenta centavos',
	'Venda de Corretivo de Solo',
	'Goi�nia',
	'GO',
	'2022-01-24'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'M�rio Nelson Osvaldo de Paula',
	'65990298170',
	'Avenida Borba Gato',
	'218',
	'',
	'74450440',
	'Capuava',
	'Goi�nia',
	'GO',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'1200.00',
	'mil e duzentos reais',
	'Servi�o Prestado como Eletricista',
	'Goi�nia',
	'GO',
	'2022-01-24'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Transportadora Maciel',
	'84774111000145',
	'Quadra 405',
	'500',
	'Sul Avenida LO 9',
	'77015611',
	'Plano Diretor Sul',
	'Palmas',
	'TO',
	'Grupo MPC',
	'73658564000190',
	'3330.50',
	'tr�s mil trezentos e trinta reais e cinquenta centavos',
	'Entrega de Mercadorias',
	'Goi�nia',
	'GO',
	'2022-01-24'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Laborat�rio �gua e Terra',
	'74844920000122',
	'Rua Maria Izami Pereira Campos',
	'672',
	'',
	'78735753',
	'Jardim Atl�ntico',
	'Rondon�polis',
	'MT',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'7899.70',
	'sete mil oitocentos e noventa e nove reais e setenta centavos',
	'An�lise de Sementes',
	'Goi�nia',
	'GO',
	'2022-01-24'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Sementeira Dois Irm�os',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goi�nia',
	'GO',
	'Matheus Pereira Castro',
	'00474913880',
	'1268.30',
	'mil duzentos e sessenta e oito reais e trinta centavos',
	'Venda de Insumos Agr�colas',
	'Goi�nia',
	'GO',
	'2022-01-25'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Pagar',
	'Osvaldo e S�rgio P�es e Doces Ltda',
	'15062950000118',
	'Rua VC 84',
	'561',
	'',
	'74495610',
	'Conjunto Vera Cruz',
	'Goi�nia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'2750.50',
	'setecentos e cinquenta reais e cinquenta centavos',
	'Servi�os de Confeitaria',
	'Goi�nia',
	'GO',
	'2022-01-25'
);

INSERT INTO RECIBOS (
	RECI_TIP,
	RECI_REC,
	RECI_REC_DOC,
	RECI_REC_END,
	RECI_REC_NUM,
	RECI_REC_COM,
	RECI_REC_CEP,
	RECI_REC_BAI,
	RECI_REC_CID,
	RECI_REC_UF,
	RECI_PAG,
	RECI_PAG_DOC,
	RECI_VAL,
	RECI_VAL_EXT,
	RECI_OBS,
	RECI_CID,
	RECI_UF,
	RECI_DAT
) VALUES (
	'A Receber',
	'Grupo MPC',
	'73658564000190',
	'Avenida Caiap�',
	'279',
	'Pr�ximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goi�nia',
	'GO',
	'Mac Filmagens Ltda',
	'07674108000109',
	'5642.89',
	'cinco mil seiscentos e quarenta e dois reais e oitenta e nove centavos',
	'Direito de Imagem',
	'Goi�nia',
	'GO',
	'2022-01-25'
);