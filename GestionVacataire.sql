create database GestionVacataire

create table Vacataire(NVacataire int primary key,Nom varchar(60),Prénom varchar(60),DateNaissance date,
                       Spécialité varchar(90),ModePasse varchar(20),Niveau varchar(20))
                       
                       
create table Section(CodeSection int primary key,Libellé varchar(50))


create table Absence(NAbsence int primary key identity(123,6),NVacataire int references Vacataire(NVacataire),
             DateAbsence date,Justification char(30))


create table Module(NVacataire int references Vacataire(NVacataire),
                   CodeSection int references Section(CodeSection),NbreHeures int,NomModule varchar(80))


create table Payement(NVacataire int references Vacataire(NVacataire),Mois varchar(30),Année varchar(40),
                      NbrHeureP int,Typee varchar(40),primary key (NVacataire,Mois,Année))


create table Utilisateur(NVacataire int references Vacataire(NVacataire),Nom varchar(40),Prénom varchar(40),
                         Email varchar(80),MotPasse varchar(50))
                         
                 
insert into Vacataire values(1,'Skalent','Ghizlane','01-03-1983','Dévloppement Informatique','123ghizlane','TS')
insert into Vacataire values(2,'Hala','Nourddine','01-22-1988','Dévloppement Informatique','123nourddin','TS')
insert into Vacataire values(3,'Atouf','Sanae','07-04-1981','Communication','123sanae','T')
insert into Vacataire values(4,'Samih','Morade','09-10-1982','Réseaux','123morade','TS')
insert into Vacataire values(5,'Miftahe','Soad','12-25-1985','Englais','123miftah','T')
insert into Vacataire values(6,'Tazi','Yassine','04-08-1979','Dévloppement Multimédia','123yassine','TS')
insert into Vacataire values(7,'Alali','Fatima','09-12-1975','Secrétariats Buretique','123fatima','TS')
insert into Vacataire values(8,'Lharchaoui','Fatima Zahra','10-06-1980','Secrétariats Buretique','123gfatimazahra','TS')
insert into Vacataire values(9,'Abo Maria','Zahira','08-12-1978','Bureautique','123zahira','T')
insert into Vacataire values(10,'Lharak','Amina','06-10-1972','Dévloppement Informatique','123amina','TS')


insert into Section values(10,'TDI201')
insert into Section values(20,'TDI202')
insert into Section values(30,'TDM201')
insert into Section values(40,'TDM202')
insert into Section values(50,'TDI101')
insert into Section values(60,'TDI102')
insert into Section values(70,'TSD101')
insert into Section values(80,'TSD102')
insert into Section values(90,'TRI101')
insert into Section values(100,'TRI202')
insert into Section values(200,'TRI201')
insert into Section values(300,'TSD201')
insert into Section values(400,'TSD202')
insert into Section values(500,'TRI102')



insert into Absence values(1,'01-19-2018','OUI')
insert into Absence values(2,'01-30-2018','OUI')
insert into Absence values(5,'02-08-2018','NON')
insert into Absence values(8,'05-20-2018','NON')
insert into Absence values(9,'04-19-2018','OUI')
insert into Absence values(10,'02-20-2018','OUI')
insert into Absence values(3,'05-30-2018','NON')
insert into Absence values(1,'09-14-2018','OUI')
insert into Absence values(5,'10-06-2018','OUI')
insert into Absence values(4,'11-09-2018','OUI')
insert into Absence values(7,'10-01-2018','OUI')
insert into Absence values(9,'12-15-2018','NON')
insert into Absence values(8,'03-23-2018','OUI')
insert into Absence values(6,'03-07-2018','OUI')
insert into Absence values(3,'02-26-2018','OUI')


insert into Module values(1,20,120,'SGBD')
insert into Module values(1,20,120,'ASP.NET')
insert into Module values(2,10,100,'HTML')                        
insert into Module values(7,80,140,'ENTREPRISE')                        
insert into Module values(8,80,120,'PRISE DE NOTE')                        
insert into Module values(4,500,100,'MATH APPLIQUE')                        
insert into Module values(10,10,140,'ADO.NET')                        
insert into Module values(2,50,120,'ALGORITHME')                        
insert into Module values(3,10,70,'TECHNIQUE DE RECHERCHE EMPLOIT')                        
insert into Module values(3,20,100,'COMMUNICATION') 
insert into Module values(8,70,140,'GESTION DE TEMP')                        
insert into Module values(9,80,75,'WORD')                        
insert into Module values(9,70,75,'EXEL')                        
insert into Module values(5,10,35,'ANGLAIS')                        
insert into Module values(5,20,35,'ANGLAIS')                        
insert into Module values(10,10,140,'SGBD')                        
insert into Module values(2,10,120,'ANDROID STUDIO')                        
insert into Module values(2,20,120,'ANDROID STUDIO')                        
                                               

insert into Utilisateur values(1,'Tahiri','Samir','samir@gmail.com','2018saamir')
insert into Utilisateur values(2,'Chakir','Kamal','kamal@gmail.com','2018kamal')                        
insert into Utilisateur values(3,'Aitarnia','Hicham','hicham@gmail.com','2018hicham')                        
insert into Utilisateur values(4,'Tahiri','Samir','samir@gmail.com','2018saamir')                        
insert into Utilisateur values(5,'Tahiri','Samir','samir@gmail.com','2018saamir')                        
insert into Utilisateur values(6,'Chakir','Kamal','kamal@gmail.com','2018kamal')
insert into Utilisateur values(7,'Chakir','Kamal','kamal@gmail.com','2018kamal')                        
insert into Utilisateur values(8,'Aitarnia','Hicham','hicham@gmail.com','2018hicham')                        
insert into Utilisateur values(9,'Aitarnia','Hicham','hicham@gmail.com','2018hicham')                        
insert into Utilisateur values(10,'Tahiri','Samir','samir@gmail.com','2018saamir')                        
                        
                        
                       
