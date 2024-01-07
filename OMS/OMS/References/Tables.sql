DROP TABLE kvar cascade CONSTRAINTS;

DROP TABLE elemenat cascade CONSTRAINTS;

DROP TABLE akcija cascade CONSTRAINTS;

CREATE SEQUENCE kvar_sequence
    START WITH 1
    INCREMENT BY 1
    NOCACHE
    NOCYCLE;
    
    CREATE SEQUENCE element_sequence
    START WITH 1
    INCREMENT BY 1
    NOCACHE
    NOCYCLE;
    CREATE SEQUENCE akcija_sequence
    START WITH 1
    INCREMENT BY 1
    NOCACHE
    NOCYCLE;


CREATE TABLE elemenat(
    Ide integer DEFAULT element_sequence.NEXTVAL NOT NULL,
    ElementId VARCHAR(25) NOT NULL,
    Naziv VARCHAR(25),
    Tip VARCHAR(25),
    GeografskaSirina FLOAT,
    GeografskaDuzina FLOAT,
    NaponskiNivo VARCHAR(20) DEFAULT 'Srednji napon',
    constraint elemenat_PK primary key (ElementId)
);

create TABLE kvar(
    Idk integer DEFAULT kvar_sequence.NEXTVAL NOT NULL,
    KvarId VARCHAR(20) NOT NULL, 
    VremeKreiranja date NOT NULL,
    Status VARCHAR(25) DEFAULT 'Nepotvrdjen',
    KratakOpis VARCHAR(1000), 
    ElektricniElement VARCHAR(25), 
    OpisKvara VARCHAR(1999), 
    constraint kvar_PK primary key (KvarId),
    constraint kvar_FK foreign key (ElektricniElement) references elemenat(ElementId)
);



Create table akcija(
    Ida integer DEFAULT akcija_sequence.NEXTVAL NOT NULL,
    KvarId varchar(20) NOT NULL,
    VremeAkcije date NOT NULL,
    OpisPosla varchar(1000),
    constraint akcija_PK primary key (Ida),
    constraint akcija_FK foreign key (KvarId) references kvar(KvarId)
);


INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ('E001', 'Transformer1', 'Transformator', 40.7128, -74.0060, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E002', 'Generator1', 'Generator', 34.0522, -118.2437, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E003', 'Line1', 'Linija', 51.5074, -0.1278, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E004', 'Transformer2', 'Transformator', 45.4215, -75.6994, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E005', 'Line2', 'Linija', 52.5200, 13.4050, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E006', 'Substation1', 'Podstanica', 41.8781, -87.6298, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E007', 'Transformer3', 'Transformator', 37.7749, -122.4194, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E008', 'Line3', 'Linija', 45.4642, 9.1900, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E009', 'Generator2', 'Generator', 34.0522, -118.2437, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E010', 'Substation2', 'Podstanica', 51.1657, 10.4515, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E011', 'Line4', 'Linija', 48.8566, 2.3522, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E012', 'Transformer4', 'Transformator', 37.7749, -122.4194, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E013', 'Generator3', 'Generator', 41.9028, 12.4964, 'Srednji napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E014', 'Substation3', 'Podstanica', 40.7128, -74.0060, 'Visoki napon');

INSERT INTO elemenat ( ElementId, Naziv, Tip, GeografskaSirina, GeografskaDuzina, NaponskiNivo)
VALUES ( 'E015', 'Line5', 'Linija', 34.0522, -118.2437, 'Srednji napon');


INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_01', SYSDATE, 'Nepotvrdjen', 'Kratki opis kvara 1', 'E001', 'Detaljan opis kvara 1');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_02', SYSDATE, 'Potvrdjen', 'Kratki opis kvara 2', 'E005', 'Detaljan opis kvara 2');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_03', SYSDATE, 'Otklonjen', 'Kratki opis kvara 3', 'E012', 'Detaljan opis kvara 3');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_04', SYSDATE, 'Nepotvrdjen', 'Kratki opis kvara 4', 'E002', 'Detaljan opis kvara 4');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_05', SYSDATE, 'Potvrdjen', 'Kratki opis kvara 5', 'E007', 'Detaljan opis kvara 5');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_06', SYSDATE, 'Otklonjen', 'Kratki opis kvara 6', 'E010', 'Detaljan opis kvara 6');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_07', SYSDATE, 'Nepotvrdjen', 'Kratki opis kvara 7', 'E003', 'Detaljan opis kvara 7');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_08', SYSDATE, 'Potvrdjen', 'Kratki opis kvara 8', 'E009', 'Detaljan opis kvara 8');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_09', SYSDATE, 'Otklonjen', 'Kratki opis kvara 9', 'E014', 'Detaljan opis kvara 9');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_10', SYSDATE, 'Nepotvrdjen', 'Kratki opis kvara 10', 'E006', 'Detaljan opis kvara 10');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_11', SYSDATE, 'Potvrdjen', 'Kratki opis kvara 11', 'E011', 'Detaljan opis kvara 11');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_12', SYSDATE, 'Otklonjen', 'Kratki opis kvara 12', 'E013', 'Detaljan opis kvara 12');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_13', SYSDATE, 'Nepotvrdjen', 'Kratki opis kvara 13', 'E004', 'Detaljan opis kvara 13');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_14', SYSDATE, 'Zatvoreno', 'Kratki opis kvara 14', 'E008', 'Detaljan opis kvara 14');

INSERT INTO kvar ( KvarId, VremeKreiranja, Status, KratakOpis, ElektricniElement, OpisKvara)
VALUES ( TO_CHAR(SYSDATE, 'yyyyMMddhhmmss') || '_15', SYSDATE, 'U_popravci', 'Kratki opis kvara 15', 'E015', 'Detaljan opis kvara 15');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_02', SYSDATE, 'Akcija 1');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_02', SYSDATE, 'Akcija 2');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_02', SYSDATE, 'Akcija 3');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_02', SYSDATE, 'Akcija 4');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_02', SYSDATE, 'Akcija 5');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_02', SYSDATE, 'Akcija 6');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_03', SYSDATE, 'Akcija 7128');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_03', SYSDATE, 'Akcija 1000');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_03', SYSDATE, 'Akcija 523');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_03', SYSDATE, 'Akcija 124');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_03', SYSDATE, 'Akcija 12321');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_01', SYSDATE, 'Akcija 124124');

INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_01', SYSDATE, 'Akcija 123123');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_01', SYSDATE, 'Akcija 1231');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_01', SYSDATE, 'Akcija 541241');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_01', SYSDATE, 'Akcija 1141');


INSERT INTO akcija (KvarId, VremeAkcije, OpisPosla)
VALUES ( '20240107020152_01', SYSDATE, 'Akcija 1142421');

COMMIT;


