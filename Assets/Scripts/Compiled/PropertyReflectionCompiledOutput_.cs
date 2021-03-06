#if RAVEN_COMPILED
using System;
using System.Collections.Generic;


// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------


namespace Starlite.Raven.Compiler {
    
    
    public class PropertyReflectionCompiledOutput {
        
        #if UNITY_EDITOR
        #region Compiler Maps
        public static readonly Dictionary<string, ulong> s_NameToTargetHashMap = new Dictionary<string, ulong>()
        {
            { "UnityEngine.RectTransform.anchoredPosition", 16899892407691550664ul },
            { "UnityEngine.RectTransform.anchoredPosition3D", 6139277867611767050ul },
            { "UnityEngine.Transform.position", 3971334896386457419ul },
            { "UnityEngine.Transform.localPosition", 17890732708694817339ul },
            { "UnityEngine.RectTransform.sizeDelta", 10625774802725675592ul },
        };
        public static readonly Dictionary<ulong, FunctionDeclaration[]> s_TargetHashToFuncMap = new Dictionary<ulong, FunctionDeclaration[]>()
        {
            {
                16899892407691550664ul,
                new FunctionDeclaration[2]
                {
                    new FunctionDeclaration()
                    {
                        m_ID = 0,
                        m_FunctionName = "GetValue_16899892407691550664",
                        m_ArgumentType = "UnityEngine.Vector2",
                        m_ComponentType = "UnityEngine.RectTransform",
                        m_MemberName = "anchoredPosition",
                        m_CastStatement = "RavenPropertyGetter<UnityEngine.Vector2>",
                        m_Hash = 16899892407691550664ul,
                    },
                    new FunctionDeclaration()
                    {
                        m_ID = 1,
                        m_FunctionName = "SetValue_16899892407691550664",
                        m_ArgumentType = "UnityEngine.Vector2",
                        m_ComponentType = "UnityEngine.RectTransform",
                        m_MemberName = "anchoredPosition",
                        m_CastStatement = "RavenPropertySetter<UnityEngine.Vector2>",
                        m_Hash = 16899892407691550664ul,
                    },
                }
            },
            {
                6139277867611767050ul,
                new FunctionDeclaration[2]
                {
                    new FunctionDeclaration()
                    {
                        m_ID = 0,
                        m_FunctionName = "GetValue_6139277867611767050",
                        m_ArgumentType = "UnityEngine.Vector3",
                        m_ComponentType = "UnityEngine.RectTransform",
                        m_MemberName = "anchoredPosition3D",
                        m_CastStatement = "RavenPropertyGetter<UnityEngine.Vector3>",
                        m_Hash = 6139277867611767050ul,
                    },
                    new FunctionDeclaration()
                    {
                        m_ID = 1,
                        m_FunctionName = "SetValue_6139277867611767050",
                        m_ArgumentType = "UnityEngine.Vector3",
                        m_ComponentType = "UnityEngine.RectTransform",
                        m_MemberName = "anchoredPosition3D",
                        m_CastStatement = "RavenPropertySetter<UnityEngine.Vector3>",
                        m_Hash = 6139277867611767050ul,
                    },
                }
            },
            {
                3971334896386457419ul,
                new FunctionDeclaration[2]
                {
                    new FunctionDeclaration()
                    {
                        m_ID = 0,
                        m_FunctionName = "GetValue_3971334896386457419",
                        m_ArgumentType = "UnityEngine.Vector3",
                        m_ComponentType = "UnityEngine.Transform",
                        m_MemberName = "position",
                        m_CastStatement = "RavenPropertyGetter<UnityEngine.Vector3>",
                        m_Hash = 3971334896386457419ul,
                    },
                    new FunctionDeclaration()
                    {
                        m_ID = 1,
                        m_FunctionName = "SetValue_3971334896386457419",
                        m_ArgumentType = "UnityEngine.Vector3",
                        m_ComponentType = "UnityEngine.Transform",
                        m_MemberName = "position",
                        m_CastStatement = "RavenPropertySetter<UnityEngine.Vector3>",
                        m_Hash = 3971334896386457419ul,
                    },
                }
            },
            {
                17890732708694817339ul,
                new FunctionDeclaration[2]
                {
                    new FunctionDeclaration()
                    {
                        m_ID = 0,
                        m_FunctionName = "GetValue_17890732708694817339",
                        m_ArgumentType = "UnityEngine.Vector3",
                        m_ComponentType = "UnityEngine.Transform",
                        m_MemberName = "localPosition",
                        m_CastStatement = "RavenPropertyGetter<UnityEngine.Vector3>",
                        m_Hash = 17890732708694817339ul,
                    },
                    new FunctionDeclaration()
                    {
                        m_ID = 1,
                        m_FunctionName = "SetValue_17890732708694817339",
                        m_ArgumentType = "UnityEngine.Vector3",
                        m_ComponentType = "UnityEngine.Transform",
                        m_MemberName = "localPosition",
                        m_CastStatement = "RavenPropertySetter<UnityEngine.Vector3>",
                        m_Hash = 17890732708694817339ul,
                    },
                }
            },
            {
                10625774802725675592ul,
                new FunctionDeclaration[2]
                {
                    new FunctionDeclaration()
                    {
                        m_ID = 0,
                        m_FunctionName = "GetValue_10625774802725675592",
                        m_ArgumentType = "UnityEngine.Vector2",
                        m_ComponentType = "UnityEngine.RectTransform",
                        m_MemberName = "sizeDelta",
                        m_CastStatement = "RavenPropertyGetter<UnityEngine.Vector2>",
                        m_Hash = 10625774802725675592ul,
                    },
                    new FunctionDeclaration()
                    {
                        m_ID = 1,
                        m_FunctionName = "SetValue_10625774802725675592",
                        m_ArgumentType = "UnityEngine.Vector2",
                        m_ComponentType = "UnityEngine.RectTransform",
                        m_MemberName = "sizeDelta",
                        m_CastStatement = "RavenPropertySetter<UnityEngine.Vector2>",
                        m_Hash = 10625774802725675592ul,
                    },
                }
            },
        };
        public static readonly Dictionary<string, string> s_TargetClassSpecializationToNameMap = new Dictionary<string, string>()
        {
        };
        #endregion Compiler Maps
        #endif
        private static readonly Dictionary<ulong, Delegate[]> s_FunctionJumpTable = new Dictionary<ulong, Delegate[]>()
        {
            {
                16899892407691550664ul,
                new Delegate[]
                {
                    (RavenPropertyGetter<UnityEngine.Vector2>)GetValue_16899892407691550664,
                    (RavenPropertySetter<UnityEngine.Vector2>)SetValue_16899892407691550664,
                }
            },
            {
                6139277867611767050ul,
                new Delegate[]
                {
                    (RavenPropertyGetter<UnityEngine.Vector3>)GetValue_6139277867611767050,
                    (RavenPropertySetter<UnityEngine.Vector3>)SetValue_6139277867611767050,
                }
            },
            {
                3971334896386457419ul,
                new Delegate[]
                {
                    (RavenPropertyGetter<UnityEngine.Vector3>)GetValue_3971334896386457419,
                    (RavenPropertySetter<UnityEngine.Vector3>)SetValue_3971334896386457419,
                }
            },
            {
                17890732708694817339ul,
                new Delegate[]
                {
                    (RavenPropertyGetter<UnityEngine.Vector3>)GetValue_17890732708694817339,
                    (RavenPropertySetter<UnityEngine.Vector3>)SetValue_17890732708694817339,
                }
            },
            {
                10625774802725675592ul,
                new Delegate[]
                {
                    (RavenPropertyGetter<UnityEngine.Vector2>)GetValue_10625774802725675592,
                    (RavenPropertySetter<UnityEngine.Vector2>)SetValue_10625774802725675592,
                }
            },
        };
        static UnityEngine.Vector2 GetValue_16899892407691550664(UnityEngine.Object c) {
            if (c != null) {
                return (c as UnityEngine.RectTransform).anchoredPosition;
            }
            return default(UnityEngine.Vector2);
        }
        
