-- ============================================================================
-- Exercise 16: Unregistered Active Users
-- Objective: Find new but inactive users.
-- 
-- Task:
-- Retrieve users who created an account in the last 30 days but have not registered for any events.
-- ============================================================================

USE community_portal_db;

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.email,
    u.city,
    u.created_at AS account_created_date
FROM Users u
LEFT JOIN Registrations r 
    ON u.user_id = r.user_id
WHERE u.created_at >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
  AND r.registration_id IS NULL
ORDER BY u.created_at DESC;
