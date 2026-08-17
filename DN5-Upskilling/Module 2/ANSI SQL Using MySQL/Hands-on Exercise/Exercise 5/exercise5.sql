-- ============================================================================
-- Exercise 5: Most Active Cities
-- Objective: Find cities with the highest participation.
-- 
-- Task:
-- List the top 5 cities with the highest number of distinct user registrations.
-- ============================================================================

USE community_portal_db;

SELECT 
    u.city,
    COUNT(DISTINCT r.user_id) AS distinct_registered_users
FROM Users u
INNER JOIN Registrations r 
    ON u.user_id = r.user_id
GROUP BY u.city
ORDER BY distinct_registered_users DESC, u.city ASC
LIMIT 5;