        static void SetValue_16899892407691550664(UnityEngine.Object c, UnityEngine.Vector2 v) {
            if (c != null) {
                (c as UnityEngine.RectTransform).anchoredPosition = v;
            }
        }
        
        static UnityEngine.Vector3 GetValue_6139277867611767050(UnityEngine.Object c) {
            if (c != null) {
                return (c as UnityEngine.RectTransform).anchoredPosition3D;
            }
            return default(UnityEngine.Vector3);
        }
        
        static void SetValue_6139277867611767050(UnityEngine.Object c, UnityEngine.Vector3 v) {
            if (c != null) {
                (c as UnityEngine.RectTransform).anchoredPosition3D = v;
            }
        }
        
        static UnityEngine.Vector3 GetValue_3971334896386457419(UnityEngine.Object c) {
            if (c != null) {
                return (c as UnityEngine.Transform).position;
            }
            return default(UnityEngine.Vector3);
        }
        
        static void SetValue_3971334896386457419(UnityEngine.Object c, UnityEngine.Vector3 v) {
            if (c != null) {
                (c as UnityEngine.Transform).position = v;
            }
        }
        
        static UnityEngine.Vector3 GetValue_17890732708694817339(UnityEngine.Object c) {
            if (c != null) {
                return (c as UnityEngine.Transform).localPosition;
            }
            return default(UnityEngine.Vector3);
        }
        
