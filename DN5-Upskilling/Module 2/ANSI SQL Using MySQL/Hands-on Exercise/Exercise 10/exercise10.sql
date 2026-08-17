-- ============================================================================
-- Exercise 10: Feedback Gap
-- Objective: Find events lacking feedback.
-- 
-- Task:
-- Identify events that have registrations but no feedback.
-- ============================================================================

USE community_portal_db;

SELECT DISTINCT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    e.status
FROM Events e
INNER JOIN Registrations r 
    ON e.event_id = r.event_id
LEFT JOIN Feedback f 
    ON e.event_id = f.event_id
WHERE f.feedback_id IS NULL
ORDER BY e.event_id ASC;
