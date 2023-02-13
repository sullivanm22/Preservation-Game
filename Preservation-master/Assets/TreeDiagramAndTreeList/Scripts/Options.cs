using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TreeDiagramAndTreeList
{
    public class Options : MonoBehaviour
    {
        [System.Serializable]
        public class ItemEvent : UnityEvent<string> { }

        [Header("Tree Diagram Options")]
        public float layerWidth = 400.0f;
        public float zoomRate = 0.3f;
        [Header("Tree List Options")]
        public float childrenOffset;
        [Header("Common Options")]
        public bool showStatus = true;
        public bool showCheckbox = false;
        public Color itemHighlightColor = new Color32(200, 255, 255, 255);
        public Color[] statusColor = new Color[3]
        {
            new Color32 (124, 181, 236, 255),
            new Color32 (175, 155, 255, 255),
            new Color32 (144, 237, 125, 255)
        };
        public ItemEvent itemSelectEvent;
        public ItemEvent itemDeselectEvent;
    }
}