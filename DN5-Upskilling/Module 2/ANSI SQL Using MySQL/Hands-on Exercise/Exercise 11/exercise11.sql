-- ============================================================================
-- Exercise 11: Daily New User Count
-- Objective: Analyze user registrations.
-- 
-- Task:
-- Find the number of users who registered each day during the last 7 days.
-- ============================================================================

USE community_portal_db;

-- Primary Query: New User Account Sign-ups per day in the last 7 days
SELECT 
    DATE(created_at) AS registration_date,
    COUNT(user_id) AS new_users_count
FROM Users
WHERE created_at >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
GROUP BY DATE(created_at)
ORDER BY registration_date DESC;

-- Alternative Query: Daily Event Registrations in the last 7 days
SELECT 
    DATE(registration_date) AS event_registration_date,
    COUNT(registration_id) AS total_event_registrations,
    COUNT(DISTINCT user_id) AS distinct_users_registered
FROM Registrations
WHERE registration_date >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
GROUP BY DATE(registration_date)
ORDER BY event_registration_date DESC;
