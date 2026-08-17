-- ============================================================================
-- Exercise 13: Average Rating per City
-- Objective: Compare event quality by city.
-- 
-- Task:
-- Calculate the average feedback rating for events conducted in each city.
-- ============================================================================

USE community_portal_db;

SELECT 
    e.city,
    COUNT(DISTINCT e.event_id) AS total_events_with_feedback,
    COUNT(f.feedback_id) AS total_feedback_count,
    ROUND(AVG(f.rating), 2) AS average_rating
FROM Events e
INNER JOIN Feedback f 
    ON e.event_id = f.event_id
GROUP BY e.city
ORDER BY average_rating DESC, e.city ASC;
