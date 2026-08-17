-- ============================================================================
-- Exercise 3: Inactive Users
-- Objective: Identify inactive users.
-- 
-- Task:
-- Retrieve users who have not registered for any events in the last 90 days.
-- ============================================================================

USE community_portal_db;

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.email,
    u.city,
    MAX(r.registration_date) AS last_registration_date
FROM Users u
LEFT JOIN Registrations r 
    ON u.user_id = r.user_id
GROUP BY u.user_id, u.full_name, u.email, u.city
HAVING MAX(r.registration_date) < DATE_SUB(CURDATE(), INTERVAL 90 DAY)
    OR MAX(r.registration_date) IS NULL
ORDER BY u.user_id ASC;
