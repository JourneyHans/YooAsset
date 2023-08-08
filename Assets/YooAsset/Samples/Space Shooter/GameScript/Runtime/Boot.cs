using UniFramework.Singleton;
using UnityEngine;
using YooAsset;

public class SingletonTest : SingletonInstance<SingletonTest>, ISingleton {

    public void OnCreate(object createParam) {
        Debug.Log("[SingletonTest:OnCreate]");
    }

    public void OnUpdate() {

    }

    public void OnDestroy() {
        Debug.Log("[SingletonTest:OnDestroy]");
    }

    public void SimplePrint() {
        Debug.Log("Print...");
    }
}

public class Boot : MonoBehaviour
{
	/// <summary>
	/// 资源系统运行模式
	/// </summary>
	public EPlayMode PlayMode = EPlayMode.EditorSimulateMode;

	void Awake()
	{
		Debug.Log($"资源系统运行模式：{PlayMode}");
		Application.targetFrameRate = 60;
		Application.runInBackground = true;
	}
	void Start()
	{
		// // 初始化事件系统
		// UniEvent.Initalize();
		//
		// // 初始化单例系统
		// UniSingleton.Initialize();
		//
		// // 初始化资源系统
		// YooAssets.Initialize();
		// YooAssets.SetOperationSystemMaxTimeSlice(30);
		//
		// // 创建补丁管理器
		// UniSingleton.CreateSingleton<PatchManager>();
		//
		// // 开始补丁更新流程
		// PatchManager.Instance.Run(PlayMode);
	}

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            UniSingleton.CreateSingleton<SingletonTest>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            UniSingleton.DestroySingleton<SingletonTest>();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SingletonTest.Instance.SimplePrint();
        }
    }
}