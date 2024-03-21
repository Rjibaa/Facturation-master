USE `Facturation`
;
/****** Object:  Table `Agent`    Script Date: 9/3/2018 1:23:41 PM ******/


CREATE TABLE `Agent`(
	`Code_agent` int NOT NULL,
	`nom_agent` varchar(50) NULL,
PRIMARY KEY 
(
	`Code_agent` ASC
)
)
;
/****** Object:  Table `Client`    Script Date: 9/3/2018 1:23:43 PM ******/


CREATE TABLE `Client`(
	`Code_cl` int NOT NULL,
	`nom_cl` varchar(25) NULL,
	`adress` varchar(50) NULL,
	`ville` varchar(50) NULL,
	`solde` decimal(12,2) NULL,
PRIMARY KEY 
(
	`Code_cl` ASC
)
)
;
/****** Object:  Table `Conserner`    Script Date: 9/3/2018 1:23:43 PM ******/


CREATE TABLE `Conserner`(
	`montant_reg` decimal(12,2) NULL,
	`no_facture` int NULL,
	`no_reglement` int NULL
)
;
/****** Object:  Table `Contient`    Script Date: 9/3/2018 1:23:43 PM ******/


CREATE TABLE `Contient`(
	`qut_cd` int NULL,
	`ref` varchar(50) NULL,
	`no_facture` int NULL
)
;
/****** Object:  Table `en_mode`    Script Date: 9/3/2018 1:23:43 PM ******/


CREATE TABLE `en_mode`(
	`sous_montant` double NULL,
	`no_reglement` int NULL,
	`code_mode` int NULL
)
;
/****** Object:  Table `Facture`    Script Date: 9/3/2018 1:23:43 PM ******/


CREATE TABLE `Facture`(
	`no_facture` int NOT NULL,
	`date_facture` `date` NULL,
	`moantant_facture` decimal(12,2) NULL,
	`montant_reste` decimal(12,2) NULL,
	`code_cl` int NULL,
PRIMARY KEY 
(
	`no_facture` ASC
)
)
;
/****** Object:  Table `marchandise`    Script Date: 9/3/2018 1:23:43 PM ******/


