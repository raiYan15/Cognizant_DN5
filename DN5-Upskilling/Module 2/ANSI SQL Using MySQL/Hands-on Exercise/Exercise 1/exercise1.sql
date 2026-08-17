-- ============================================================================
-- Exercise 1: User Upcoming Events
-- Objective: Display upcoming events for registered users.
-- 
-- Task:
-- Show all upcoming events a user is registered for in their city.
-- Sort the results by event date.
-- ============================================================================

USE community_portal_db;

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.city AS user_city,
    e.event_id,
    e.title AS event_title,
    e.city AS event_city,
    e.event_date,
    e.status AS event_status
FROM Users u
INNER JOIN Registrations r 
    ON u.user_id = r.user_id
INNER JOIN Events e 
    ON r.event_id = e.event_id
WHERE e.city = u.city
  AND (e.status = 'Upcoming' OR e.event_date >= CURDATE())
ORDER BY e.event_date ASC;
