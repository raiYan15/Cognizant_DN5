-- ============================================================================
-- ANSI SQL Using MySQL Hands-on Exercises (All 25 Exercises)
-- Database: community_portal_db
-- ============================================================================

USE community_portal_db;

-- ----------------------------------------------------------------------------
-- Exercise 1: User Upcoming Events
-- Task: Show all upcoming events a user is registered for in their city. Sort by event date.
-- ----------------------------------------------------------------------------
SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.city AS user_city,
    e.event_id,
    e.title AS event_title,
    e.city AS event_city,
    e.event_date,
    e.status AS event_status
FROM Users u
INNER JOIN Registrations r 
    ON u.user_id = r.user_id
INNER JOIN Events e 
    ON r.event_id = e.event_id
WHERE e.city = u.city
  AND (e.status = 'Upcoming' OR e.event_date >= CURDATE())
ORDER BY e.event_date ASC;

-- ----------------------------------------------------------------------------
-- Exercise 2: Top Rated Events
-- Task: Identify events with highest average rating having at least 10 feedback submissions.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 3: Inactive Users
-- Task: Retrieve users who have not registered for any events in the last 90 days.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 4: Peak Session Hours
-- Task: Count number of sessions scheduled between 10:00 AM and 12:00 PM for each event.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(s.session_id) AS morning_session_count
FROM Events e
LEFT JOIN Sessions s 
    ON e.event_id = s.event_id
    AND s.start_time >= '10:00:00' 
    AND s.start_time <= '12:00:00'
GROUP BY e.event_id, e.title
ORDER BY e.event_id ASC;

-- ----------------------------------------------------------------------------
-- Exercise 5: Most Active Cities
-- Task: List top 5 cities with highest distinct user registrations.
-- ----------------------------------------------------------------------------
SELECT 
    u.city,
    COUNT(DISTINCT r.user_id) AS distinct_registered_users
FROM Users u
INNER JOIN Registrations r 
    ON u.user_id = r.user_id
GROUP BY u.city
ORDER BY distinct_registered_users DESC, u.city ASC
LIMIT 5;

-- ----------------------------------------------------------------------------
-- Exercise 6: Event Resource Summary
-- Task: Report count of PDFs, Images, and Links per event.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    COALESCE(SUM(CASE WHEN r.resource_type = 'pdf' THEN 1 ELSE 0 END), 0) AS pdf_count,
    COALESCE(SUM(CASE WHEN r.resource_type = 'image' THEN 1 ELSE 0 END), 0) AS image_count,
    COALESCE(SUM(CASE WHEN r.resource_type = 'link' THEN 1 ELSE 0 END), 0) AS link_count,
    COUNT(r.resource_id) AS total_resources
FROM Events e
LEFT JOIN Resources r 
    ON e.event_id = r.event_id
GROUP BY e.event_id, e.title
ORDER BY e.event_id ASC;

-- ----------------------------------------------------------------------------
-- Exercise 7: Low Feedback Alerts
-- Task: List users who gave rating < 3 with user name, comments, and event name.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 8: Sessions per Upcoming Event
-- Task: Display upcoming events and total scheduled session count.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    e.event_date,
    e.status,
    COUNT(s.session_id) AS total_sessions_scheduled
FROM Events e
LEFT JOIN Sessions s 
    ON e.event_id = s.event_id
WHERE e.status = 'Upcoming' OR e.event_date >= CURDATE()
GROUP BY e.event_id, e.title, e.event_date, e.status
ORDER BY e.event_date ASC;

-- ----------------------------------------------------------------------------
-- Exercise 9: Organizer Event Summary
-- Task: Summarize event count and statuses for each organizer.
-- ----------------------------------------------------------------------------
SELECT 
    o.organizer_id,
    o.name AS organizer_name,
    COALESCE(e.status, 'No Events') AS event_status,
    COUNT(e.event_id) AS event_count
FROM Organizers o
LEFT JOIN Events e 
    ON o.organizer_id = e.organizer_id
GROUP BY o.organizer_id, o.name, e.status
ORDER BY o.organizer_id ASC, e.status ASC;

-- ----------------------------------------------------------------------------
-- Exercise 10: Feedback Gap
-- Task: Identify events with registrations but no feedback submissions.
-- ----------------------------------------------------------------------------
SELECT DISTINCT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    e.status
FROM Events e
INNER JOIN Registrations r 
    ON e.event_id = r.event_id
LEFT JOIN Feedback f 
    ON e.event_id = f.event_id
WHERE f.feedback_id IS NULL
ORDER BY e.event_id ASC;

-- ----------------------------------------------------------------------------
-- Exercise 11: Daily New User Count
-- Task: Number of users who registered each day in the last 7 days.
-- ----------------------------------------------------------------------------
SELECT 
    DATE(created_at) AS registration_date,
    COUNT(user_id) AS new_users_count
FROM Users
WHERE created_at >= DATE_SUB(CURDATE(), INTERVAL 7 DAY)
GROUP BY DATE(created_at)
ORDER BY registration_date DESC;

-- ----------------------------------------------------------------------------
-- Exercise 12: Event with Maximum Sessions
-- Task: Find the event(s) having the highest number of sessions.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(s.session_id) AS total_sessions
FROM Events e
INNER JOIN Sessions s 
    ON e.event_id = s.event_id
GROUP BY e.event_id, e.title
HAVING COUNT(s.session_id) = (
    SELECT MAX(session_count)
    FROM (
        SELECT COUNT(session_id) AS session_count
        FROM Sessions
        GROUP BY event_id
    ) AS session_totals
);

