using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour {
	public static AlarmManager Instance;//单例模式
    public List<AlarmRecord> alarmRecords= new List<AlarmRecord>();
    //在 C# 里，new 后面必须跟一个 ()，这代表你正在“执行创建指令”
    private void Awake()
	{
		Instance = this;
	}
	public void AddAlarmRecord(string deviceName,string alarmType)
	{
		AlarmRecord record=new AlarmRecord(deviceName, alarmType);
		alarmRecords.Add(record);
		Debug.Log("新增报警记录：" + record.deviceName + "," 
			+ record.alarmType + "," + record.alarmTime);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
