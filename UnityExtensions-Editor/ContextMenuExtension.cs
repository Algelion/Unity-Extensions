using System.IO;
using UnityEngine;

namespace UnityEditor
{
    internal static class ContextMenuExtension
    {
        private const string ScriptsAssetMenuPath = "Assets/Create Script/";
        private const string AssetMenuPath = "Assets/";

        private static string _templatePath;
        private static string _templateExtension;
        private static string _assetExtension;

        static ContextMenuExtension()
        {
            if (Directory.Exists(ContextMenuExtension._templatePath) == false)
            {
                ScriptTemplatesGenerator.GenerateScriptTemplates();
            }

            ContextMenuExtension._templatePath = Application.dataPath + "/Editor/Script Templates/";
            ContextMenuExtension._templateExtension = ".txt";
            ContextMenuExtension._assetExtension = ".cs";
        }

        private static void CreateScript(string name)
        {
            string templateFilePath = ContextMenuExtension._templatePath + name
                + ContextMenuExtension._templateExtension;
            string defaultFileName = "New" + name + ContextMenuExtension._assetExtension;

            if(Directory.Exists(ContextMenuExtension._templatePath) == false)
            {
                ScriptTemplatesGenerator.GenerateScriptTemplates();
            }

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templateFilePath, defaultFileName);
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "Folder", false, 1)]
        private static void CreateFolder()
        {
            ProjectWindowUtil.CreateFolder();
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Interface", false, 12)]
        private static void CreateInterface()
        {
            ContextMenuExtension.CreateScript("Interface");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Enum", false, 12)]
        private static void CreateEnum()
        {
            ContextMenuExtension.CreateScript("Enum");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Class/C# Default Class", false)]
        private static void CreateClass()
        {
            ContextMenuExtension.CreateScript("DefaultClass");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Class/C# Static Class", false)]
        private static void CreateStaticClass()
        {
            ContextMenuExtension.CreateScript("StaticClass");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Class/C# Abstract Class", false)]
        private static void CreateAbstractClass()
        {
            ContextMenuExtension.CreateScript("AbstractClass");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Struct/C# Serializable Class", false)]
        private static void CreateSerializableClass()
        {
            ContextMenuExtension.CreateScript("SerializableClass");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Class/C# Serializable Abstract Class", false)]
        private static void CreateSerializableAbstractClass()
        {
            ContextMenuExtension.CreateScript("SerializableAbstractClass");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Struct/C# Default Struct", false)]
        private static void CreateStruct()
        {
            ContextMenuExtension.CreateScript("Struct");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Struct/C# Serializable Struct", false)]
        private static void CreateSerializableStruct()
        {
            ContextMenuExtension.CreateScript("SerializableStruct");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Unity/C# Editor Script", false)]
        private static void CreateEditorScript()
        {
            ContextMenuExtension.CreateScript("EditorScript");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Unity/C# ScriptableObject", false)]
        private static void CreateScriptableObject()
        {
            ContextMenuExtension.CreateScript("ScriptableObject");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Unity/C# MonoBehaviour Script", false)]
        private static void CreateMonoBehaviourScript()
        {
            ContextMenuExtension.CreateScript("MonoBehaviourScript");
        }

        [MenuItem(ContextMenuExtension.ScriptsAssetMenuPath + "C# Unity/C# Abstract MonoBehaviour Script", false)]
        private static void CreateAbstractMonoBehaviourScript()
        {
            ContextMenuExtension.CreateScript("AbstractMonoBehaviourScript");
        }

        [MenuItem(ContextMenuExtension.AssetMenuPath + "Reveal Log Folder in Finder", false)]
        private static void RevealLogFolderinFinder()
        {
            EditorUtility.RevealInFinder(LogUtilities.LogDirectory);
        }
    }
}
