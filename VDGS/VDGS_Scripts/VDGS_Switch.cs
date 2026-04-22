// <Kawakaze's Airport> - <Airport facilities for VRChat>
// Copyright (C) 2026 <KWKZ-ES1111>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
public class VDGS_Switch : UdonSharpBehaviour
{
    [Header("=== 1. 目标控制组 ===")]
    [Tooltip("在此放入所有需要开关的物体")]
    [SerializeField] private GameObject[] targetObjects;

    [Header("=== 2. 初始状态 ===")]
    [SerializeField] private bool isOn = false;

    [Header("=== 3. 交互设置 ===")]
    [Tooltip("交互显示的文字提示")]
    [SerializeField] private string interactText = "Toggle VDGS Power";
    [Tooltip("碰撞触发的冷却时间 (秒)")]
    [SerializeField] private float toggleCooldown = 0.5f;

    private float _lastToggleTime;

    void Start()
    {
        // 初始化交互文字
        this.InteractionText = interactText;
        UpdateVisuals();
    }

    // --- 模式 A: 选中并按 E 键交互 ---
    public override void Interact()
    {
        ToggleState();
    }

    // --- 模式 B: 物理碰撞触发 (手部或身体触碰) ---
    private void OnTriggerEnter(Collider other)
    {
        // 仅响应玩家触发
        if (other == null || !other.name.Contains("Hand") && !other.name.Contains("Finger")) return;
        
        if (Time.time - _lastToggleTime > toggleCooldown)
        {
            _lastToggleTime = Time.time;
            ToggleState();
        }
    }

    private void ToggleState()
    {
        isOn = !isOn;
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        if (targetObjects == null) return;

        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                obj.SetActive(isOn);
            }
        }
    }
}
