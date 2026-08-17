-- ============================================================================
-- Exercise 7: Low Feedback Alerts
-- Objective: Identify poor feedback.
-- 
-- Task:
-- List users who gave a rating less than 3.
-- Display:
-- User name
-- Comments
-- Event name
-- ============================================================================

USE community_portal_db;

SELECT 
    u.full_name AS user_name,
    f.rating,
    f.comments,
    e.title AS event_name
FROM Feedback f
INNER JOIN Users u 
    ON f.user_id = u.user_id
INNER JOIN Events e 
    ON f.event_id = e.event_id
WHERE f.rating < 3
ORDER BY f.rating ASC, u.full_name ASC;
