using System.Linq;
using UnityEngine;


namespace SigmaEditorViewRecolorPlugin
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
    class KSCFixer : MonoBehaviour
    {
        void Start()
        {
            // If Kopernicus is installed let it handle ksc recolor
            if (AssemblyLoader.loadedAssemblies.FirstOrDefault(a => a.name == "Kopernicus") != null) return;


            // Read Settings
            ConfigNode node = GameDatabase.Instance.GetConfigNodes("SigmaEditorViewRecolor").FirstOrDefault();
            string groundTex = node?.GetValue("KSCGroundTex");
            string[] groundColor = node?.GetValue("KSCGroundColor")?.Split(',');


            // Load the texture we want to use for the ksc ground
            Texture kscGroundTex = null;
            if (!string.IsNullOrEmpty(groundTex))
                kscGroundTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == groundTex);

            Color? color = Get.Color(groundColor);

            foreach (Material material in Resources.FindObjectsOfTypeAll<Material>().Where(m => m.name == "ksc_exterior_terrain_grass_02"))
            {
                if (kscGroundTex != null)
                    material.mainTexture = kscGroundTex;

                if (color != null)
                    material.color = (Color)color;
            }
        }
    }
}
