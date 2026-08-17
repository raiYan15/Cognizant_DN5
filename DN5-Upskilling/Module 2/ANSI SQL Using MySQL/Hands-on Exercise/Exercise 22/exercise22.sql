-- ============================================================================
-- Exercise 22: Duplicate Registrations Check
-- Objective: Detect duplicate registrations.
-- 
-- Task:
-- Identify users registered more than once for the same event.
-- ============================================================================

USE community_portal_db;

SELECT 
    r.user_id,
    u.full_name AS user_name,
    u.email,
    r.event_id,
    e.title AS event_title,
    COUNT(r.registration_id) AS registration_count
FROM Registrations r
INNER JOIN Users u 
    ON r.user_id = u.user_id
INNER JOIN Events e 
    ON r.event_id = e.event_id
GROUP BY r.user_id, u.full_name, u.email, r.event_id, e.title
HAVING COUNT(r.registration_id) > 1
ORDER BY registration_count DESC, r.user_id ASC;
