using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniFramework.Pooling;
using UniFramework.Window;
using UniFramework.Machine;
using UniFramework.Singleton;
using YooAsset;

internal class FsmInitGame : IStateNode
{
	private StateMachine _machine;

	void IStateNode.OnCreate(StateMachine machine)
	{
		_machine = machine;
	}
	void IStateNode.OnEnter()
	{
		// UniSingleton.StartCoroutine(Prepare());
        Prepare();
    }
	void IStateNode.OnUpdate()
	{
	}
	void IStateNode.OnExit()
	{
	}

	private async void Prepare()
	{
		var handle = YooAssets.LoadAssetAsync<GameObject>("UICanvas");
		// yield return handle;
        await handle.ToUniTask();
		var canvas = handle.InstantiateSync();
		var desktop = canvas.transform.Find("Desktop").gameObject;
		GameObject.DontDestroyOnLoad(canvas);

		// 初始化窗口系统
		UniWindow.Initalize(desktop);

		// 初始化对象池系统
		UniPooling.Initalize();

		_machine.ChangeState<FsmSceneHome>();
	}
}