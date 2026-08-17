-- ============================================================================
-- Exercise 6: Event Resource Summary
-- Objective: Summarize event resources.
-- 
-- Task:
-- Generate a report showing the number of:
-- PDFs
-- Images
-- Links
-- uploaded for each event.
-- ============================================================================

USE community_portal_db;

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
