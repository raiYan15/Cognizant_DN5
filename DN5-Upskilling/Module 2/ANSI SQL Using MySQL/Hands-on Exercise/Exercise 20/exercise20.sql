-- ============================================================================
-- Exercise 20: User Engagement Index
-- Objective: Measure user participation.
-- 
-- Task:
-- For each user, calculate:
-- Number of events attended
-- Number of feedback submissions
-- ============================================================================

USE community_portal_db;

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.email,
    COUNT(DISTINCT r.event_id) AS events_attended,
    COUNT(DISTINCT f.feedback_id) AS feedback_submissions
FROM Users u
LEFT JOIN Registrations r 
    ON u.user_id = r.user_id
LEFT JOIN Feedback f 
    ON u.user_id = f.user_id
GROUP BY u.user_id, u.full_name, u.email
ORDER BY events_attended DESC, feedback_submissions DESC, u.user_id ASC;
