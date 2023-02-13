using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TreeDiagramAndTreeList
{
    public class TreeDiagram : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("Reference")]
        [SerializeField] GameObject itemPrefab;
        [SerializeField] GameObject dummyItemPrefab;
        [SerializeField] GameObject layerPrefab;
        [SerializeField] RectTransform layerContainer;

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

        TreeDiagramItem currentItem = null;
        List<TreeDiagramLayer> layerList = new List<TreeDiagramLayer>();
        Dictionary<string, List<Data>> seriesDict = new Dictionary<string, List<Data>>();
        bool init = false;
        bool isPointerOver = false;
        float itemHeight = 0.0f;
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
            if (isPointerOver)
            {
                float zoom = 1.0f + option.zoomRate * Input.GetAxis("Mouse ScrollWheel");
                if (zoom != 1.0f)
                {
                    Vector3 vec = Input.mousePosition - layerContainer.transform.position;
                    layerContainer.position += vec - vec * zoom;
                    layerContainer.localScale *= zoom;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0)) DeselectItem();
            }
        }

        public void Init()
        {
            if (init) return;

            itemHeight = itemPrefab.GetComponent<RectTransform>().sizeDelta.y;
            itemNormalColor = itemPrefab.GetComponent<TreeDiagramItem>().background.color;

            init = true;
        }

        public void Clear()
        {
            foreach (var v in layerList)
            {
                v.Clear();
                Destroy(v.gameObject);
            }
            layerList.Clear();
            seriesDict.Clear();
            layerContainer.sizeDelta = Vector2.zero;
        }

        public void Refresh()
        {
            if (!init || data == null) return;

            Clear();
            seriesDict = data.GetSeriesDictionary();

            if (!seriesDict.ContainsKey("Main"))
            {
                Debug.LogError("Entry not found. There should be one series with id:\"Main\"");
                return;
            }
            UpdateNode("Main", 0, null);
        }

        void UpdateNode(string nodeName, int layer, TreeDiagramItem parent)
        {
            //add a new layer
            if (layerList.Count < layer + 1)
            {
                TreeDiagramLayer layerItem = Instantiate(layerPrefab, layerContainer).GetComponent<TreeDiagramLayer>();
                layerItem.GetComponent<RectTransform>().sizeDelta = new Vector2(option.layerWidth, 0.0f);
                layerItem.linkedTreeDiagram = this;
                layerList.Add(layerItem);
            }

            //add dummy items first
            if (layer > 0)
            {
                for (int i = layerList[layer - 1].itemList.Count - 2; i >= 0; --i)
                {
                    TreeDiagramItem item = layerList[layer - 1].itemList[i];
                    if (item.rear != null && item.rear.activeSelf) break;
                    else
                    {
                        TreeDiagramItem dummyItem = Instantiate(dummyItemPrefab, layerList[layer].transform).GetComponent<TreeDiagramItem>();
                        dummyItem.GetComponent<RectTransform>().sizeDelta = new Vector2(0.0f, itemHeight);
                        layerList[layer].itemList.Add(dummyItem);
                    }
                }
            }

            //add new nodes
            List<Data> seriesData = seriesDict[nodeName];
            for (int i = 0; i < seriesData.Count; ++i)
            {
                TreeDiagramItem item = Instantiate(itemPrefab, layerList[layer].transform).GetComponent<TreeDiagramItem>();
                item.data = seriesData[i];
                item.layer = layer;
                //item.front.SetActive(layer != 0);
                item.front_up.SetActive(i != 0);
                item.front_down.SetActive(i != seriesData.Count - 1);
                item.nameText.text = item.data.name;
                item.statusText.gameObject.SetActive(option.showStatus);
                item.statusText.text = item.data.status;
                item.statusText.color = option.statusColor[item.data.statusColorIndex % option.statusColor.Length];
                item.toggleSlot.gameObject.SetActive(option.showCheckbox);
                item.check.gameObject.SetActive(item.data.check);
                item.uncheck.gameObject.SetActive(!item.data.check);
                item.linkedTreeDiagram = this;
                //item.GetComponent<RectTransform>().sizeDelta = new Vector2(0, itemHeight);
                item.parentItem = parent;
                layerList[layer].itemList.Add(item);

                //recursively update children
                if (seriesDict.ContainsKey(item.data.id))
                {
                    item.expend.gameObject.SetActive(!item.data.expend);
                    item.collapse.gameObject.SetActive(item.data.expend);
                    item.rear.SetActive(item.data.expend);
                    if (item.data.expend)
                    {
                        //recursively update parent height
                        float height = itemHeight * seriesDict[item.data.id].Count;
                        item.GetComponent<RectTransform>().sizeDelta = new Vector2(0, height);
                        UpdateParentHeight(item.parentItem, height - itemHeight);
                        UpdateNode(item.data.id, layer + 1, item);
                    }
                }
                else
                {
                    item.rear.SetActive(false);
                    item.expend.gameObject.SetActive(false);
                    item.collapse.gameObject.SetActive(false);
                }
            }

            //update container size
            float tempHeight = 0.0f;
            for (int i = 0; i < layerList[0].itemList.Count; ++i)
                tempHeight += layerList[0].itemList[i].GetComponent<RectTransform>().rect.height;
            layerContainer.sizeDelta = new Vector2(option.layerWidth * layerList.Count + 40.0f, tempHeight + 40.0f);
        }

        void UpdateParentHeight(TreeDiagramItem item, float addHeight)
        {
            if (item == null) return;
            item.GetComponent<RectTransform>().sizeDelta += new Vector2(0, addHeight);
            UpdateParentHeight(item.parentItem, addHeight);
        }

        public void OnSelectItem(TreeDiagramItem item)
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

        public void OnExpendItem(TreeDiagramItem item)
        {
            item.data.expend = true;
            Refresh();
        }

        public void OnCollapseItem(TreeDiagramItem item)
        {
            item.data.expend = false;
            Refresh();
        }

        public void OnCheckItem(TreeDiagramItem item)
        {
            item.data.check = true;
            ToggleChildren(item.data.id, item.data.check);
            Refresh();
        }

        public void OnUncheckItem(TreeDiagramItem item)
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