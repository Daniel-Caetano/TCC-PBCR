
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
	'Rua Maria Jesuína Tavares',
	'Zenon Borges Guimarães',
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
	'Negrão de Lima',
	'Goiânia',
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
	'Avenida Caiapó',
	'Santa Genoveva',
	'Goiânia',
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
	'Goiânia',
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
	'São Carlos',
	'Anápolis',
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
	'Cuiabá',
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
	'Goiânia',
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
	'Avenida Weimar Gonçalves Torres',
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
	'Rua José Rodrigues Furtado',
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
	'Goiânia',
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
	'Jardim Atlântico',
	'Rondonópolis',
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
	'Goiânia',
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
	'Goiânia',
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
	'Goiânia',
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
	'Próximo ao antigo aeroporto',
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
	'Lot Jd Independência',
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
	'Sementeira Dois Irmãos',
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
	'Laboratório Água e Terra',
	12
);

INSERT INTO EMPRESAS (
	EMPR_CNPJ,
	EMPR_RAZ,
	EMPR_ENDE_ID_FK
) VALUES (
	'15062950000118',
	'Osvaldo e Sérgio Pães e Doces Ltda',
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
	'Cauê Antonio Farias',
	5
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'59958715104',
	'Renata Rosângela das Neves',
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
	'Jorge Leandro Ian Fogaça',
	8
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'73560814669',
	'Ricardo João Lopes',
	9
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'65990298170',
	'Mário Nelson Osvaldo de Paula',
	10
);

