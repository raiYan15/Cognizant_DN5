-- ============================================================================
-- Exercise 18: Resource Availability Check
-- Objective: Identify missing resources.
-- 
-- Task:
-- List all events without any uploaded resources.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    e.status
FROM Events e
LEFT JOIN Resources r 
    ON e.event_id = r.event_id
WHERE r.resource_id IS NULL
ORDER BY e.event_id ASC;
