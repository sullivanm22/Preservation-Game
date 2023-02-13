using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeDiagramAndTreeList
{
    public class TreeDiagramLayer : MonoBehaviour
    {
        [HideInInspector] public List<TreeDiagramItem> itemList = new List<TreeDiagramItem>();
        [HideInInspector] public TreeDiagram linkedTreeDiagram;

        public void UpdateHeight()
        {
            Vector2 size = GetComponent<RectTransform>().sizeDelta;
            size.y = 0.0f;
            foreach (var item in itemList)
            {
                size.y += item.GetComponent<RectTransform>().sizeDelta.y;
            }
            GetComponent<RectTransform>().sizeDelta = size;
        }

        public void Clear()
        {
            foreach (var v in itemList)
            {
                Destroy(v.gameObject);
            }
            itemList.Clear();
        }

        public void ExpendAll(bool expend)
        {
            foreach (var item in itemList)
            {
                item.data.expend = expend;
            }
            linkedTreeDiagram.Refresh();
        }
    }
}