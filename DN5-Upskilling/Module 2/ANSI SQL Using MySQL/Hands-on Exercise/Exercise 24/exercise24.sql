-- ============================================================================
-- Exercise 24: Average Session Duration per Event
-- Objective: Measure session duration.
-- 
-- Task:
-- Calculate the average session duration (in minutes) for each event.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(s.session_id) AS total_sessions,
    ROUND(AVG(TIMESTAMPDIFF(MINUTE, s.start_time, s.end_time)), 2) AS avg_session_duration_minutes
FROM Events e
INNER JOIN Sessions s 
    ON e.event_id = s.event_id
GROUP BY e.event_id, e.title
ORDER BY avg_session_duration_minutes DESC, e.event_id ASC;
