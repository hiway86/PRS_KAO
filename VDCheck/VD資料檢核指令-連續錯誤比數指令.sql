SELECT     a.設備編號, a.方向, a.星期, a.時段, a.標準型態名稱, a.grp, CONVERT(VARCHAR(20), min(a.速度)) + '~' + CONVERT(VARCHAR(20), max(a.速度)) AS 速度範圍, 
                      CONVERT(VARCHAR(20), min(a.佔有率)) + '~' + CONVERT(VARCHAR(20), max(a.佔有率)) AS 佔有率範圍,CONVERT(VARCHAR(20), min(a.流量)) + '~' + CONVERT(VARCHAR(20), max(a.流量)) AS 流量範圍, min(a.時間) AS 時間, count(*) AS [Counts]
FROM         (SELECT     ROW_NUMBER() OVER (PARTITION BY 標準型態名稱, 設備編號, 方向, 星期, 時段
                       ORDER BY 時間) AS row, *, dateadd(minute, - 1 * ROW_NUMBER() OVER (PARTITION BY 標準型態名稱, 設備編號, 方向, 星期, 時段
ORDER BY 時間), 時間) AS grp
FROM         View_CheckVD) AS a
GROUP BY a.設備編號, a.方向, a.星期, a.時段, a.標準型態名稱, a.grp

