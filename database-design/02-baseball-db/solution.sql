SELECT * FROM teams;

-- Heaviest Hitters. This award goes to the team with the highest average weight of its batters on a given year.

SELECT AVG(people.weight),
    teams.name
FROM people
JOIN batting 
    ON people.playerid = batting.playerid
JOIN teams 
    ON batting.teamid = teams.teamid
    AND batting.yearid = teams.yearid
GROUP BY teams.name, teams.yearid
ORDER BY 1 DESC
LIMIT 1;


-- Shortest Sluggers. This award goes to the team with the smallest average height of its batters on a given year. 
-- This query should look very similar to the one you wrote to find the heaviest teams.

SELECT AVG(people.height),
	teams.name
FROM people
JOIN batting 
    ON people.playerid = batting.playerid
JOIN teams 
    ON batting.teamid = teams.teamid
    AND batting.yearid = teams.yearid
GROUP BY teams.name, teams.yearid
ORDER BY 1 ASC
LIMIT 1;

-- Biggest Spenders. This award goes to the team with the largest total salary of all players in a given year.

SELECT teams.name, SUM(salaries.salary), salaries.yearid
FROM teams
JOIN salaries
    ON salaries.teamid = teams.teamid
    AND salaries.yearid = teams.yearid
GROUP BY salaries.teamid, salaries.yearid, teams.name
ORDER BY 2 DESC
LIMIT 1;

-- This award goes to the team that had the smallest “cost per win” in 2010.

SELECT teams.name, salaries.yearid, ROUND(SUM(salaries.salary) / teams.w)
FROM teams
JOIN salaries
	ON salaries.teamid = teams.teamid
	AND salaries.yearid = teams.yearid
WHERE teams.yearid = 2010
GROUP BY salaries.teamid, salaries.yearid, teams.name, teams.w
ORDER BY 3 ASC
LIMIT 1;

-- This award goes to the pitcher who, in a given year, cost the most money per game in which they were the starting pitcher.

SELECT ROUND(SUM(salaries.salary) / pitching.gs), people.playerid, people.namegiven, salaries.yearid
FROM salaries
JOIN pitching ON salaries.playerid = pitching.playerid
	AND salaries.yearid = pitching.yearid
	AND salaries.teamid = pitching.teamid
JOIN people ON pitching.playerid = people.playerid
WHERE pitching.gs >= 10
GROUP BY salaries.yearid, people.playerid, people.namegiven, pitching.gs
ORDER BY 1 DESC
LIMIT 1;

-- Worst of the Best: The pitcher or batter inducted into the hall of fame with the worst career stats (you can decide what stat to look at)

SELECT ROUND(SUM(batting.h)::numeric / SUM(batting.ab), 3), people.namegiven
FROM batting
JOIN halloffame ON batting.playerid = halloffame.playerid
JOIN people ON batting.playerid = people.playerid
WHERE inducted = 'Y'
GROUP BY batting.playerid, people.namegiven
HAVING SUM(ab) > 1000
ORDER BY 1 ASC;
