-- ============================================================================
-- Exercise 23: Registration Trends
-- Objective: Analyze monthly registrations.
-- 
-- Task:
-- Display the month-wise registration count for the past 12 months.
-- ============================================================================

USE community_portal_db;

SELECT 
    DATE_FORMAT(registration_date, '%Y-%m') AS registration_month,
    COUNT(registration_id) AS total_registrations
FROM Registrations
WHERE registration_date >= DATE_SUB(CURDATE(), INTERVAL 12 MONTH)
GROUP BY DATE_FORMAT(registration_date, '%Y-%m')
ORDER BY registration_month ASC;
