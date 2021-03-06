﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InputRecord
{
    public EKeyList key;
    public bool pressed;//抬起还是按下
}

public class InputBase : TblBase
{
    public override string TableName { get { return "Input"; } }
    public int Idx;
    public string Lines;
    public string LinesAir;
    public string InputString;
    public int DelayFrame;
}

public class InputItem
{
    public int state;
    public int totalState;
    public int frame;
    public char[] keyInput;
    public EKeyList[] KeyInput;
    public Dictionary<int, List<int>> lines = new Dictionary<int, List<int>>();//存储 行-行里的Pose集合
    public Dictionary<int, List<int>> linesAir = new Dictionary<int, List<int>>();
    public int Idx;
    public MeteorUnit mOwner;//输入控制者
    EKeyList last;
    string to;
    public override string ToString()
    {
        if (string.IsNullOrEmpty(to))
            to = new string(keyInput);
        return to;
    }

    public InputItem(MeteorUnit owner)
    {
        mOwner = owner;
    }

    public bool OnKeyDown(KeyState k)
    {
        if (KeyInput.Length < state || state < 0)
            return false;
        if (k.Key == KeyInput[state])
        {
            state++;
            if (state == totalState)
            {
                int target = -1;
                if (Check(out target))
                {
                    //Debug.LogError("action change:" + target);
                    mOwner.posMng.LinkAction(target);
                    Reset();
                    return true;
                }
                else
                {
                    Reset();//有部分情况会影响其他招式输入状态
                }
            }
            else
            {
                frame = AppInfo.GetWaitForNextInput();
            }
        }
        return false;
    }

    public bool OnKeyUp(KeyState k)
    {
        return false;
    }

    public bool OnKeyPressing(KeyState k)
    {
        if (k.Key == KeyInput[state] && totalState != 1)
        {
            state++;
            if (state == totalState)
            {
                int target = -1;
                if (Check(out target))
                {
                    mOwner.posMng.LinkAction(target);
                    Reset();
                    return true;
                }
                else
                {
                    Reset();//有部分情况会影响其他招式输入状态
                }
            }
            else
            {
                frame = AppInfo.GetWaitForNextInput();
            }
        }
        return false;
    }

