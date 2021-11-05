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
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public abstract class #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "AbstractMonoBehaviourScript",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public abstract class #SCRIPTNAME# : MonoBehaviour\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "DefaultClass",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public class #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "EditorScript",
                "#if UNITY_EDITOR\n" +
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEditor;\n" +
                "using UnityEditor.UIElements;\n" +
                "using UnityEngine;\n" +
                "using UnityEngine.UIElements;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public class #SCRIPTNAME# : Editor\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#\n" +
                "#endif"
            },
            {
                "Enum",
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public enum #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "Interface",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public interface #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "MonoBehaviourScript",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public class #SCRIPTNAME# : MonoBehaviour\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "ScriptableObject",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public class #SCRIPTNAME# : ScriptableObject\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "SerializableAbstractClass",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "[Serializable]\n" +
                "public abstract class #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "SerializableClass",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "[Serializable]\n" +
                "public class #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "SerializableStruct",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "[Serializable]\n" +
                "public struct #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "StaticClass",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public static class #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
            {
                "Struct",
                "using System;\n" +
                "using System.Collections;\n" +
                "using System.Collections.Generic;\n" +
                "using UnityEngine;\n\n" +
                "    #ROOTNAMESPACEBEGIN#\n" +
                "public struct #SCRIPTNAME#\n" +
                "{\n" +
                "    #NOTRIM#\n" +
                "}\n" +
                "#ROOTNAMESPACEEND#"
            },
        };

        public static void GenerateScriptTemplates()
        {
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
