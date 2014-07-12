SELECT vdid,vsrdir,avg(speed)as SpeedAvg,isnull(stdev(speed),0) as SpeedStandard,              
avg(laneoccupy) as laneoccupyAvg,isnull(stdev(laneoccupy),0)as LaneOccupyStandard,               
avg(isnull(volume_T,0)+volume_L+volume_S+volume_M) as FlowAvg,isnull(stdev(isnull(volume_T,0)+volume_L+volume_S+volume_M),0)as FlowStandard,              
DatePart(WEEKDAY, datacollecttime) as week,DatePart(HOUR, datacollecttime) as hours  
from VD_Value_his  where vdid = '64000V000661' AND vsrdir = '0'  AND (isnull(volume_T,0)+volume_L+volume_S+volume_M) < 60  
and speed < 255 and laneoccupy < 100   
AND ((isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0 and speed <> 0 or (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0 and laneoccupy <> 0)  
AND (laneoccupy <> 0 and speed <> 0 or laneoccupy <> 0 and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> 0) 
AND (speed <>  laneoccupy and speed <>  (isnull(volume_T,0)+volume_L+volume_S+volume_M) and (isnull(volume_T,0)+volume_L+volume_S+volume_M) <> laneoccupy)  
AND datacollecttime between '2013/12/04 15:47'  and '2014/07/05 15:47'  
GROUP BY vdid,vsrdir,DatePart(WEEKDAY, datacollecttime), DatePart(HOUR, datacollecttime)   
Order by vdid,DatePart(WEEKDAY, datacollecttime),DatePart(HOUR, datacollecttime)  