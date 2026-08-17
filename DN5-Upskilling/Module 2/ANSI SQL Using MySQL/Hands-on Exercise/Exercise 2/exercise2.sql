-- ============================================================================
-- Exercise 2: Top Rated Events
-- Objective: Find the highest-rated events.
-- 
-- Task:
-- Identify events with the highest average rating.
-- Consider only events with at least 10 feedback submissions.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(f.feedback_id) AS total_feedback_count,
    ROUND(AVG(f.rating), 2) AS average_rating
FROM Events e
INNER JOIN Feedback f 
    ON e.event_id = f.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(f.feedback_id) >= 10
ORDER BY average_rating DESC, total_feedback_count DESC;
