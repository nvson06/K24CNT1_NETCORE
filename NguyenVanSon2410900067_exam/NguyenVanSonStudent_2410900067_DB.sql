CREATE DATABASE NguyenVanSonStudent_2410900067_Db;
GO

USE NguyenVanSonStudent_2410900067_Db;
GO

CREATE TABLE NguyenVanSonStudent
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NguyenVanSonName NVARCHAR(100) NOT NULL,
    NguyenVanSonGender NVARCHAR(10) NOT NULL,
    NguyenVanSonBirthDay DATE NOT NULL,
    NguyenVanSonEmail VARCHAR(100) NOT NULL,
    NguyenVanSonPhone VARCHAR(15) NOT NULL,
    NguyenVanSonActive BIT NOT NULL DEFAULT 1
);
GO

INSERT INTO NguyenVanSonStudent
(
    NguyenVanSonName,
    NguyenVanSonGender,
    NguyenVanSonBirthDay,
    NguyenVanSonEmail,
    NguyenVanSonPhone,
    NguyenVanSonActive
)
VALUES
(
    N'Nguyễn Văn Sơn',
    N'Nam',
    '2006-10-02',
    'nguyenvanson02102k6@gmail.com',
    '0971840601',
    1
);
GO