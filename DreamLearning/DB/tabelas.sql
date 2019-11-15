create table Address(
   Inep VARCHAR(20) NOT NULL PRIMARY KEY,
   Logradouro VARCHAR(100) NOT NULL,
   Numero VARCHAR(20) NOT NULL,
   Email VARCHAR(60) NOT NULL,
   Bairro VARCHAR(60),
   Cep VARCHAR(2) NOT NULL
);

create table GeolocationPoint(
   Inep VARCHAR(20) NOT NULL PRIMARY KEY,
   Latitude VARCHAR(20) NOT NULL,
   Longitude VARCHAR(20) NOT NULL
);


create table School(
   Inep VARCHAR(20) NOT NULL PRIMARY KEY,
   Nome VARCHAR(100) NOT NULL,
   AbreviacaoNome VARCHAR(20) NOT NULL,
   Email VARCHAR(60) NOT NULL,
   Telefone VARCHAR(60)
);
