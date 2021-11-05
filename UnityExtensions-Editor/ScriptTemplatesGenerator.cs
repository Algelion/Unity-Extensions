using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityEditor
{
    internal static class ScriptTemplatesGenerator
    {
        private static readonly string ScriptTemplatePath = Application.dataPath + "/Editor/Script Templates/";

        private static readonly Dictionary<string, string> ScriptTemplates = new Dictionary<string, string>
        {
            {
                "AbstractClass", 
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public abstract class #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#" 
            },
            {
                "AbstractMonoBehaviourScript",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public abstract class #SCRIPTNAME# : MonoBehaviour 
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "DefaultClass",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public class #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "EditorScript",
                @"#if UNITY_EDITOR
                using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEditor;
                using UnityEditor.UIElements;
                using UnityEngine;
                using UnityEngine.UIElements;

                    #ROOTNAMESPACEBEGIN#
                public class #SCRIPTNAME# : Editor
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#
                #endif"
            },
            {
                "Enum",
                @"#ROOTNAMESPACEBEGIN#
                public enum #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "Interface",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public interface #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "MonoBehaviourScript",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public class #SCRIPTNAME# : MonoBehaviour 
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "ScriptableObject",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public class #SCRIPTNAME# : ScriptableObject
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "SerializableAbstractClass",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                [Serializable]
                public abstract class #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "SerializableClass",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                [Serializable]
                public class #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "SerializableStruct",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                [Serializable]
                public struct #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "StaticClass",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public static class #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
            {
                "Struct",
                @"using System;
                using System.Collections;
                using System.Collections.Generic;
                using UnityEngine;

                    #ROOTNAMESPACEBEGIN#
                public struct #SCRIPTNAME#
                {
                    #NOTRIM#
                }
                #ROOTNAMESPACEEND#"
            },
        };

        public static void GenerateScriptTemplates()
        {
            Debug.Log("Generate Script Templates");

            if(Directory.Exists(ScriptTemplatesGenerator.ScriptTemplatePath) == false)
            {
                Directory.CreateDirectory(ScriptTemplatesGenerator.ScriptTemplatePath);
            }

            foreach(KeyValuePair<string, string> scriptTemplate in ScriptTemplatesGenerator.ScriptTemplates)
            {
                File.WriteAllText
                (
                    path: ScriptTemplatesGenerator.ScriptTemplatePath + scriptTemplate.Key + ".txt",
                    contents: scriptTemplate.Value
                );
            }
        }
    }
}