    bool Check(out int targetPose)
    {
        if (mOwner != null)
        {
            //技能中的动作，不许接输入
            if (mOwner.IsPlaySkill)
            {
                targetPose = -1;
                return false;
            }
            if (ActionInterrupt.Instance.Whole.ContainsKey(mOwner.posMng.mActiveAction.Idx) || mOwner.GetWeaponType() == (int)EquipWeaponType.Gun)
            {
                int targetIdx = mOwner.posMng.mActiveAction.Idx;

                //滚动或者闪动。可以连任意Pose与Idle一样
                if (targetIdx >= 164 && targetIdx <= 179)
                    targetIdx = 0;

                //任意准备动作，可以接任意Pose与Idle一样
                if (targetIdx >= CommonAction.DartReady && targetIdx <= CommonAction.HammerReady)
                    targetIdx = 0;
                if (targetIdx >= CommonAction.ZhihuReady && targetIdx <= CommonAction.RendaoReady)
                    targetIdx = 0;

                //部分火枪动作，翻滚，攻击，都有后摇，不允许立即切换，必须等待动作完成
                if (mOwner.GunReady && !mOwner.posMng.IsAttackPose() && 
                    !(mOwner.posMng.mActiveAction.Idx >= CommonAction.DCForw && mOwner.posMng.mActiveAction.Idx <= CommonAction.DCBack))
                {
                    targetIdx = CommonAction.Idle;//模拟普通IDLE就可以发其他火枪招式了
                    //Debug.LogError("useGun");
                }

                if (!ActionInterrupt.Instance.Whole.ContainsKey(targetIdx))
                {
                    Debug.LogError("not contains:" + targetIdx);
                    targetPose = -1;
                    return false;
                }

                ActionNode no = ActionInterrupt.Instance.Whole[targetIdx];
                //if (targetIdx == 200)
                //{
                //    Debug.LogError("200--");
                //}
                if (mOwner.IsOnGround())
                {
                    //拦截火枪的状态机，只要不处于213-使用火枪就进入212POSE
                    if (!mOwner.GunReady && mOwner.GetWeaponType() == (int)EquipWeaponType.Gun)
                    {
                        targetPose = CommonAction.GunReload;
                        //Debug.LogError("targetPose = 212");
                        return true;
                    }

                    foreach (var each in lines)
                    {
                        for (int i = 0; i < no.target.Count; i++)
                        {
                            if (each.Value.Contains(no.target[i].ActionIdx))
                            {
                                bool ret = mOwner.controller.Input.CheckPos(each.Key, no.target[i].ActionIdx);
                                if (ret)
                                {
                                    targetPose = no.target[i].ActionIdx;
                                    //if (targetPose == 200 && targetIdx == 200)
                                    //{
                                    //    Debug.DebugBreak();
                                    //    Debug.LogError("link 200");
                                    //}
                                    return ret;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var each in linesAir)
                    {
                        for (int i = 0; i < no.target.Count; i++)
                        {
                            if (each.Value.Contains(no.target[i].ActionIdx))
                            {
                                bool ret = mOwner.controller.Input.CheckPos(each.Key, no.target[i].ActionIdx);
                                if (ret)
                                {
                                    targetPose = no.target[i].ActionIdx;
                                    return ret;
                                }
                            }
                        }
                    }
                }
            }
        }
        targetPose = -1;
        return false;
    }

    //bool CheckPose(int pose)
    //{
    //    return Global.GMeteorInput.HasMapInput(,pose);
    //    switch (pose)
    //    {
    //        case 259:
    //            if (MeteorManager.Instance.LocalPlayer.AngryValue < 100)
    //                return false;
    //        break;
    //        case 88:
    //        case 150:
    //            if (MeteorManager.Instance.LocalPlayer.AngryValue < 60)
    //                return false;
    //            return true;
    //    }
    //    return false;
    //}

    public void Reset()
    {
        state = 0;
        frame = AppInfo.GetWaitForNextInput();
    }

    public bool Wait()
    {
        if (state != 0 && state != totalState)
            return true;
        return false;
    }

    public void Update()
    {
        frame -= 1;
        if (frame < 0)
            Reset();
    }
}

[Serializable]
public class KeyState
{
    public string AxisName;
    public float PressedTime = 10.0f;
    public float ReleasedTime = 10.0f;
    public int Pressed = 0;// 0=release 1=click 2=double click
    public bool IsAI;
    public EKeyList Key;
};

public class InputModule
{
    MeteorUnit mOwner;
    public List<InputItem> inputs = new List<InputItem>();
    //SortedList input = new SortedList();//KeyMap与招式的对应关系.
    public InputModule(MeteorUnit owner)
    {
        if (inputs.Count != 0)
            return;
        mOwner = owner;
        List<InputBase> ipts = GameData.inputMng.GetFullRow();
        for (int i = 0; i < ipts.Count; i++)
        {
            InputItem it = new InputItem(owner);
            it.Idx = ipts[i].Idx;
            it.keyInput = ipts[i].InputString.ToCharArray();
            it.KeyInput = new EKeyList[it.keyInput.Length];
            for (int j = 0; j < it.keyInput.Length; j++)
            {
                if (it.keyInput[j] == 'W')
                    it.KeyInput[j] = EKeyList.KL_KeyW;
                else
                if (it.keyInput[j] == 'S')
                    it.KeyInput[j] = EKeyList.KL_KeyS;
                else
                if (it.keyInput[j] == 'A')
                    it.KeyInput[j] = EKeyList.KL_KeyA;
                else
                if (it.keyInput[j] == 'D')
                    it.KeyInput[j] = EKeyList.KL_KeyD;
                else
                if (it.keyInput[j] == 'J')
                    it.KeyInput[j] = EKeyList.KL_Attack;
                //else
                //if (it.keyInput[j] == 'K')
                //    it.KeyInput[j] = EKeyList.KL_Jump;
            }

            string[] str = ipts[i].Lines.Trim(new char[] { '\"', '\t' }).Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < str.Length; j++)
            {
                it.lines.Add(int.Parse(str[j]), new List<int>());
            }
            str = ipts[i].LinesAir.Trim(new char[] { '\"', '\t' }).Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < str.Length; j++)
            {
                it.linesAir.Add(int.Parse(str[j]), new List<int>());
            }
            it.frame = AppInfo.GetWaitForNextInput();
            it.state = 0;
            it.totalState = it.keyInput.Length;
            int[] lines = new int[it.lines.Keys.Count];
            it.lines.Keys.CopyTo(lines, 0);
            int[] linesAir = new int[it.linesAir.Keys.Count];
            it.linesAir.Keys.CopyTo(linesAir, 0);

            for (int j = 0; j < lines.Length; j++)
            {
                if (ActionInterrupt.Instance.Lines.ContainsKey(lines[j]))
                {
                    for (int k = 0; k < ActionInterrupt.Instance.Lines[lines[j]].Count; k++)
                    {
                        it.lines[lines[j]].Add(ActionInterrupt.Instance.Lines[lines[j]][k]);
                    }
                }
                else
                    Debug.Log("line:" + lines[j] + " miss");
            }
            for (int j = 0; j < linesAir.Length; j++)
            {
                if (ActionInterrupt.Instance.Lines.ContainsKey(linesAir[j]))
                {
                    for (int k = 0; k < ActionInterrupt.Instance.Lines[linesAir[j]].Count; k++)
                    {
                        it.linesAir[linesAir[j]].Add(ActionInterrupt.Instance.Lines[linesAir[j]][k]);
                    }
                }
                else
                    Debug.Log("line:" + linesAir[j] + " miss");
            }
            inputs.Add(it);
            //input.Add(i, it.);
        }
        //foreach (DictionaryEntry each in input)
        //{
        //    Debug.LogError("line:" + (each.Value));
        //}
    }

    public void Update()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            //等待下一个指令输入的，需要更新
            if (inputs[i].Wait())
                inputs[i].Update();
        }
    }

    public void Reset()
    {
        for (int i = 0; i < inputs.Count; i++)
            inputs[i].Reset();
    }

    //这里要集中处理，因为招式很有可能会同时满足多个
    //类似 匕首 后前前手，既触发 大绝招 又出发 前前手，这个时候，应该设置一个冲掉机制，让输入长度长的招式 优先与 输入长度短的招式
    public bool OnKeyDown(KeyState keyStatus)
    {
        //从后往前遍历，长的招式冲断短的招式。
        //测试招式
        //for (int i = inputs.Count - 1; i >= 0; i--)
        //{
        //    if (mOwner.Attr.IsPlayer && keyStatus.Key == EKeyList.KL_Attack)
        //        Debug.LogError(string.Format("testinput:{0}", inputs[i].ToString()));
        //}

        for (int i = inputs.Count - 1; i >= 0; i--)
        {
            //if (inputs[i].ToString() == "SSWJ" && keyStatus.Key == EKeyList.KL_Attack && mOwner.Attr.IsPlayer && (mOwner.posMng.mActiveAction.Idx == 431 || mOwner.posMng.mActiveAction.Idx == 485))//乾坤刀绝招?
            //    Debug.DebugBreak();
            if (inputs[i].OnKeyDown(keyStatus))
            {
                //if (mOwner.Attr.IsPlayer && keyStatus.Key == EKeyList.KL_Attack)
                //    Debug.LogError(string.Format("accept testinput:{0}", inputs[i].ToString()));
                return true;
            }
        }
        return false;
    }

    public void OnKeyUp(KeyState keyStatus)
    {
        //从后往前遍历，长的招式冲断短的招式。
        for (int i = inputs.Count - 1; i >= 0; i--)
        {
            if (inputs[i].OnKeyUp(keyStatus))
                break;
        }
    }

    public void OnKeyPressing(KeyState keyStatus)
    {
        //从后往前遍历，长的招式冲断短的招式。
        for (int i = inputs.Count - 1; i >= 0; i--)
        {
            if (inputs[i].OnKeyPressing(keyStatus))
                return;
        }
    }
}