CREATE TABLE `marchandise`(
	`ref` varchar(50) NOT NULL,
	`designation` varchar(50) NULL,
	`pu` double NULL,
	`qut_st` int NULL,
 CONSTRAINT `PK_marchandise` PRIMARY KEY 
(
	`ref` ASC
)
)
;
/****** Object:  Table `Mode`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE TABLE `Mode`(
	`Code_mode` int NOT NULL,
	`libelle_mode` varchar(50) NULL,
PRIMARY KEY 
(
	`Code_mode` ASC
)
)
;
/****** Object:  Table `Reglement`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE TABLE `Reglement`(
	`no_reglement` int NOT NULL,
	`date_reg` `date` NULL,
	`total_reglement` double NULL,
	`code_agent` int NULL,
PRIMARY KEY 
(
	`no_reglement` ASC
)
)
;
/****** Object:  Table `Utilisateur`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE TABLE `Utilisateur`(
	`ID` varchar(50) NOT NULL,
	`PSW` varchar(50) NULL,
	`USERNAME` varchar(50) NULL,
	`STATUT` tinyint NULL,
	`DATE_DRN_VALIDER` `date` NULL,
	`NOMBRE_TENTATIVE` int NULL,
 CONSTRAINT `PK_User` PRIMARY KEY 
(
	`ID` ASC
)
)
;
INSERT `Client` (`Code_cl`, `nom_cl`, `adress`, `ville`, `solde`) VALUES (1, N'Mojahid BELAMAN', N'hay dakhla blok G', N'Boujniba', 35900.0000)
INSERT `Client` (`Code_cl`, `nom_cl`, `adress`, `ville`, `solde`) VALUES (2, N'Othman FADIL', N'Hay Dakhla Bloc B', N'khouribga', 50000.0000)
INSERT `Client` (`Code_cl`, `nom_cl`, `adress`, `ville`, `solde`) VALUES (3, N'Kamal EZIKOURI', N'hay dakhla bloc F', N'khouribga', 70000.0000)
INSERT `Client` (`Code_cl`, `nom_cl`, `adress`, `ville`, `solde`) VALUES (4, N'Ayoub ElBEZDAWI', N'tachroun', N'boujniba', 98000.0000)
INSERT `Contient` (`qut_cd`, `ref`, `no_facture`) VALUES (2, N'art4', 1)
INSERT `Contient` (`qut_cd`, `ref`, `no_facture`) VALUES (2, N'art1', 2)
INSERT `Contient` (`qut_cd`, `ref`, `no_facture`) VALUES (3, N'art1', 3)
INSERT `Contient` (`qut_cd`, `ref`, `no_facture`) VALUES (1, N'art5', 4)
INSERT `Contient` (`qut_cd`, `ref`, `no_facture`) VALUES (1, N'art4', 5)
INSERT `Contient` (`qut_cd`, `ref`, `no_facture`) VALUES (1, N'art2', 5)
INSERT `Facture` (`no_facture`, `date_facture`, `moantant_facture`, `montant_reste`, `code_cl`) VALUES (1, CAST(N'2017-04-02' AS Date), 200.0000, 39800.0000, 1)
INSERT `Facture` (`no_facture`, `date_facture`, `moantant_facture`, `montant_reste`, `code_cl`) VALUES (2, CAST(N'2017-05-26' AS Date), 2000.0000, 98000.0000, 4)
INSERT `Facture` (`no_facture`, `date_facture`, `moantant_facture`, `montant_reste`, `code_cl`) VALUES (3, CAST(N'2017-06-05' AS Date), 3000.0000, 36800.0000, 1)
INSERT `Facture` (`no_facture`, `date_facture`, `moantant_facture`, `montant_reste`, `code_cl`) VALUES (4, CAST(N'2017-10-13' AS Date), 300.0000, 36500.0000, 1)
INSERT `Facture` (`no_facture`, `date_facture`, `moantant_facture`, `montant_reste`, `code_cl`) VALUES (5, CAST(N'2017-10-13' AS Date), 600.0000, 35900.0000, 1)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art1', N'laptop', 1000, 1)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art2', N'caméra', 500, 2)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art3', N'lenovo B590', 1500, 3)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art4', N'USB', 100, 17)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art5', N'Lecteur DVD', 300, 29)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art6', N'Lecteur CD', 200, 15)
INSERT `marchandise` (`ref`, `designation`, `pu`, `qut_st`) VALUES (N'art7', N'Carte mére', 5000, 4)
INSERT `Mode` (`Code_mode`, `libelle_mode`) VALUES (1, N'chèque')
INSERT `Mode` (`Code_mode`, `libelle_mode`) VALUES (2, N'espèce')
INSERT `Mode` (`Code_mode`, `libelle_mode`) VALUES (3, N'carte de crédit')
INSERT `Utilisateur` (`ID`, `PSW`, `USERNAME`, `STATUT`, `DATE_DRN_VALIDER`, `NOMBRE_TENTATIVE`) VALUES (N'admin', N'ad123', N'Mojahid BELAMAN', 1, CAST(N'2018-09-03' AS Date), 0)
INSERT `Utilisateur` (`ID`, `PSW`, `USERNAME`, `STATUT`, `DATE_DRN_VALIDER`, `NOMBRE_TENTATIVE`) VALUES (N'user', N'us123', N'Ayoub TALABI', 1, CAST(N'2017-04-05' AS Date), 4)
ALTER TABLE `Conserner`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`no_facture`)
REFERENCES `Facture` (`no_facture`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `Conserner` CHECK CONSTRAINT `FK_Conserner_Facture`
;
ALTER TABLE `Conserner`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`no_reglement`)
REFERENCES `Reglement` (`no_reglement`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `Conserner` CHECK CONSTRAINT `FK_Conserner_Reglement`
;
ALTER TABLE `Contient`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`no_facture`)
REFERENCES `Facture` (`no_facture`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `Contient` CHECK CONSTRAINT `FK_Contient_Facture`
;
ALTER TABLE `Contient`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`ref`)
REFERENCES `marchandise` (`ref`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `Contient` CHECK CONSTRAINT `FK_Contient_marchandise`
;
ALTER TABLE `en_mode`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`code_mode`)
REFERENCES `Mode` (`Code_mode`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `en_mode` CHECK CONSTRAINT `FK_en_mode_Mode`
;
ALTER TABLE `en_mode`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`no_reglement`)
REFERENCES `Reglement` (`no_reglement`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `en_mode` CHECK CONSTRAINT `FK_en_mode_Reglement`
;
ALTER TABLE `Facture`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`code_cl`)
REFERENCES `Client` (`Code_cl`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `Facture` CHECK CONSTRAINT `FK_Facture_Client`
;
ALTER TABLE `Reglement`  WITH CHECK ADD  CONSTRAINT FOREIGN KEY (`code_agent`)
REFERENCES `Agent` (`Code_agent`)
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE `Reglement` CHECK CONSTRAINT `FK_Reglement_Agent`
;
/****** Object:  StoredProcedure `ADD_ARTICLE`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `ADD_ARTICLE`
@REF VARCHAR(50), @DESIGNATION VARCHAR(50), @PU FLOAT, @QUT_ST INT
AS
INSERT INTO `marchandise`
           (`ref`
		   ,`designation`
           ,`pu`
           ,`qut_st`)
     VALUES
           (@REF
		   ,@designation
           ,@pu
           ,@qut_st)
;
/****** Object:  StoredProcedure `ADD_CLIENT`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `ADD_CLIENT`
@CODE_CL INT, @NOM_CL VARCHAR(25), @ADRESSE VARCHAR(50), @VILLE VARCHAR(50), @SOLDE MONEY
AS
INSERT INTO `Client`
           (`Code_cl`
           ,`nom_cl`
           ,`adress`
           ,`ville`
           ,`solde`)
     VALUES
           (@CODE_CL
           ,@NOM_CL
           ,@ADRESSE
           ,@VILLE
           ,@SOLDE)
;
/****** Object:  StoredProcedure `ADD_CONTIENT`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `ADD_CONTIENT`
@REF VARCHAR(50), @NO_FACTURE INT, @QUT_CD INT
AS
INSERT INTO `Contient`
           (`qut_cd`
           ,`ref`
		   ,`no_facture`)
     VALUES
           (@QUT_CD
		   ,@REF
           ,@NO_FACTURE)

UPDATE marchandise SET qut_st = qut_st - @QUT_CD WHERE ref = @REF

;
/****** Object:  StoredProcedure `ADD_FACTURE`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `ADD_FACTURE`
@NO_FACTURE INT, @DATE_FACTURE DATE, @MONTANT_FACTURE MONEY, @MONTANT_RESTE MONEY, @CODE_CL INT
AS
INSERT INTO `Facture`
           (`no_facture`
           ,`date_facture`
           ,`moantant_facture`
           ,`montant_reste`
           ,`code_cl`)
     VALUES
           (@NO_FACTURE
           ,@DATE_FACTURE
           ,@MONTANT_FACTURE
		   ,@MONTANT_RESTE
           ,@CODE_CL)

UPDATE Client SET solde = solde - @MONTANT_FACTURE WHERE Code_cl = @CODE_CL

;
/****** Object:  StoredProcedure `ALL_ARTICLE`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `ALL_ARTICLE`
AS 
SELECT ref, designation, pu, qut_st FROM marchandise 
;
/****** Object:  StoredProcedure `ALL_CLIENT`    Script Date: 9/3/2018 1:23:44 PM ******/