-- ----------------------------------------------------------------------------
-- Exercise 13: Average Rating per City
-- Task: Calculate average feedback rating for events conducted in each city.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 14: Most Registered Events
-- Task: Top 3 events based on total user registrations.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    COUNT(r.registration_id) AS total_registrations
FROM Events e
INNER JOIN Registrations r 
    ON e.event_id = r.event_id
GROUP BY e.event_id, e.title, e.city, e.event_date
ORDER BY total_registrations DESC, e.title ASC
LIMIT 3;

-- ----------------------------------------------------------------------------
-- Exercise 15: Event Session Time Conflict
-- Task: Identify overlapping sessions within the same event.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    s1.session_id AS session_1_id,
    s1.title AS session_1_title,
    s1.start_time AS session_1_start,
    s1.end_time AS session_1_end,
    s2.session_id AS session_2_id,
    s2.title AS session_2_title,
    s2.start_time AS session_2_start,
    s2.end_time AS session_2_end
FROM Sessions s1
INNER JOIN Sessions s2 
    ON s1.event_id = s2.event_id 
   AND s1.session_id < s2.session_id
INNER JOIN Events e 
    ON s1.event_id = e.event_id
WHERE s1.start_time < s2.end_time 
  AND s1.end_time > s2.start_time
ORDER BY e.event_id, s1.start_time;

-- ----------------------------------------------------------------------------
-- Exercise 16: Unregistered Active Users
-- Task: Users created in the last 30 days who haven't registered for any events.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 17: Multi-Session Speakers
-- Task: Find speakers handling more than one session across all events.
-- ----------------------------------------------------------------------------
SELECT 
    sp.speaker_id,
    sp.speaker_name,
    sp.email,
    COUNT(s.session_id) AS total_sessions_handled,
    COUNT(DISTINCT s.event_id) AS total_distinct_events
FROM Speakers sp
INNER JOIN Sessions s 
    ON sp.speaker_id = s.speaker_id
GROUP BY sp.speaker_id, sp.speaker_name, sp.email
HAVING COUNT(s.session_id) > 1
ORDER BY total_sessions_handled DESC, sp.speaker_name ASC;

-- ----------------------------------------------------------------------------
-- Exercise 18: Resource Availability Check
-- Task: List all events without any uploaded resources.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    e.status
FROM Events e
LEFT JOIN Resources r 
    ON e.event_id = r.event_id
WHERE r.resource_id IS NULL
ORDER BY e.event_id ASC;

-- ----------------------------------------------------------------------------
-- Exercise 19: Completed Events with Feedback Summary
-- Task: For completed events, display total registrations and average rating.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    COUNT(DISTINCT r.registration_id) AS total_registrations,
    COALESCE(ROUND(AVG(f.rating), 2), 0.00) AS average_feedback_rating
FROM Events e
LEFT JOIN Registrations r 
    ON e.event_id = r.event_id
LEFT JOIN Feedback f 
    ON e.event_id = f.event_id
WHERE e.status = 'Completed'
GROUP BY e.event_id, e.title, e.city, e.event_date
ORDER BY e.event_date DESC;

-- ----------------------------------------------------------------------------
-- Exercise 20: User Engagement Index
-- Task: For each user, calculate events attended and feedback submissions.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 21: Top Feedback Providers
-- Task: Top 5 users who submitted the most feedback.
-- ----------------------------------------------------------------------------
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

-- ----------------------------------------------------------------------------
-- Exercise 22: Duplicate Registrations Check
-- Task: Identify users registered more than once for the same event.
-- ----------------------------------------------------------------------------
SELECT 
    r.user_id,
    u.full_name AS user_name,
    u.email,
    r.event_id,
    e.title AS event_title,
    COUNT(r.registration_id) AS registration_count
FROM Registrations r
INNER JOIN Users u 
    ON r.user_id = u.user_id
INNER JOIN Events e 
    ON r.event_id = e.event_id
GROUP BY r.user_id, u.full_name, u.email, r.event_id, e.title
HAVING COUNT(r.registration_id) > 1
ORDER BY registration_count DESC, r.user_id ASC;

-- ----------------------------------------------------------------------------
-- Exercise 23: Registration Trends
-- Task: Month-wise registration count for the past 12 months.
-- ----------------------------------------------------------------------------
SELECT 
    DATE_FORMAT(registration_date, '%Y-%m') AS registration_month,
    COUNT(registration_id) AS total_registrations
FROM Registrations
WHERE registration_date >= DATE_SUB(CURDATE(), INTERVAL 12 MONTH)
GROUP BY DATE_FORMAT(registration_date, '%Y-%m')
ORDER BY registration_month ASC;

-- ----------------------------------------------------------------------------
-- Exercise 24: Average Session Duration per Event
-- Task: Calculate average session duration (in minutes) for each event.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    COUNT(s.session_id) AS total_sessions,
    ROUND(AVG(TIMESTAMPDIFF(MINUTE, s.start_time, s.end_time)), 2) AS avg_session_duration_minutes
FROM Events e
INNER JOIN Sessions s 
    ON e.event_id = s.event_id
GROUP BY e.event_id, e.title
ORDER BY avg_session_duration_minutes DESC, e.event_id ASC;

-- ----------------------------------------------------------------------------
-- Exercise 25: Events Without Sessions
-- Task: List all events that currently have no sessions scheduled.
-- ----------------------------------------------------------------------------
SELECT 
    e.event_id,
    e.title AS event_title,
    e.city,
    e.event_date,
    e.status
FROM Events e
LEFT JOIN Sessions s 
    ON e.event_id = s.event_id
WHERE s.session_id IS NULL
ORDER BY e.event_id ASC;
