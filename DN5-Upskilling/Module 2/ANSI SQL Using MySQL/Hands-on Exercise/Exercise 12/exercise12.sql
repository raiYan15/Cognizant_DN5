-- ============================================================================
-- Exercise 12: Event with Maximum Sessions
-- Objective: Find the busiest event.
-- 
-- Task:
-- List the event(s) having the highest number of sessions.
-- ============================================================================

USE community_portal_db;

-- 1. Standard ANSI SQL using Subquery (Handles Ties)
SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(s.session_id) AS total_sessions
FROM Events e
INNER JOIN Sessions s 
    ON e.event_id = s.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(s.session_id) = (
    SELECT MAX(session_count)
    FROM (
        SELECT COUNT(session_id) AS session_count
        FROM Sessions
        GROUP BY event_id
    ) AS session_totals
);

-- 2. Window Function approach with DENSE_RANK() (MySQL 8.0+)
WITH EventSessionRank AS (
    SELECT 
        e.event_id,
        e.title AS event_title,
        COUNT(s.session_id) AS total_sessions,
        DENSE_RANK() OVER (ORDER BY COUNT(s.session_id) DESC) AS rank_pos
    FROM Events e
    INNER JOIN Sessions s 
        ON e.event_id = s.event_id
    GROUP BY e.event_id, e.title
)
SELECT 
    event_id,
    event_title,
    total_sessions
FROM EventSessionRank
WHERE rank_pos = 1;