INSERT INTO PESSOAS (
	PESS_CPF,
	PESS_NOM,
	PESS_ENDE_ID_FK
) VALUES (
	'75024838106',
	'Eloá Agatha Aparício',
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
	'Negrão de Lima',
	'Goiânia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'6000.00',
	'seis mil reais',
	'Serviço Prestado como Tratorista',
	'Goiânia',
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
	'Avenida Caiapó',
	'279',
	'Próximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goiânia',
	'GO',
	'Sementeira Dois Irmãos',
	'09341993000130',
	'150000.00',
	'cento e cinquenta mil reais',
	'Venda de Grãos',
	'Goiânia',
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
	'Rua Maria Jesuína Tavares',
	'689',
	'',
	'75528275',
	'Zenon Borges Guimarães',
	'Itumbiara',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'2750.50',
	'dois mil setecentos e cinquenta reais e cinquenta centavos',
	'Serviço Prestado como Cozinheira',
	'Goiânia',
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
	'Sementeira Dois Irmãos',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goiânia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'9999.99',
	'nove mil novecentos e noventa e nove reais e noventa e nove centavos',
	'Representação Comercial',
	'Goiânia',
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
	'Sementeira Dois Irmãos',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goiânia',
	'GO',
	'Matheus Pereira Castro',
	'00474913880',
	'1625.75',
	'mil seiscentos e vinte e cinco reais e setenta e cinco centavos',
	'Venda de Insumos Agrícolas',
	'Goiânia',
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
	'Sementeira Dois Irmãos',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goiânia',
	'GO',
	'Liz Sueli da Luz',
	'60333616103',
	'4667.89',
	'quatro mil seiscentos e sessenta e sete reais e oitenta e nove centavos',
	'Venda de Sementes',
	'Goiânia',
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
	'Avenida Caiapó',
	'279',
	'Próximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goiânia',
	'GO',
	'Sementeira Dois Irmãos',
	'09341993000130',
	'8664.99',
	'oito mil seiscentos e sessenta e quatro reais e noventa e nove centavos',
	'Intermediação de Contratos',
	'Goiânia',
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
	'Cauê Antonio Farias',
	'87281180144',
	'Travessa Um',
	'822',
	'',
	'75084470',
	'São Carlos',
	'Anápolis',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'2568.78',
	'dois mil quinhentos e sessenta e oito reais e setenta e oito centavos',
	'Honorários Contábeis',
	'Goiânia',
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
	'Cauê Antonio Farias',
	'87281180144',
	'Travessa Um',
	'822',
	'',
	'75084470',
	'São Carlos',
	'Anápolis',
	'GO',
	'Sementeira Dois Irmãos',
	'09341993000130',	
	'1650.99',
	'mil seiscentos e cinquenta reais e noventa e nove centavos',
	'Honorários Contábeis',
	'Goiânia',
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
	'Avenida Caiapó',
	'279',
	'Próximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goiânia',
	'GO',
	'Renata Rosângela das Neves',
	'59958715104',
	'5685.76',
	'cinco mil seiscentos e oitenta e cinco reais e setenta e seis centavos',
	'Venda de Defensivos Agrícolas',
	'Goiânia',
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
	'Sementeira Dois Irmãos',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goiânia',
	'GO',
	'Renata Rosângela das Neves',
	'59958715104',
	'3825.40',
	'três mil oitocentos e vinte e cinco reais e quarenta centavos',
	'Venda de Defensivos Agrícolas',
	'Goiânia',
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
	'Goiânia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'600.00',
	'seiscentos reais',
	'Serviço Prestado como Jardineiro',
	'Goiânia',
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
	'Sementeira Dois Irmãos',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goiânia',
	'GO',
	'Jorge Leandro Ian Fogaça',
	'42172038105',
	'7500.85',
	'sete mil e quinhentos reais e oitenta e cinco centavos',
	'Venda de Sementes',
	'Goiânia',
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
	'Avenida Caiapó',
	'279',
	'Próximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goiânia',
	'GO',
	'Ricardo João Lopes',
	'73560814669',
	'4889.60',
	'quatro mil oitocentos e oitenta e nove reais e sessenta centavos',
	'Venda de Corretivo de Solo',
	'Goiânia',
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
	'Mário Nelson Osvaldo de Paula',
	'65990298170',
	'Avenida Borba Gato',
	'218',
	'',
	'74450440',
	'Capuava',
	'Goiânia',
	'GO',
	'Sementeira Dois Irmãos',
	'09341993000130',
	'1200.00',
	'mil e duzentos reais',
	'Serviço Prestado como Eletricista',
	'Goiânia',
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
	'três mil trezentos e trinta reais e cinquenta centavos',
	'Entrega de Mercadorias',
	'Goiânia',
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
	'Laboratório Água e Terra',
	'74844920000122',
	'Rua Maria Izami Pereira Campos',
	'672',
	'',
	'78735753',
	'Jardim Atlântico',
	'Rondonópolis',
	'MT',
	'Sementeira Dois Irmãos',
	'09341993000130',
	'7899.70',
	'sete mil oitocentos e noventa e nove reais e setenta centavos',
	'Análise de Sementes',
	'Goiânia',
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
	'Sementeira Dois Irmãos',
	'09341993000130',
	'Rua 205',
	'956',
	'',
	'74530030',
	'Setor Coimbra',
	'Goiânia',
	'GO',
	'Matheus Pereira Castro',
	'00474913880',
	'1268.30',
	'mil duzentos e sessenta e oito reais e trinta centavos',
	'Venda de Insumos Agrícolas',
	'Goiânia',
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
	'Osvaldo e Sérgio Pães e Doces Ltda',
	'15062950000118',
	'Rua VC 84',
	'561',
	'',
	'74495610',
	'Conjunto Vera Cruz',
	'Goiânia',
	'GO',
	'Grupo MPC',
	'73658564000190',
	'2750.50',
	'setecentos e cinquenta reais e cinquenta centavos',
	'Serviços de Confeitaria',
	'Goiânia',
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
	'Avenida Caiapó',
	'279',
	'Próximo ao antigo aeroporto',
	'74672400',
	'Santa Genoveva',
	'Goiânia',
	'GO',
	'Mac Filmagens Ltda',
	'07674108000109',
	'5642.89',
	'cinco mil seiscentos e quarenta e dois reais e oitenta e nove centavos',
	'Direito de Imagem',
	'Goiânia',
	'GO',
	'2022-01-25'
);