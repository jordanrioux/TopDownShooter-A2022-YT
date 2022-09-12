using System.IO;
using UnityEditor;
using UnityEngine;

namespace TopDownShooter.Editor
{
    public static class ToolsMenu
    {
        #region Default Directories
        
        private static readonly string[] DefaultDirectories = new[]
        {
            "_Scripts",
                "_Scripts/Managers",
                "_Scripts/Shaders",
                "_Scripts/ScriptableObjects",
                "_Scripts/Systems",
                "_Scripts/Systems/Input",
                "_Scripts/Units",
                "_Scripts/Units/Enemies",
                "_Scripts/Units/Players",
                "_Scripts/Utilities",
            "Animations",
            "Art",
                "Art/Fonts",
                "Art/Materials",
                "Art/Sprites",
                "Art/Textures",
            "Audio",
                "Audio/Music",
                "Audio/SFX",
            "Prefabs",
            "Resources",
            "Scenes",
            "Tilemaps"
        };
        
        #endregion
        
        [MenuItem("Tools/Setup/Create Default Directories")]
        public static void CreateDefaultDirectories()
        {
            CreateDirectories("_Project", DefaultDirectories);
            AssetDatabase.Refresh();
        }
        
        private static void CreateDirectories(string root, params string[] directories)
        {
            var fullPath = Path.Combine(Application.dataPath, root);
            foreach (var directory in directories)
            {
                Directory.CreateDirectory(Path.Combine(fullPath, directory));
            }
        }
    }
}

