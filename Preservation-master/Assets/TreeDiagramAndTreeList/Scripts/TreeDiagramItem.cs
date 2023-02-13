using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TreeDiagramAndTreeList
{
    public class TreeDiagramItem : MonoBehaviour
    {
        public Text nameText;
        public Text statusText;
        public Image background;
        public Button expend;
        public Button collapse;
        public Button check;
        public Button uncheck;
        public GameObject toggleSlot;
        public GameObject front, rear;
        public GameObject front_up, front_down;
        [HideInInspector] public TreeDiagramItem parentItem;
        [HideInInspector] public TreeDiagram linkedTreeDiagram;
        [HideInInspector] public Data data;
        [HideInInspector] public int layer;

        public void OnSelect()
        {
            linkedTreeDiagram.OnSelectItem(this);
        }

        public void OnExpend()
        {
            linkedTreeDiagram.OnExpendItem(this);
        }

        public void OnCollapse()
        {
            linkedTreeDiagram.OnCollapseItem(this);
        }

        public void OnCheck()
        {
            linkedTreeDiagram.OnCheckItem(this);
        }

        public void OnUncheck()
        {
            linkedTreeDiagram.OnUncheckItem(this);
        }
    }
}