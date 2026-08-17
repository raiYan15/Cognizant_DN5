-- ============================================================================
-- Exercise 19: Completed Events with Feedback Summary
-- Objective: Summarize completed events.
-- 
-- Task:
-- For completed events, display:
-- Total registrations
-- Average feedback rating
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    COUNT(DISTINCT r.registration_id) AS total_registrations,
    COALESCE(ROUND(AVG(f.rating), 2), 0.00) AS average_feedback_rating
FROM Events e
LEFT JOIN Registrations r 
    ON e.event_id = r.event_id
LEFT JOIN Feedback f 
    ON e.event_id = f.event_id
WHERE e.status = 'Completed'
GROUP BY e.event_id, e.title, e.city, e.event_date
ORDER BY e.event_date DESC;
