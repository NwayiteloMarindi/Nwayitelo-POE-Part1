
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



CREATE TABLE RACE_EVENT (
    event_id INT IDENTITY(1,1) PRIMARY KEY,
    venue_id INT NOT NULL,
    organizer_id INT NOT NULL,
    event_name VARCHAR(150) NOT NULL,
    event_date DATE NOT NULL,
    description VARCHAR(500),
    status VARCHAR(20) NOT NULL DEFAULT 'UPCOMING',

    CONSTRAINT FK_Event_Venue
        FOREIGN KEY (venue_id)
        REFERENCES VENUE(venue_id),

    CONSTRAINT FK_Event_Organizer
        FOREIGN KEY (organizer_id)
        REFERENCES [USER](user_id),

    CONSTRAINT CK_Event_Status
        CHECK (status IN ('UPCOMING', 'ACTIVE', 'COMPLETED', 'CANCELLED'))
);

CREATE TABLE RACE (
    race_id INT IDENTITY(1,1) PRIMARY KEY,
    event_id INT NOT NULL,
    race_name VARCHAR(100) NOT NULL,
    race_number INT NOT NULL,
    distance DECIMAL(6,2) NOT NULL,
    start_time TIME NOT NULL,
    description VARCHAR(300),

    CONSTRAINT FK_Race_Event
        FOREIGN KEY (event_id)
        REFERENCES RACE_EVENT(event_id),

    CONSTRAINT CK_Race_Distance
        CHECK (distance > 0),

    CONSTRAINT CK_Race_Number
        CHECK (race_number > 0),

    CONSTRAINT UQ_Race_Event_Number
        UNIQUE (event_id, race_number)
);

CREATE TABLE PARTICIPANT (
    participant_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL UNIQUE,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    phone VARCHAR(20),
    date_of_birth DATE NOT NULL,
    gender VARCHAR(20),
    address VARCHAR(200),

    CONSTRAINT FK_Participant_User
        FOREIGN KEY (user_id)
        REFERENCES [USER](user_id)
);

CREATE TABLE REGISTRATION (
    registration_id INT IDENTITY(1,1) PRIMARY KEY,
    race_id INT NOT NULL,
    participant_id INT NOT NULL,
    registration_date DATE NOT NULL DEFAULT GETDATE(),
    status VARCHAR(20) NOT NULL DEFAULT 'REGISTERED',

    CONSTRAINT FK_Registration_Race
        FOREIGN KEY (race_id)
        REFERENCES RACE(race_id),

    CONSTRAINT FK_Registration_Participant
        FOREIGN KEY (participant_id)
        REFERENCES PARTICIPANT(participant_id),

    CONSTRAINT UQ_Registration_Race_Participant
        UNIQUE (race_id, participant_id),

    CONSTRAINT CK_Registration_Status
        CHECK (status IN ('REGISTERED', 'CANCELLED', 'COMPLETED'))
);
