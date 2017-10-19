using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadManager : Singleton<LoadManager> {

	// Use this for initialization
	public int lvl1;
	public int lvl2;
	public int lvl3;
	public int lvl4;

	void Awake()
	{
		public static SingletonController instance;

		private void Awake() {
			if (instance != null) {
				Destroy(gameObject);
			}else{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
		}
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/save.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/save.dat", FileMode.Open);
			SaveData newData = (SaveData)bf.Deserialize (file);
			file.Close ();
			lvl1 = newData.lvl_1;
			lvl2 = newData.lvl_2;
			lvl3 = newData.lvl_3;
			lvl4 = newData.lvl_4;
		}
	}

	[Serializable]
	class SaveData {
		public int lvl_1 = 1;
		public int lvl_2 = 0;
		public int lvl_3 = 0;
		public int lvl_4 = 0;
	}
}
