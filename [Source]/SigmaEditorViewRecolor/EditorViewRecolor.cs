using System.Linq;
using UnityEngine;


namespace SigmaEditorViewRecolorPlugin
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    class SettingsLoader : MonoBehaviour
    {
        Color? color;

        void OnDestroy()
        {
            // Read Settings
            ConfigNode node = GameDatabase.Instance.GetConfigNodes("SigmaEditorViewRecolor").FirstOrDefault();
            string url = node?.GetValue("EditorSkyBox");
            string groundTex = node?.GetValue("EditorGroundTex");
            string[] groundColor = node?.GetValue("EditorGroundColor")?.Split(',');
            string fogEnabled = node?.GetValue("FogEnabled");
            string[] fogColor = node?.GetValue("FogColor")?.Split(',');


            // Load the textures we want to use for the SkyBox
            if (url == "GalaxyTex")
            {
                TextureFixer.UpTex = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m?.name == "YP")?.mainTexture;
                TextureFixer.DownTex = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m?.name == "YN")?.mainTexture;
                TextureFixer.LeftTex = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m?.name == "XN")?.mainTexture;
                TextureFixer.RightTex = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m?.name == "XP")?.mainTexture;
                TextureFixer.FrontTex = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m?.name == "ZP")?.mainTexture;
                TextureFixer.BackTex = Resources.FindObjectsOfTypeAll<Material>().FirstOrDefault(m => m?.name == "ZN")?.mainTexture;
            }
            else if (!string.IsNullOrEmpty(url))
            {
                TextureFixer.UpTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == url + "Sunny3_up");
                TextureFixer.DownTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == url + "Sunny3_down");
                TextureFixer.LeftTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == url + "Sunny3_left");
                TextureFixer.RightTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == url + "Sunny3_right");
                TextureFixer.FrontTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == url + "Sunny3_front");
                TextureFixer.BackTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == url + "Sunny3_back");
            }


            // Load the texture we want to use for the ground
            if (!string.IsNullOrEmpty(groundTex))
                TextureFixer.groundTex = Resources.FindObjectsOfTypeAll<Texture>().FirstOrDefault(t => t?.name == groundTex);

            color = Get.Color(fogColor);
            if (color != null)
                TextureFixer.fogColor = color;


            // Change Fog Settings
            if (!bool.TryParse(fogEnabled, out TextureFixer.fogEnabled) || TextureFixer.fogEnabled == true)
            {
                TextureFixer.fogEnabled = true;

                Color? color = Get.Color(groundColor);
                if (color != null)
                    TextureFixer.groundColor = color;
            }
        }
    }

    [KSPAddon(KSPAddon.Startup.EditorVAB, false)]
    class TextureFixer : MonoBehaviour
    {
        internal static Texture UpTex;
        internal static Texture DownTex;
        internal static Texture LeftTex;
        internal static Texture RightTex;
        internal static Texture FrontTex;
        internal static Texture BackTex;
        internal static Texture groundTex;
        internal static Color? groundColor;
        internal static bool fogEnabled;
        internal static Color? fogColor;
        static bool skip = false;

        void Awake()
        {
            skip = false;
            DontDestroyOnLoad(this);
        }

        void Start()
        {
            // Find the SkyBox material
            Material mat = RenderSettings.skybox;
            if (mat == null) return;

            // Replace the textures with the ones we want
            if (UpTex != null)
            {
                UpTex.wrapMode = TextureWrapMode.Clamp;
                mat.SetTexture("_UpTex", UpTex);
            }
            if (DownTex != null)
            {
                DownTex.wrapMode = TextureWrapMode.Clamp;
                mat.SetTexture("_DownTex", DownTex);
            }
            if (LeftTex != null)
            {
                LeftTex.wrapMode = TextureWrapMode.Clamp;
                mat.SetTexture("_LeftTex", LeftTex);
            }
            if (RightTex != null)
            {
                RightTex.wrapMode = TextureWrapMode.Clamp;
                mat.SetTexture("_RightTex", RightTex);
            }
            if (FrontTex != null)
            {
                FrontTex.wrapMode = TextureWrapMode.Clamp;
                mat.SetTexture("_FrontTex", FrontTex);
            }
            if (BackTex != null)
            {
                BackTex.wrapMode = TextureWrapMode.Clamp;
                mat.SetTexture("_BackTex", BackTex);
            }

            // Fix the Fog
            if (fogEnabled == false)
                RenderSettings.fog = false;
            else if (fogColor != null)
                RenderSettings.fogColor = (Color)fogColor;
        }

        void Update()
        {
            // Fix the ground outside
            if (!skip)
            {
                GameObject ground = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(o => o.name == "ksc_terrain");

                if (ground != null)
                {
                    skip = true;
                    Material material = ground.GetComponent<Renderer>()?.material;
                    if (material != null)
                    {
                        if (groundTex != null)
                            material.mainTexture = groundTex;
                        if (groundColor != null)
                            material.SetColor("_Color", (Color)groundColor);
                    }
                }
            }
        }
    }
}
