using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UniFramework.Machine;
using UniFramework.Window;
using UniFramework.Singleton;
using YooAsset;

internal class FsmSceneHome : IStateNode
{
	private StateMachine _machine;

	void IStateNode.OnCreate(StateMachine machine)
	{
		_machine = machine;
	}
	void IStateNode.OnEnter()
	{
        Prepare();
    }
	void IStateNode.OnUpdate()
	{
	}
	void IStateNode.OnExit()
	{
		UniWindow.CloseWindow<UIHomeWindow>();
	}

	private async void Prepare() {
        await YooAssets.LoadSceneAsync("scene_home").ToUniTask();
        await UniWindow.OpenWindowAsync<UIHomeWindow>("UIHome");

		// 释放资源
		var package = YooAssets.GetPackage("DefaultPackage");
		package.UnloadUnusedAssets();
	}
}