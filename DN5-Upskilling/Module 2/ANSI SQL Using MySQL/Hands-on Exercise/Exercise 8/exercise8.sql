-- ============================================================================
-- Exercise 8: Sessions per Upcoming Event
-- Objective: Count sessions.
-- 
-- Task:
-- Display all upcoming events.
-- Show the number of sessions scheduled for each.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    e.event_date,
    e.status,
    COUNT(s.session_id) AS total_sessions_scheduled
FROM Events e
LEFT JOIN Sessions s 
    ON e.event_id = s.event_id
WHERE e.status = 'Upcoming' OR e.event_date >= CURDATE()
GROUP BY e.event_id, e.title, e.event_date, e.status
ORDER BY e.event_date ASC;
