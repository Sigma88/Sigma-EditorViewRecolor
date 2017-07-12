using UnityEngine;


namespace SigmaEditorViewRecolorPlugin
{
    internal static class Get
    {
        internal static Color? Color(string[] s)
        {
            Color? color = null;
            if (s?.Length == 3 || s?.Length == 4)
            {
                float r;
                float g;
                float b;
                float a;
                if (float.TryParse(s[0], out r) && float.TryParse(s[1], out g) && float.TryParse(s[2], out b))
                {
                    if (s.Length == 4 && float.TryParse(s[3], out a))
                    {
                        color = new Color(r, g, b, a);
                    }
                    else
                    {
                        color = new Color(r, g, b);
                    }
                }
            }
            return color;
        }
    }
}
