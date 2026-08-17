-- ============================================================================
-- Exercise 9: Organizer Event Summary
-- Objective: Summarize organizer activities.
-- 
-- Task:
-- For each organizer, display:
-- Number of events created
-- Current event status (Upcoming, Completed, Cancelled)
-- ============================================================================

USE community_portal_db;

-- 1. Status-wise grouping per Organizer
SELECT 
    o.organizer_id,
    o.name AS organizer_name,
    COALESCE(e.status, 'No Events') AS event_status,
    COUNT(e.event_id) AS event_count
FROM Organizers o
LEFT JOIN Events e 
    ON o.organizer_id = e.organizer_id
GROUP BY o.organizer_id, o.name, e.status
ORDER BY o.organizer_id ASC, e.status ASC;

-- 2. Pivot Summary Matrix per Organizer
SELECT 
    o.organizer_id,
    o.name AS organizer_name,
    COUNT(e.event_id) AS total_events_created,
    SUM(CASE WHEN e.status = 'Upcoming' THEN 1 ELSE 0 END) AS upcoming_events,
    SUM(CASE WHEN e.status = 'Completed' THEN 1 ELSE 0 END) AS completed_events,
    SUM(CASE WHEN e.status = 'Cancelled' THEN 1 ELSE 0 END) AS cancelled_events
FROM Organizers o
LEFT JOIN Events e 
    ON o.organizer_id = e.organizer_id
GROUP BY o.organizer_id, o.name
ORDER BY o.organizer_id ASC;
