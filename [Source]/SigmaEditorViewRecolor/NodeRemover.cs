using UnityEngine;
using System.Linq;


namespace SigmaEditorViewRecolorPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class ConfigNodeRemover : MonoBehaviour
    {
        void Start()
        {
            foreach (UrlDir.UrlConfig node in GameDatabase.Instance.GetConfigs("SigmaEditorViewRecolor").Where(c => c.url != "Sigma/EditorViewRecolor/Settings/SigmaEditorViewRecolor"))
            {
                node.parent.configs.Remove(node);
            }
        }
    }
}
