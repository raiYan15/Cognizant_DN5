-- ============================================================================
-- Exercise 25: Events Without Sessions
-- Objective: Find incomplete event schedules.
-- 
-- Task:
-- List all events that currently have no sessions scheduled.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    e.status
FROM Events e
LEFT JOIN Sessions s 
    ON e.event_id = s.event_id
WHERE s.session_id IS NULL
ORDER BY e.event_id ASC;
