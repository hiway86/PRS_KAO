SELECT     a.�]�ƽs��, a.��V, a.�P��, a.�ɬq, a.�зǫ��A�W��, a.grp, CONVERT(VARCHAR(20), min(a.�t��)) + '~' + CONVERT(VARCHAR(20), max(a.�t��)) AS �t�׽d��, 
                      CONVERT(VARCHAR(20), min(a.�����v)) + '~' + CONVERT(VARCHAR(20), max(a.�����v)) AS �����v�d��,CONVERT(VARCHAR(20), min(a.�y�q)) + '~' + CONVERT(VARCHAR(20), max(a.�y�q)) AS �y�q�d��, min(a.�ɶ�) AS �ɶ�, count(*) AS [Counts]
FROM         (SELECT     ROW_NUMBER() OVER (PARTITION BY �зǫ��A�W��, �]�ƽs��, ��V, �P��, �ɬq
                       ORDER BY �ɶ�) AS row, *, dateadd(minute, - 1 * ROW_NUMBER() OVER (PARTITION BY �зǫ��A�W��, �]�ƽs��, ��V, �P��, �ɬq
ORDER BY �ɶ�), �ɶ�) AS grp
FROM         View_CheckVD) AS a
GROUP BY a.�]�ƽs��, a.��V, a.�P��, a.�ɬq, a.�зǫ��A�W��, a.grp

