create table EQUIPEDEMATCH 
(
   IDEQUIPE             integer IDENTITY(1000, 1)      primary key,
   NOM                  varchar(20)                    null,
   LOGO                 varchar(2000)                          null,
   PAYS                 varchar(20)                    null  
);
create table JOUEUR 
(  IDJOUEUR             integer  IDENTITY(1000, 1)     primary key,
   NUMJO                int                            null,
   IDEQUIPE             integer                        null,
   NOM                  varchar(20)                    null,
   PRENOM               varchar(20)                    null,
   PHOTO                image                          null,
   COEFF                int                            null,
   AGE                  int                            null,
   TAILLE               int                            null,
   POIDS                int                            null,
   POST                 varchar(20)                    null,
   foreign key (IDEQUIPE)references EQUIPEDEMATCH (IDEQUIPE)
);
create table BUT 
(
   IDBUT                integer   IDENTITY(1000, 1)    primary key,
   TAIM                 time                           not null,
   IDJOUEUR             integer                        not null,
   IDEQUIPE             integer                        null,
   URLVIDEO             varchar (2000)                       null,
   IMAGEBUT             image                          null,
   foreign key (IDEQUIPE) references EQUIPEDEMATCH (IDEQUIPE),
   foreign key (IDJOUEUR) references JOUEUR (IDJOUEUR)
);
create table MATCHE
(
   NUMMAT               integer      IDENTITY(1000, 1) primary key ,
   DATEMAT              date                           null,
   URLVIDEOMAT          varchar (1000)                 null,
   STADE                varchar(20)                    null
  
);
create table MITNPS 
(
   IDMIT                int        IDENTITY(1000, 1)   primary key,
   TEMPSPRDU            time                           null,
   HIBELE               varchar(20)                    null
);
create table PARTICIP_EQIPE 
(
   IDEQUIPE             integer                        null,
   NUMMAT               integer                        not null,
   IDMIT                int                            not null,
   PARTIE               char                           not null,
   
   foreign key (IDEQUIPE) references EQUIPEDEMATCH (IDEQUIPE),
   foreign key (NUMMAT)references MATCHE (NUMMAT),
   foreign key (IDMIT)references MITNPS (IDMIT),
   constraint PK_PARTICIP_EQIPE primary key clustered (NUMMAT, IDMIT, PARTIE)
);
