-- ============================================================================
-- Exercise 4: Peak Session Hours
-- Objective: Analyze session timings.
-- 
-- Task:
-- Count the number of sessions scheduled between 10:00 AM and 12:00 PM for each event.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(s.session_id) AS morning_session_count
FROM Events e
LEFT JOIN Sessions s 
    ON e.event_id = s.event_id
    AND s.start_time >= '10:00:00' 
    AND s.start_time <= '12:00:00'
GROUP BY e.event_id, e.title
ORDER BY e.event_id ASC;
