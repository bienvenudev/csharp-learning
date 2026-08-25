-- SELECT *
-- FROM hacker_news
-- ORDER BY score DESC;

-- Start by getting a feel for the hacker_news table! Let’s find the most popular Hacker News stories
SELECT title, url, score
FROM hacker_news
ORDER BY score DESC
LIMIT 5;

-- Find the total score of all the stories.
SELECT SUM(score) AS 'total_score'
FROM hacker_news;

-- Find the individual users who have gotten combined scores of more than 200, and their combined scores.
SELECT user, SUM(score)
FROM hacker_news
GROUP BY user
HAVING SUM(score) > 200;

-- Add their scores together and divide it by the total sum.
SELECT (517 + 309 + 304 + 282) / 6366.0;

-- Some power users are rickrolling, how many times has each offending user posted this link?
SELECT user,
   COUNT(*)
FROM hacker_news
WHERE url LIKE '%watch?v=dQw4w9WgXcQ%'
GROUP BY user;

-- Categorize each story based on their source
-- SELECT CASE
--    WHEN url LIKE '%github.com%' THEN 'GitHub'
--    WHEN url LIKE '%medium.com%' THEN 'Medium'
--    WHEN url LIKE '%nytimes.com%' THEN 'New York Times'
--    ELSE 'Other'
--   END AS 'Source'
-- FROM hacker_news;

-- Build on the previous query: Add a column for the number of stories from each URL using COUNT().
SELECT CASE
   WHEN url LIKE '%github.com%' THEN 'GitHub'
   WHEN url LIKE '%medium.com%' THEN 'Medium'
   WHEN url LIKE '%nytimes.com%' THEN 'New York Times'
   ELSE 'Other'
  END AS 'Source',
  COUNT(*)
FROM hacker_news
GROUP BY 1;

-- 
SELECT timestamp
FROM hacker_news
LIMIT 10;

-- 
SELECT timestamp,
   strftime('%H', timestamp)
FROM hacker_news
GROUP BY 1
LIMIT 20;

--  Let’s write a query that returns three columns: The hours of the timestamp, The average score for each hour, The count of stories for each hour
SELECT strftime('%H', timestamp), 
   AVG(score),
   COUNT(*)
FROM hacker_news
GROUP BY 1
ORDER BY 2 DESC;

-- What are the best hours to post a story on Hacker News?
-- What's the best time to post a story?

SELECT strftime('%H', timestamp) AS 'Hour', 
   ROUND(AVG(score), 1) AS 'Average Score', 
   COUNT(*) AS 'Number of Stories'
FROM hacker_news
WHERE timestamp IS NOT NULL
GROUP BY 1
ORDER BY 2 DESC;
