-- ============================================================================
-- Local Community Event Portal Database
-- ANSI SQL Using MySQL - Schema & Sample Data Setup
-- ============================================================================

DROP DATABASE IF EXISTS community_portal_db;
CREATE DATABASE community_portal_db;
USE community_portal_db;

-- ----------------------------------------------------------------------------
-- Table: Users
-- ----------------------------------------------------------------------------
CREATE TABLE Users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    city VARCHAR(50) NOT NULL,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- ----------------------------------------------------------------------------
-- Table: Organizers
-- ----------------------------------------------------------------------------
CREATE TABLE Organizers (
    organizer_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contact_number VARCHAR(20)
);

-- ----------------------------------------------------------------------------
-- Table: Events
-- ----------------------------------------------------------------------------
CREATE TABLE Events (
    event_id INT AUTO_INCREMENT PRIMARY KEY,
    title VARCHAR(150) NOT NULL,
    description TEXT,
    city VARCHAR(50) NOT NULL,
    event_date DATE NOT NULL,
    status ENUM('Upcoming', 'Completed', 'Cancelled') NOT NULL DEFAULT 'Upcoming',
    organizer_id INT NOT NULL,
    FOREIGN KEY (organizer_id) REFERENCES Organizers(organizer_id) ON DELETE CASCADE
);

-- ----------------------------------------------------------------------------
-- Table: Speakers
-- ----------------------------------------------------------------------------
CREATE TABLE Speakers (
    speaker_id INT AUTO_INCREMENT PRIMARY KEY,
    speaker_name VARCHAR(100) NOT NULL,
    bio TEXT,
    email VARCHAR(100) NOT NULL
);

-- ----------------------------------------------------------------------------
-- Table: Sessions
-- ----------------------------------------------------------------------------
CREATE TABLE Sessions (
    session_id INT AUTO_INCREMENT PRIMARY KEY,
    event_id INT NOT NULL,
    speaker_id INT NOT NULL,
    title VARCHAR(150) NOT NULL,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id) ON DELETE CASCADE,
    FOREIGN KEY (speaker_id) REFERENCES Speakers(speaker_id) ON DELETE CASCADE
);

-- ----------------------------------------------------------------------------
-- Table: Registrations
-- ----------------------------------------------------------------------------
CREATE TABLE Registrations (
    registration_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    event_id INT NOT NULL,
    registration_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (event_id) REFERENCES Events(event_id) ON DELETE CASCADE
);

