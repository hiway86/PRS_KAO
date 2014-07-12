SELECT     a_1.vdid AS 設備序號, a_1.vdid AS 設備編號, a_1.datacollecttime AS 時間, a_1.vsrdir AS 方向, a_1.week AS 星期, a_1.hours AS 時段, a_1.speed AS 速度, 
                      a_1.Laneoccupy AS 佔有率,a_1.flow as 流量, CONVERT(VARCHAR(20), s.SpeedAvg - s.SpeedStandard * s.Times) + '~' + CONVERT(VARCHAR(20), 
                      s.SpeedAvg + s.SpeedStandard * s.Times) AS 標準速度範圍, CONVERT(VARCHAR(10), s.LaneOccupyAvg - s.LaneOccupyStandard * 2) 
                      + '~' + CONVERT(VARCHAR(10), s.LaneOccupyAvg + s.LaneOccupyStandard * 2) AS 標準佔有率範圍,
                      CONVERT(VARCHAR(10), s.FlowAvg - s.FlowStandard * 2) 
                      + '~' + CONVERT(VARCHAR(10), s.FlowAvg + s.FlowStandard * 2) AS 流量範圍
                       , s.StandardNum AS 標準型態編號, 
                      s.TypeName AS 標準型態名稱
FROM         (SELECT     vdid, vsrdir, avg(speed) AS speed, avg(laneoccupy) AS Laneoccupy,AVG(ISNULL(volume_T,0)+volume_L+volume_S+volume_M)as flow, datacollecttime, 
                          DATEPART(WEEKDAY, datacollecttime) AS week, DATEPART(HOUR, datacollecttime) AS hours
                       FROM          dbo.VD_Value
                       GROUP BY vdid, vsrdir, datacollecttime) AS a_1 LEFT OUTER JOIN
                      dbo.VD_STANDARD AS s ON a_1.vdid = s.Vdid AND a_1.vsrdir = s.Vsrdir AND a_1.hours = s.Hours AND a_1.week = s.Week
WHERE     (a_1.Laneoccupy NOT BETWEEN s.LaneOccupyAvg - s.LaneOccupyStandard * s.Times AND s.LaneOccupyAvg + s.LaneOccupyStandard * s.Times) AND 
                      (s.TypeName = 'Default') OR (a_1.speed NOT BETWEEN s.SpeedAvg - s.SpeedStandard * s.Times AND s.SpeedAvg + s.SpeedStandard * s.Times)
                      OR (a_1.flow NOT BETWEEN s.FlowAvg-s.FlowStandard * s.Times AND s.FlowAvg+s.FlowStandard * s.Times)
                      
