using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//
/*
 * Add using RectTransformX where used.
 * 
 * Sample:
 * var obj = new GameObject();
 * obj.RT().SetAnchorType(RectTransformEx.AnchorType.TopLeft);
 * obj.RT().SetSize(PhotoImage.width, PhotoImage.height);
 * obj.RT().SetPosition(Vector3.zero);
 */
//
namespace RectTransformX
{
    public static class Cast
    {
        public static RectTransform RT(this GameObject go)
        {
            if (go == null || go.transform == null)
                return null;

            return go.GetComponent<RectTransform>();
        }

        public static RectTransform RT(this Transform t)
        {
            if (t is RectTransform == false)
                return null;

            return t as RectTransform;
        }

        public static RectTransform RT(this Component c)
        {
            return RT(c.transform);
        }

        public static RectTransform RT(this UIBehaviour ui)
        {
            if (ui == null)
                return null;

            return ui.transform as RectTransform;
        }
    }

    public static class RectTransformEx
    {
        //Position
        public static Vector3 position(this RectTransform RT)
        {
            return RT.anchoredPosition3D;   //px?
        }

        public static void SetPosition(this RectTransform RT, Vector3 pos)
        {
            RT.anchoredPosition3D = pos;    //px?
        }

        //Size
        public static float width(this RectTransform RT)
        {
            return RT.sizeDelta.x;
        }
        public static float height(this RectTransform RT)
        {
            return RT.sizeDelta.y;
        }

        public static void SetSize(this RectTransform RT, Vector2 value)
        {
            RT.sizeDelta = value;
        }

        public static void SetSize(this RectTransform RT, float width, float height)
        {
            RT.sizeDelta = new Vector2(width, height);
        }

        public static Vector2 GetSize(this RectTransform RT)
        {
            return RT.sizeDelta;
        }

        //Anchors
        #region Anchors
        public enum AnchorType
        {
            TopCenter,
            LeftCenter,
            RightCenter,
            BottomCenter,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Center,
            Undefined
        }

        public static void SetAnchors(this RectTransform RT, float xMin, float yMin, float xMax, float yMax)
        {
            RT.anchorMin = new Vector2(Mathf.Clamp01(xMin), Mathf.Clamp01(yMin));
            RT.anchorMax = new Vector2(Mathf.Clamp01(xMax), Mathf.Clamp01(yMax));
        }

        public static void SetAnchorType(this RectTransform RT, AnchorType type)
        {
            switch (type)
            {
                case AnchorType.TopCenter:
                    RT.anchorMin = new Vector2(0.5f, 1);
                    RT.anchorMax = new Vector2(0.5f, 1);
                    break;
                case AnchorType.LeftCenter:
                    RT.anchorMin = new Vector2(0, 0.5f);
                    RT.anchorMax = new Vector2(0, 0.5f);
                    break;
                case AnchorType.RightCenter:
                    RT.anchorMin = new Vector2(1, 0.5f);
                    RT.anchorMax = new Vector2(1, 0.5f);
                    break;
                case AnchorType.BottomCenter:
                    RT.anchorMin = new Vector2(0.5f, 0);
                    RT.anchorMax = new Vector2(0.5f, 0);
                    break;
                case AnchorType.TopLeft:
                    RT.anchorMin = new Vector2(0, 1);
                    RT.anchorMax = new Vector2(0, 1);
                    break;
                case AnchorType.TopRight:
                    RT.anchorMin = new Vector2(1, 1);
                    RT.anchorMax = new Vector2(1, 1);
                    break;
                case AnchorType.BottomLeft:
                    RT.anchorMin = new Vector2(0, 0);
                    RT.anchorMax = new Vector2(0, 0);
                    break;
                case AnchorType.BottomRight:
                    RT.anchorMin = new Vector2(1, 0);
                    RT.anchorMax = new Vector2(1, 0);
                    break;
                case AnchorType.Center:
                    RT.anchorMin = new Vector2(0.5f, 0.5f);
                    RT.anchorMax = new Vector2(0.5f, 0.5f);
                    break;
                default:
                    //Center
                    RT.anchorMin = new Vector2(0.5f, 0.5f);
                    RT.anchorMax = new Vector2(0.5f, 0.5f);
                    break;
            }
        }

