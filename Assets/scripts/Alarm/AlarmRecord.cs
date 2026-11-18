using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]//是存储报警信息的数据结构（private 字段也能在Inspector 里显示、修改）

public class AlarmRecord
//不用MonoBehaviour，因为需要的是一个普通数据类，而不是挂载在 GameObject 上的组件
//MonoBehaviour 是 Unity 中一个非常重要的基类。让普通 C# 类获得 Unity 游戏组件能力的基础类。
{
	public string deviceName;
	public string alarmType;
	public string alarmTime;

	//构造函数
	public AlarmRecord(string name, string type)
    {
        deviceName = name;
        alarmType = type;
		alarmTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    void Start () {
		
	}
	
	
	void Update () {
		
	}
}
