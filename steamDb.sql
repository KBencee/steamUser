CREATE TABLE `jatekok` (
  `id` integer PRIMARY KEY,
  `nev` varchar(255),
  `ertekeles` integer,
  `ertekelesekSZama` integer,
  `kiadasiDatum` timestamp
);

CREATE TABLE `beinditottJatekok` (
  `id` integer PRIMARY KEY,
  `jatekId` int,
  `felhasznaloNeve` varchar(255),
  `beinditasIdeje` timestamp
);

CREATE TABLE `felhasznalo` (
  `id` int PRIMARY KEY,
  `nev` varchar(255),
  `regisztracioDatum` date,
  `szuletett` date,
  `orszag` varchar(255)
);

ALTER TABLE `jatekok` ADD FOREIGN KEY (`id`) REFERENCES `beinditottJatekok` (`jatekId`);

ALTER TABLE `beinditottJatekok` ADD FOREIGN KEY (`felhasznaloNeve`) REFERENCES `felhasznalo` (`nev`);