        public static AnchorType GetAnchorType(this RectTransform RT)
        {
            if (RT.anchorMin == new Vector2(0.5f, 1) && RT.anchorMax == new Vector2(0.5f, 1))
                return AnchorType.TopCenter;
            else if (RT.anchorMin == new Vector2(0, 0.5f) && RT.anchorMax == new Vector2(0, 0.5f))
                return AnchorType.LeftCenter;
            else if (RT.anchorMin == new Vector2(1, 0.5f) && RT.anchorMax == new Vector2(1, 0.5f))
                return AnchorType.RightCenter;
            else if (RT.anchorMin == new Vector2(0.5f, 0) && RT.anchorMax == new Vector2(0.5f, 0))
                return AnchorType.BottomCenter;
            else if (RT.anchorMin == new Vector2(0, 1) && RT.anchorMax == new Vector2(0, 1))
                return AnchorType.TopLeft;
            else if (RT.anchorMin == new Vector2(1, 1) && RT.anchorMax == new Vector2(1, 1))
                return AnchorType.TopRight;
            else if (RT.anchorMin == new Vector2(0, 0) && RT.anchorMax == new Vector2(0, 0))
                return AnchorType.BottomLeft;
            else if (RT.anchorMin == new Vector2(1, 0) && RT.anchorMax == new Vector2(1, 0))
                return AnchorType.BottomRight;
            else if (RT.anchorMin == new Vector2(0.5f, 0.5f) && RT.anchorMax == new Vector2(0.5f, 0.5f))
                return AnchorType.Center;
            else
                return AnchorType.Undefined;
        }
        #endregion

        //Pivot
        #region Pivot
        public enum PivotType
        {
            TopCenter,
            LeftCenter,
            RightCenter,
            BottomCenter,
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Center,
            Undefined
        }

        public static void SetPivot(this RectTransform RT, float x, float y)
        {
            RT.pivot = new Vector2(Mathf.Clamp01(x), Mathf.Clamp01(y));
        }

        public static void SetPivot(this RectTransform RT, Vector2 vec2)
        {
            RT.pivot = vec2;
        }

        public static void SetPivot(this RectTransform RT, PivotType type)
        {
            switch (type)
            {
                case PivotType.TopCenter:
                    RT.pivot = new Vector2(0.5f, 1);
                    break;
                case PivotType.LeftCenter:
                    RT.pivot = new Vector2(0, 0.5f);
                    break;
                case PivotType.RightCenter:
                    RT.pivot = new Vector2(1, 0.5f);
                    break;
                case PivotType.BottomCenter:
                    RT.pivot = new Vector2(0.5f, 0);
                    break;
                case PivotType.TopLeft:
                    RT.pivot = new Vector2(0, 1);
                    break;
                case PivotType.TopRight:
                    RT.pivot = new Vector2(1, 1);
                    break;
                case PivotType.BottomLeft:
                    RT.pivot = new Vector2(0, 0);
                    break;
                case PivotType.BottomRight:
                    RT.pivot = new Vector2(1, 0);
                    break;
                case PivotType.Center:
                    RT.pivot = new Vector2(0.5f, 0.5f);
                    break;
                default:
                    //Center
                    RT.pivot = new Vector2(0.5f, 0.5f);
                    break;
            }
        }

        public static PivotType GetPivotType(this RectTransform RT)
        {
            if (RT.pivot == new Vector2(0.5f, 1))
                return PivotType.TopCenter;
            else if (RT.pivot == new Vector2(0, 0.5f))
                return PivotType.LeftCenter;
            else if (RT.pivot == new Vector2(1, 0.5f))
                return PivotType.RightCenter;
            else if (RT.pivot == new Vector2(0.5f, 0))
                return PivotType.BottomCenter;
            else if (RT.pivot == new Vector2(0, 1))
                return PivotType.TopLeft;
            else if (RT.pivot == new Vector2(1, 1))
                return PivotType.TopRight;
            else if (RT.pivot == new Vector2(0, 0))
                return PivotType.BottomLeft;
            else if (RT.pivot == new Vector2(1, 0))
                return PivotType.BottomRight;
            else if (RT.pivot == new Vector2(0.5f, 0.5f))
                return PivotType.Center;
            else
                return PivotType.Undefined;
        }
        #endregion
    }
}
