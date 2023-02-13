using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TreeDiagramAndTreeList
{
    public class TreeList : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Reference")]
        [SerializeField]
        GameObject itemPrefab;
        [SerializeField]
        RectTransform container;

        private SeriesData m_data = null;
        public SeriesData data
        {
            get
            {
                if (m_data == null) m_data = GetComponent<SeriesData>();
                return m_data;
            }
        }
        private Options m_option = null;
        public Options option
        {
            get
            {
                if (m_option == null) m_option = GetComponent<Options>();
                return m_option;
            }
        }

        TreeListItem currentItem = null;
        List<TreeListItem> itemList = new List<TreeListItem>();
        Dictionary<string, List<Data>> seriesDict = new Dictionary<string, List<Data>>();
        bool init = false;
        bool isPointerOver = false;
        Color itemNormalColor;

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            Refresh();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointerOver = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerOver = false;
        }

        private void Update()
        {
            if (!isPointerOver)
            {
                if (Input.GetMouseButtonDown(0)) DeselectItem();
            }
        }

        public void Init()
        {
            if (init) return;

            itemNormalColor = itemPrefab.GetComponent<TreeListItem>().background.color;

            init = true;
        }

        public void Clear()
        {
            foreach (var v in itemList)
            {
                Destroy(v.gameObject);
            }
            itemList.Clear();
            seriesDict.Clear();
        }

        public void Refresh()
        {
            if (!init || data == null) return;

            Clear();
            seriesDict = data.GetSeriesDictionary();

            if (!seriesDict.ContainsKey("Main"))
            {
                Debug.LogError("Treelist entry not found.");
                return;
            }
            UpdateNode("Main", 0);
        }

        void UpdateNode(string nodeName, int layer)
        {
            List<Data> seriesData = seriesDict[nodeName];
            for (int i = 0; i < seriesData.Count; ++i)
            {
                TreeListItem item = Instantiate(itemPrefab, container).GetComponent<TreeListItem>();
                item.data = seriesData[i];
                item.layer = layer;
                item.offset.sizeDelta = new Vector2(option.childrenOffset * layer, 0);
                item.nameText.text = item.data.name;
                item.statusText.gameObject.SetActive(option.showStatus);
                item.statusText.text = item.data.status;
                item.statusText.color = option.statusColor[item.data.statusColorIndex % option.statusColor.Length];
                item.toggleSlot.gameObject.SetActive(option.showCheckbox);
                item.check.gameObject.SetActive(item.data.check);
                item.uncheck.gameObject.SetActive(!item.data.check);
                item.linkedTreeList = this;
                itemList.Add(item);

                //recursively update children
                if (seriesDict.ContainsKey(item.data.id))
                {
                    item.expend.gameObject.SetActive(!item.data.expend);
                    item.collapse.gameObject.SetActive(item.data.expend);
                    if (item.data.expend)
                    {
                        UpdateNode(item.data.id, layer + 1);
                    }
                }
                else
                {
                    item.expend.gameObject.SetActive(false);
                    item.collapse.gameObject.SetActive(false);
                }
            }
        }

        public void OnSelectItem(TreeListItem item)
        {
            if (currentItem != null)
            {
                option.itemDeselectEvent.Invoke(currentItem.data.linkedItemID);
                currentItem.background.color = itemNormalColor;
            }
            currentItem = item;
            currentItem.background.color = option.itemHighlightColor;
            option.itemSelectEvent.Invoke(item.data.linkedItemID);
        }

        public void OnExpendItem(TreeListItem item)
        {
            item.data.expend = true;
            Refresh();
        }

        public void OnCollapseItem(TreeListItem item)
        {
            item.data.expend = false;
            Refresh();
        }

        public void OnCheckItem(TreeListItem item)
        {
            item.data.check = true;
            ToggleChildren(item.data.id, item.data.check);
            Refresh();
        }

        public void OnUncheckItem(TreeListItem item)
        {
            item.data.check = false;
            ToggleChildren(item.data.id, item.data.check);
            Refresh();
        }

        void ToggleChildren(string key, bool flag)
        {
            if (!seriesDict.ContainsKey(key)) return;
            foreach (var data in seriesDict[key])
            {
                data.check = flag;
                ToggleChildren(data.id, flag);
            }
        }

        public void DeselectItem()
        {
            if (currentItem != null)
            {
                option.itemDeselectEvent.Invoke(currentItem.data.linkedItemID);
                currentItem.background.color = itemNormalColor;
            }
            currentItem = null;
        }

        public List<string> GetSelectedItems()
        {
            List<string> items = new List<string>();

            foreach (var item in seriesDict)
            {
                foreach (var data in item.Value)
                {
                    if (data.check) items.Add(data.linkedItemID);
                }
            }

            return items;
        }
    }
}