CREATE PROC `ALL_CLIENT`
AS
SELECT Code_cl AS 'Code Client' , nom_cl AS 'Nom Client', solde AS 'Solde' FROM Client
;
/****** Object:  StoredProcedure `LAST_FACTURE`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `LAST_FACTURE`
AS
SELECT ISNULL(MAX(no_facture) + 1, 1) FROM Facture
;
/****** Object:  StoredProcedure `LAST_FACTURE_PRINT`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `LAST_FACTURE_PRINT`
AS
SELECT MAX(no_facture) FROM Facture
;
/****** Object:  StoredProcedure `PRINT_DETAIL_FACTURE`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROC `PRINT_DETAIL_FACTURE`
@NO_FACTURE INT
AS
SELECT F.`no_facture`
      ,F.`date_facture`
      ,F.`moantant_facture`
      ,F.`montant_reste`
      ,F.`code_cl`
	  ,CL.nom_cl
	  ,CL.adress
	  ,CL.ville
	  ,CL.solde
	  ,M.ref
	  ,M.designation
	  ,M.pu
	  ,M.qut_st
	  ,C.qut_cd
  FROM Facture F
  INNER JOIN Contient C ON C.no_facture = F.no_facture
  INNER JOIN marchandise M ON C.ref = M.ref
  INNER JOIN Client CL ON F.code_cl = CL.Code_cl
  WHERE F.no_facture = @NO_FACTURE
;
/****** Object:  StoredProcedure `PRINT_DETAIL_FACTURE2`    Script Date: 9/3/2018 1:23:44 PM ******/



