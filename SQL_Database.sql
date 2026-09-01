
CREATE DATABASE RaceDayDB;


CREATE TABLE VENUE (
    venue_id INT IDENTITY(1,1) PRIMARY KEY,
    venue_name VARCHAR(100) NOT NULL,
    location VARCHAR(150) NOT NULL,
    city VARCHAR(100) NOT NULL,
    province VARCHAR(100) NOT NULL,
    capacity INT NOT NULL,
    
    CONSTRAINT CK_Venue_Capacity
        CHECK (capacity > 0)
);

CREATE TABLE [USER] (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role VARCHAR(20) NOT NULL,
    phone VARCHAR(20),

    CONSTRAINT CK_User_Role
        CHECK (role IN ('ORGANISER', 'PARTICIPANT'))
);
