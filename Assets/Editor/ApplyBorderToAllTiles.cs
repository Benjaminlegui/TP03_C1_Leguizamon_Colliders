using UnityEngine;
using UnityEditor;
using UnityEditor.U2D.Sprites;

public class ApplyBorderToAllTiles
{
    // Vector4 = (Left, Bottom, Right, Top)
    static readonly Vector4 BORDE = new Vector4(18, 18, 18, 18);

    [MenuItem("Tools/Borde 9-slice 18px a todos los sprites")]
    static void Apply()
    {
        var factories = new SpriteDataProviderFactories();
        factories.Init();

        int texturas = 0;

        foreach (var obj in Selection.objects)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            var importer = AssetImporter.GetAtPath(path) as TextureImporter;
            if (importer == null) continue;

            if (importer.spriteImportMode != SpriteImportMode.Multiple)
            {
                Debug.LogWarning($"{path}: Sprite Mode no esta en Multiple.");
                continue;
            }

            var provider = factories.GetSpriteEditorDataProviderFromObject(importer);
            if (provider == null)
            {
                Debug.LogWarning($"{path}: no se pudo obtener el data provider.");
                continue;
            }

            provider.InitSpriteEditorDataProvider();

            var rects = provider.GetSpriteRects();
            if (rects == null || rects.Length == 0)
            {
                Debug.LogWarning($"{path}: no hay sub-sprites. Slicealo primero.");
                continue;
            }

            foreach (var rect in rects)
                rect.border = BORDE;

            provider.SetSpriteRects(rects);
            provider.Apply();

            importer.SaveAndReimport();

            Debug.Log($"Borde 18px aplicado a {rects.Length} sprites en {path}");
            texturas++;
        }

        if (texturas == 0)
            Debug.LogWarning("No seleccionaste ninguna textura en el Project.");
    }
}