        static void SetValue_17890732708694817339(UnityEngine.Object c, UnityEngine.Vector3 v) {
            if (c != null) {
                (c as UnityEngine.Transform).localPosition = v;
            }
        }
        
        static UnityEngine.Vector2 GetValue_10625774802725675592(UnityEngine.Object c) {
            if (c != null) {
                return (c as UnityEngine.RectTransform).sizeDelta;
            }
            return default(UnityEngine.Vector2);
        }
        
        static void SetValue_10625774802725675592(UnityEngine.Object c, UnityEngine.Vector2 v) {
            if (c != null) {
                (c as UnityEngine.RectTransform).sizeDelta = v;
            }
        }
        
        public static bool HasInDatabase(string targetObject, string targetProperty, out ulong outHash) {
            outHash = RavenUtility.s_InvalidHash;
#if UNITY_EDITOR
            var stitchedName = RavenUtility.StitchTypeAndMember(targetObject, targetProperty);
            if (s_NameToTargetHashMap.TryGetValue(stitchedName, out outHash)) {
                return true;
            }
            else {
                outHash = RavenUtility.s_InvalidHash;
            }
#endif
            return false;
        }
        
        public static bool HasPropertySpecialization(string packedTypes, out System.Type outSpecializationType) {
            outSpecializationType = null;
#if UNITY_EDITOR
            string type;
            if (s_TargetClassSpecializationToNameMap.TryGetValue(packedTypes, out type)) {
                outSpecializationType = RavenUtility.GetTypeFromLoadedAssemblies(type);
                return true;
            }
#endif
            return false;
        }
        
        public static void ConfigureRavenAnimationProperty<T>(RavenAnimationDataPropertyBase<T> animationProperty) {
            if (animationProperty == null) {
                return;
            }
            var targetHash = animationProperty.TargetHash;
            animationProperty.SetOnSyncCallback((((RavenPropertyGetter<T>)s_FunctionJumpTable[targetHash][0])));
            animationProperty.SetOnExecuteCallback((((RavenPropertySetter<T>)s_FunctionJumpTable[targetHash][1])));
        }
        
        public static void ConfigureRavenTriggerProperty(RavenTriggerPropertyBase0 triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0>(RavenTriggerPropertyBase1<T0> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1>(RavenTriggerPropertyBase2<T0, T1> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2>(RavenTriggerPropertyBase3<T0, T1, T2> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3>(RavenTriggerPropertyBase4<T0, T1, T2, T3> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3, T4>(RavenTriggerPropertyBase5<T0, T1, T2, T3, T4> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3, T4>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3, T4, T5>(RavenTriggerPropertyBase6<T0, T1, T2, T3, T4, T5> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3, T4, T5>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3, T4, T5, T6>(RavenTriggerPropertyBase7<T0, T1, T2, T3, T4, T5, T6> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3, T4, T5, T6>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3, T4, T5, T6, T7>(RavenTriggerPropertyBase8<T0, T1, T2, T3, T4, T5, T6, T7> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3, T4, T5, T6, T7>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3, T4, T5, T6, T7, T8>(RavenTriggerPropertyBase9<T0, T1, T2, T3, T4, T5, T6, T7, T8> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3, T4, T5, T6, T7, T8>)s_FunctionJumpTable[targetHash][0])));
        }
        
        public static void ConfigureRavenTriggerProperty<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(RavenTriggerPropertyBase10<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9> triggerProperty) {
            if (triggerProperty == null) {
                return;
            }
            var targetHash = triggerProperty.TargetHash;
            triggerProperty.SetOnExecuteCallback((((RavenFunctionCall<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>)s_FunctionJumpTable[targetHash][0])));
        }
    }
}
#endif	 // RAVEN_COMPILED