-- ----------------------------------------------------------------------------
-- Table: Feedback
-- ----------------------------------------------------------------------------
CREATE TABLE Feedback (
    feedback_id INT AUTO_INCREMENT PRIMARY KEY,
    event_id INT NOT NULL,
    user_id INT NOT NULL,
    rating INT NOT NULL CHECK (rating BETWEEN 1 AND 5),
    comments TEXT,
    feedback_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (event_id) REFERENCES Events(event_id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE
);

-- ----------------------------------------------------------------------------
-- Table: Resources
-- ----------------------------------------------------------------------------
CREATE TABLE Resources (
    resource_id INT AUTO_INCREMENT PRIMARY KEY,
    event_id INT NOT NULL,
    resource_type ENUM('pdf', 'image', 'link') NOT NULL,
    resource_url VARCHAR(255) NOT NULL,
    FOREIGN KEY (event_id) REFERENCES Events(event_id) ON DELETE CASCADE
);

-- ============================================================================
-- Sample Data Insertion
-- ============================================================================

-- Organizers
INSERT INTO Organizers (organizer_id, name, email, contact_number) VALUES
(1, 'Green Earth Society', 'contact@greenearth.org', '555-0101'),
(2, 'Tech Innovators Hub', 'events@techinnovators.org', '555-0102'),
(3, 'City Arts & Heritage Guild', 'guild@cityarts.org', '555-0103'),
(4, 'Downtown Wellness Association', 'info@wellnessassoc.org', '555-0104');

-- Users
INSERT INTO Users (user_id, full_name, email, city, created_at) VALUES
(1, 'Alice Johnson', 'alice.j@example.com', 'Austin', '2026-01-10 09:00:00'),
(2, 'Bob Martinez', 'bob.m@example.com', 'Seattle', '2026-02-15 10:30:00'),
(3, 'Charlie Davis', 'charlie.d@example.com', 'Austin', '2026-03-01 11:15:00'),
(4, 'Diana Patel', 'diana.p@example.com', 'San Francisco', '2026-04-20 14:00:00'),
(5, 'Evan Wright', 'evan.w@example.com', 'Denver', '2026-05-12 16:45:00'),
(6, 'Fiona Clark', 'fiona.c@example.com', 'Austin', '2026-06-05 08:30:00'),
(7, 'George Miller', 'george.m@example.com', 'Seattle', '2026-07-01 12:00:00'),
(8, 'Hannah Abbott', 'hannah.a@example.com', 'Chicago', '2026-07-25 15:20:00'),
(9, 'Ian Somer', 'ian.s@example.com', 'New York', '2026-08-01 09:10:00'),
(10, 'Julia Roberts', 'julia.r@example.com', 'Denver', '2026-08-10 11:00:00'),
(11, 'Kevin Bacon', 'kevin.b@example.com', 'Austin', '2026-08-12 13:40:00'),
(12, 'Laura Croft', 'laura.c@example.com', 'Seattle', '2026-08-14 10:00:00'),
(13, 'Michael Scott', 'michael.s@example.com', 'Scranton', '2026-08-15 09:30:00'),
(14, 'Nancy Wheeler', 'nancy.w@example.com', 'Austin', '2026-08-16 14:20:00'),
(15, 'Oscar Martinez', 'oscar.m@example.com', 'Austin', '2026-08-17 08:00:00');

-- Events
INSERT INTO Events (event_id, title, description, city, event_date, status, organizer_id) VALUES
(1, 'Community Solar Energy Summit', 'Workshop on clean urban energy solutions.', 'Austin', '2026-09-15', 'Upcoming', 1),
(2, 'AI & Robotics Maker Expo', 'Hands-on hardware & software showcase.', 'Seattle', '2026-09-20', 'Upcoming', 2),
(3, 'Austin Downtown Art Walk', 'Explore murals, photography, and local indie art.', 'Austin', '2026-10-05', 'Upcoming', 3),
(4, 'Urban Farming & Gardening Meet', 'Learn organic urban farming in compact spaces.', 'Denver', '2026-05-10', 'Completed', 1),
(5, 'Cloud Architecture Day 2026', 'Deep dive into microservices and cloud scalability.', 'Seattle', '2026-06-15', 'Completed', 2),
(6, 'Mindfulness & Yoga in the Park', 'Outdoor session for mental clarity and flexibility.', 'Austin', '2026-07-20', 'Completed', 4),
(7, 'Indie Music Fest 2026', 'Community music event featuring local bands.', 'Chicago', '2026-08-01', 'Cancelled', 3),
(8, 'Clean City River Cleanup', 'Volunteers gathering to clean the shoreline.', 'Austin', '2026-11-12', 'Upcoming', 1),
(9, 'Web3 & Decentralized Web Forum', 'Decentralized identity and smart contracts.', 'San Francisco', '2026-12-01', 'Upcoming', 2),
(10, 'Youth Robotics Championship', 'Annual STEM competition for young builders.', 'Seattle', '2026-08-25', 'Upcoming', 2);

-- Speakers
INSERT INTO Speakers (speaker_id, speaker_name, bio, email) VALUES
(1, 'Dr. Aris Thorne', 'Clean Energy Specialist & Researcher', 'aris.thorne@example.com'),
(2, 'Sarah Connor', 'Lead Robotics Engineer', 'sarah.c@example.com'),
(3, 'Marcus Vance', 'Contemporary Visual Artist', 'marcus.v@example.com'),
(4, 'Elena Rostova', 'Permaculture Designer', 'elena.r@example.com'),
(5, 'David Kim', 'Principal Cloud Architect', 'david.k@example.com'),
(6, 'Priya Sharma', 'Holistic Wellness Instructor', 'priya.s@example.com');

-- Sessions (including 10am-12pm sessions, multi-session speakers, overlapping sessions for conflict detection)
INSERT INTO Sessions (session_id, event_id, speaker_id, title, start_time, end_time) VALUES
(1, 1, 1, 'Keynote: Solar Innovations', '10:00:00', '11:15:00'),
(2, 1, 1, 'Interactive Panel: Grid Storage', '11:30:00', '12:30:00'),
(3, 1, 4, 'Community Solar Grants', '14:00:00', '15:30:00'),
(4, 2, 2, 'Autonomous Navigation Systems', '10:30:00', '11:45:00'),
(5, 2, 2, 'Robotics Workshop Live Demo', '11:00:00', '12:30:00'), -- Overlaps with session 4 on Event 2
(6, 2, 5, 'Edge Computing in Robotics', '13:30:00', '15:00:00'),
(7, 3, 3, 'Public Art & Mural Tour', '10:15:00', '11:45:00'),
(8, 4, 4, 'Soil Health and Composting', '09:00:00', '10:30:00'),
(9, 4, 4, 'Hydroponics for Small Spaces', '11:00:00', '12:30:00'),
(10, 5, 5, 'Distributed Caching Strategies', '09:30:00', '11:00:00'),
(11, 5, 5, 'Zero Trust Architecture', '11:15:00', '12:45:00'),
(12, 6, 6, 'Guided Morning Meditation', '08:00:00', '09:30:00'),
(13, 6, 6, 'Pranayama Breathing Techniques', '10:00:00', '11:00:00'),
(14, 10, 2, 'Junior Robotics Arena Briefing', '10:00:00', '11:30:00'),
(15, 10, 5, 'Sensors and Actuators Demo', '11:45:00', '13:00:00');

-- Registrations (including past 12 months, recent registrations, duplicates)
INSERT INTO Registrations (registration_id, user_id, event_id, registration_date) VALUES
(1, 1, 1, '2026-08-10 10:00:00'),
(2, 3, 1, '2026-08-11 11:30:00'),
(3, 6, 1, '2026-08-12 14:00:00'),
(4, 14, 1, '2026-08-16 15:20:00'),
(5, 2, 2, '2026-08-05 09:10:00'),
(6, 7, 2, '2026-08-08 12:40:00'),
(7, 12, 2, '2026-08-14 16:00:00'),
(8, 1, 3, '2026-08-01 10:15:00'),
(9, 3, 3, '2026-08-02 11:45:00'),
(10, 1, 3, '2026-08-03 12:00:00'), -- Duplicate registration for User 1 on Event 3
(11, 4, 4, '2026-04-25 10:00:00'),
(12, 5, 4, '2026-04-28 14:30:00'),
(13, 10, 4, '2026-05-01 09:00:00'),
(14, 2, 5, '2026-05-20 11:00:00'),
(15, 4, 5, '2026-05-25 15:30:00'),
(16, 7, 5, '2026-06-01 13:00:00'),
(17, 1, 6, '2026-06-25 08:30:00'),
(18, 3, 6, '2026-07-01 09:45:00'),
(19, 6, 6, '2026-07-05 10:15:00'),
(20, 8, 7, '2026-07-15 16:20:00'),
(21, 1, 8, '2026-08-15 08:45:00'),
(22, 11, 8, '2026-08-16 09:00:00'),
(23, 2, 10, '2026-08-12 14:10:00'),
(24, 7, 10, '2026-08-13 15:00:00');

-- Feedback (including ratings < 3, events with >= 10 reviews, multiple feedback providers)
INSERT INTO Feedback (feedback_id, event_id, user_id, rating, comments, feedback_date) VALUES
(1, 5, 1, 5, 'Spectacular architecture sessions and great networking!', '2026-06-16 10:00:00'),
(2, 5, 2, 5, 'The best tech event in Seattle this year.', '2026-06-16 11:15:00'),
(3, 5, 3, 4, 'Very insightful, slides were crisp.', '2026-06-16 12:00:00'),
(4, 5, 4, 5, 'Flawless cloud demos by David Kim.', '2026-06-16 14:20:00'),
(5, 5, 5, 4, 'Great deep dive into microservices.', '2026-06-16 15:00:00'),
(6, 5, 6, 5, 'Super well organized.', '2026-06-16 16:10:00'),
(7, 5, 7, 4, 'Loved the interactive Q&A session.', '2026-06-16 17:00:00'),
(8, 5, 8, 5, 'Highly recommend to all backend engineers.', '2026-06-17 09:30:00'),
(9, 5, 9, 4, 'Good venue and refreshments.', '2026-06-17 10:45:00'),
(10, 5, 10, 5, 'Outstanding zero trust architecture overview.', '2026-06-17 11:20:00'),
(11, 5, 11, 4, 'Learned practical caching mechanisms.', '2026-06-17 13:00:00'),
(12, 4, 4, 4, 'Inspiring ideas for rooftop gardens.', '2026-05-11 10:00:00'),
(13, 4, 5, 5, 'Loved Elena’s composting workshop.', '2026-05-11 11:30:00'),
(14, 4, 10, 2, 'Venue was too crowded and audio was muffled.', '2026-05-11 14:00:00'),
(15, 6, 1, 5, 'So relaxing and centering.', '2026-07-21 08:30:00'),
(16, 6, 3, 2, 'The park background noise was distracting.', '2026-07-21 09:00:00'),
(17, 6, 6, 1, 'Started 30 minutes late, lacked proper shade.', '2026-07-21 10:00:00');

-- Resources
INSERT INTO Resources (resource_id, event_id, resource_type, resource_url) VALUES
(1, 1, 'pdf', 'https://portal.local/resources/solar_handbook.pdf'),
(2, 1, 'pdf', 'https://portal.local/resources/austin_rebate_guidelines.pdf'),
(3, 1, 'image', 'https://portal.local/resources/solar_rooftop_blueprint.png'),
(4, 1, 'link', 'https://energy.gov/clean-energy-initiatives'),
(5, 2, 'pdf', 'https://portal.local/resources/robotics_starter_guide.pdf'),
(6, 2, 'link', 'https://github.com/maker-expo/2026-demos'),
(7, 3, 'image', 'https://portal.local/resources/downtown_art_map.jpg'),
(8, 3, 'image', 'https://portal.local/resources/artist_mural_preview.png'),
(9, 4, 'pdf', 'https://portal.local/resources/urban_composting_manual.pdf'),
(10, 5, 'pdf', 'https://portal.local/resources/cloud_patterns_whitepaper.pdf'),
(11, 5, 'link', 'https://cloud-scaler.org/reference-architectures');
