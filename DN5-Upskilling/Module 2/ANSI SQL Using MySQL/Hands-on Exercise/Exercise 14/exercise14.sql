-- ============================================================================
-- Exercise 14: Most Registered Events
-- Objective: Find the most popular events.
-- 
-- Task:
-- List the top 3 events based on total user registrations.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    COUNT(r.registration_id) AS total_registrations
FROM Events e
INNER JOIN Registrations r 
    ON e.event_id = r.event_id
GROUP BY e.event_id, e.title, e.city, e.event_date
ORDER BY total_registrations DESC, e.title ASC
LIMIT 3;
