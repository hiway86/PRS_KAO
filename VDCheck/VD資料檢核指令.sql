SELECT     a_1.vdid AS �]�ƧǸ�, a_1.vdid AS �]�ƽs��, a_1.datacollecttime AS �ɶ�, a_1.vsrdir AS ��V, a_1.week AS �P��, a_1.hours AS �ɬq, a_1.speed AS �t��, 
                      a_1.Laneoccupy AS �����v,a_1.flow as �y�q, CONVERT(VARCHAR(20), s.SpeedAvg - s.SpeedStandard * s.Times) + '~' + CONVERT(VARCHAR(20), 
                      s.SpeedAvg + s.SpeedStandard * s.Times) AS �зǳt�׽d��, CONVERT(VARCHAR(10), s.LaneOccupyAvg - s.LaneOccupyStandard * 2) 
                      + '~' + CONVERT(VARCHAR(10), s.LaneOccupyAvg + s.LaneOccupyStandard * 2) AS �зǦ����v�d��,
                      CONVERT(VARCHAR(10), s.FlowAvg - s.FlowStandard * 2) 
                      + '~' + CONVERT(VARCHAR(10), s.FlowAvg + s.FlowStandard * 2) AS �y�q�d��
                       , s.StandardNum AS �зǫ��A�s��, 
                      s.TypeName AS �зǫ��A�W��
FROM         (SELECT     vdid, vsrdir, avg(speed) AS speed, avg(laneoccupy) AS Laneoccupy,AVG(ISNULL(volume_T,0)+volume_L+volume_S+volume_M)as flow, datacollecttime, 
                          DATEPART(WEEKDAY, datacollecttime) AS week, DATEPART(HOUR, datacollecttime) AS hours
                       FROM          dbo.VD_Value
                       GROUP BY vdid, vsrdir, datacollecttime) AS a_1 LEFT OUTER JOIN
                      dbo.VD_STANDARD AS s ON a_1.vdid = s.Vdid AND a_1.vsrdir = s.Vsrdir AND a_1.hours = s.Hours AND a_1.week = s.Week
WHERE     (a_1.Laneoccupy NOT BETWEEN s.LaneOccupyAvg - s.LaneOccupyStandard * s.Times AND s.LaneOccupyAvg + s.LaneOccupyStandard * s.Times) AND 
                      (s.TypeName = 'Default') OR (a_1.speed NOT BETWEEN s.SpeedAvg - s.SpeedStandard * s.Times AND s.SpeedAvg + s.SpeedStandard * s.Times)
                      OR (a_1.flow NOT BETWEEN s.FlowAvg-s.FlowStandard * s.Times AND s.FlowAvg+s.FlowStandard * s.Times)
                      
