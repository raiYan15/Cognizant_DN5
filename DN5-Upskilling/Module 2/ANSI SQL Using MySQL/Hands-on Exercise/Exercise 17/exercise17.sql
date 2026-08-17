-- ============================================================================
-- Exercise 17: Multi-Session Speakers
-- Objective: Identify frequent speakers.
-- 
-- Task:
-- Find speakers handling more than one session across all events.
-- ============================================================================

USE community_portal_db;

SELECT 
    sp.speaker_id,
    sp.speaker_name,
    sp.email,
    COUNT(s.session_id) AS total_sessions_handled,
    COUNT(DISTINCT s.event_id) AS total_distinct_events
FROM Speakers sp
INNER JOIN Sessions s 
    ON sp.speaker_id = s.speaker_id
GROUP BY sp.speaker_id, sp.speaker_name, sp.email
HAVING COUNT(s.session_id) > 1
ORDER BY total_sessions_handled DESC, sp.speaker_name ASC;
