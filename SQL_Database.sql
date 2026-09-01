
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