CREATE PROC `PRINT_DETAIL_FACTURE2`
AS
SELECT F.`no_facture`
      ,F.`date_facture`
      ,F.`moantant_facture`
      ,F.`montant_reste`
      ,F.`code_cl`
	  ,CL.nom_cl
	  ,CL.adress
	  ,CL.ville
	  ,CL.solde
  FROM Facture F
  INNER JOIN Client CL on F.code_cl = CL.Code_cl
;
/****** Object:  StoredProcedure `SP_LOGIN`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE procedure `SP_LOGIN` 
	@ID varchar(50), @PSW varchar(50) 
as

--Si la connexion est OK
IF (SELECT COUNT(*) FROM Utilisateur WHERE ID = @ID AND PSW = @PSW AND statut = 1) = 1
	BEGIN
		UPDATE Utilisateur SET NOMBRE_TENTATIVE = 0, DATE_DRN_VALIDER = GETDATE() WHERE ID = @ID AND PSW = @PSW
		return 0
	end
ELSE
	BEGIN
		-- Si le compte utilisateur n'existe pas
		if((select count(*) from Utilisateur where ID = @ID and PSW = @PSW) = 0)
			begin 
				return 1
			end
		ELSE
			BEGIN
				--Si le compte est bloqué (statut = 0)
				if((select STATUT from Utilisateur where ID = @ID) = 0)
					begin
						return 2
					end
				ELSE
					BEGIN
						--Si le mot de passe fourni n'est pas correcte
						if((select PSW from Utilisateur where ID = @ID) <> @PSW)
							begin
								BEGIN TRAN
									UPDATE Utilisateur SET NOMBRE_TENTATIVE = NOMBRE_TENTATIVE + 1 WHERE ID = @ID
									IF(SELECT NOMBRE_TENTATIVE FROM Utilisateur WHERE ID = @ID) > 3
									BEGIN
										UPDATE Utilisateur SET STATUT = 0 WHERE ID = @ID
									END
								COMMIT TRAN
								return 3
							end
					END
			END
	END
;
/****** Object:  StoredProcedure `VERIFIER_ID`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROCEDURE `VERIFIER_ID`
	@REF VARCHAR(50)
AS
SELECT * FROM marchandise WHERE ref = @REF
;
/****** Object:  StoredProcedure `VERIFIER_ID_CLIENT`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROCEDURE `VERIFIER_ID_CLIENT`
	@CODE_CL INT
AS
SELECT * FROM Client WHERE Code_cl = @CODE_CL
;
/****** Object:  StoredProcedure `VERIFY_QUTESTOCK`    Script Date: 9/3/2018 1:23:44 PM ******/


CREATE PROCEDURE `VERIFY_QUTESTOCK`
	@REF VARCHAR(6), @QUT_ST INT
AS
SELECT * FROM marchandise WHERE ref = @REF AND qut_st > @QUT_ST
;
