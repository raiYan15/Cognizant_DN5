-- ============================================================================
-- Exercise 21: Top Feedback Providers
-- Objective: Identify active reviewers.
-- 
-- Task:
-- List the top 5 users who submitted the most feedback.
-- ============================================================================

USE community_portal_db;

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.email,
    COUNT(f.feedback_id) AS total_feedback_submitted
FROM Users u
INNER JOIN Feedback f 
    ON u.user_id = f.user_id
GROUP BY u.user_id, u.full_name, u.email
ORDER BY total_feedback_submitted DESC, u.full_name ASC
LIMIT 5;
