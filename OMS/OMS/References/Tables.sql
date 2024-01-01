DROP TABLE kvar cascade CONSTRAINTS;

DROP TABLE elemenat cascade CONSTRAINTS;

DROP TABLE akcija cascade CONSTRAINTS;

CREATE TABLE kvar(
    Idk integer NOT NULL,
    KvarId VARCHAR(20) NOT NULL, 
    VremeKreiranja date NOT NULL,
    Status VARCHAR(25) DEFAULT 'Nepotvrdjen',
    KratakOpis VARCHAR(1000), 
    ElektricniElement VARCHAR(25), 
    OpisKvara VARCHAR(1999), 
    constraint kvar_PK primary key (KvarId),
    constraint kvar_FK foreign key (ElektricniElement) references elemenat(ElementId)
);

CREATE TABLE elemenat(
    Ide integer,
    ElementId VARCHAR(25) NOT NULL,
    Naziv VARCHAR(25),
    Tip VARCHAR(25),
    GeografskaSirina FLOAT,
    GeografskaDuzina FLOAT,
    NaponskiNivo VARCHAR(20) DEFAULT 'Srednji napon',
    constraint elemenat_PK primary key (ElementId)
);

Create table akcija(
    Ida integer,
    KvarId varchar(20) NOT NULL,
    VremeAkcije date NOT NULL,
    OpisPosla varchar(1000),
    constraint akcija_PK primary key (Ida),
    constraint akcija_FK foreign key (KvarId) references kvar(KvarId)
);
