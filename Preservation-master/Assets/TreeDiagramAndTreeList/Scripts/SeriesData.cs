using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TreeDiagramAndTreeList
{
    [System.Serializable]
    public class Data
    {
        public string id;
        public string name;
        public string status;
        public int statusColorIndex;
        public string linkedItemID;
        public bool check = false;
        public bool expend = false;
    }

    [System.Serializable]
    public class Series
    {
        public string id;
        public List<Data> dataList = new List<Data>();
    }

    public class SeriesData : MonoBehaviour
    {
        public List<Series> series = new List<Series>();

        public Dictionary<string, List<Data>> GetSeriesDictionary()
        {
            Dictionary<string, List<Data>> dict = new Dictionary<string, List<Data>>();
            foreach (var v in series)
            {
                dict.Add(v.id, v.dataList);
            }
            return dict;
        }
    }
}
