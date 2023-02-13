using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TreeDiagramAndTreeList
{
    public class TreeListItem : MonoBehaviour
    {

        public Text nameText;
        public Text statusText;
        public Image background;
        public Button expend;
        public Button collapse;
        public Button check;
        public Button uncheck;
        public GameObject toggleSlot;
        public RectTransform offset;
        [HideInInspector] public TreeList linkedTreeList;
        [HideInInspector] public Data data;
        [HideInInspector] public int layer;

        public void OnSelect()
        {
            linkedTreeList.OnSelectItem(this);
        }

        public void OnExpend()
        {
            linkedTreeList.OnExpendItem(this);
        }

        public void OnCollapse()
        {
            linkedTreeList.OnCollapseItem(this);
        }

        public void OnCheck()
        {
            linkedTreeList.OnCheckItem(this);
        }

        public void OnUncheck()
        {
            linkedTreeList.OnUncheckItem(this);
        }
    }
}