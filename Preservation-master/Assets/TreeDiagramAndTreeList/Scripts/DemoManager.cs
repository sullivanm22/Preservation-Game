using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeDiagramAndTreeList
{
    public class DemoManager : MonoBehaviour
    {
        [SerializeField] TreeDiagram treeDiagram;
        [SerializeField] TreeList treeList;
        [SerializeField] int minDepth, maxDepth;
        [SerializeField] int minNodes, maxNodes;
        [SerializeField] Transform demoObjectsContainer;

        //=======================================================
        //random data generation demo
        //=======================================================
        static int idCounter = 1;
        static List<Series> m_series = new List<Series>();

        public void Refresh()
        {
            m_series.Clear();
            Series s = GenerateRandomSeries("Main", maxNodes);
            m_series.Add(s);
            GenerateRandomData(s, 0);

            treeDiagram.data.series = m_series;
            treeDiagram.Refresh();
            treeList.data.series = m_series;
            treeList.Refresh();
        }

        void GenerateRandomData(Series series, int depth)
        {
            foreach (var data in series.dataList)
            {
                int n = Random.Range(minNodes, maxNodes + 1);
                if (n != 0)
                {
                    Series s = GenerateRandomSeries(data.id, n);
                    m_series.Add(s);
                    if (depth < Random.Range(minDepth, maxDepth + 1))
                        GenerateRandomData(s, depth + 1);
                }
            }
        }

        Series GenerateRandomSeries(string id, int n)
        {
            Series series = new Series();

            series.id = id;
            for (int i = 0; i < n; ++i)
            {
                Data d = new Data();
                d.id = idCounter.ToString("0000");
                idCounter++;
                d.name = "Node" + d.id;
                if (Random.Range(0, 2) < 1)
                { d.status = "Good"; d.statusColorIndex = 0; }
                else
                { d.status = "Bad"; d.statusColorIndex = 1; }
                if (Random.Range(0, 2) < 1)
                    d.expend = true;
                else
                    d.expend = false;
                d.check = false;
                series.dataList.Add(d);
            }

            return series;
        }


        //=======================================================
        //item select event demo
        //=======================================================
        static Dictionary<string, GameObject> demoObjects = new Dictionary<string, GameObject>();

        private void Awake()
        {
            if (demoObjectsContainer != null)
            {
                foreach (var v in demoObjectsContainer.GetComponentsInChildren<DemoObject>())
                    demoObjects.Add(v.id, v.gameObject);
            }
        }

        public void SelectObject(string key)
        {
            DeselectObject();
            GameObject obj = demoObjects[key];
            MeshRenderer r = obj.GetComponent<MeshRenderer>();
            r.material.SetColor("_Color", Color.blue);
        }

        public void MultipleSelection(TreeList list)
        {
            DeselectObject();
            foreach (var key in list.GetSelectedItems())
            {
                MeshRenderer r = demoObjects[key].GetComponent<MeshRenderer>();
                r.material.SetColor("_Color", Color.blue);
            }
        }

        public void DeselectObject()
        {
            foreach (var obj in demoObjects.Values)
            {
                MeshRenderer r = obj.GetComponent<MeshRenderer>();
                r.material.SetColor("_Color", Color.white);
            }
        }
    }
}