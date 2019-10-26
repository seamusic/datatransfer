using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daan.DataTransfer.DataCommon
{
    public class SplitList<T>
    {
        private int itemLength = 10000;
        private int positon = 0;
        private List<T> _listData;

        public void InitialData(List<T> listData)
        {
            _listData = listData;
        }

        public SplitList(List<T> listData)
        {
            _listData = listData;
        }


        public SplitList()
        {

        }
        /// <summary>
        /// 读取一段数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Read()
        {
            List<T> temp = new List<T>();

            int begin = positon;
            int endPosition = positon + itemLength;

            if (_listData.Count - positon < itemLength)
            {
                endPosition = _listData.Count;
            }

            for (int i = begin; i < endPosition; i++)
            {
                temp.Add(_listData[i]);
                positon++;
            }

            return temp;
        }





        /// <summary>
        /// 独到结尾
        /// </summary>
        /// <returns></returns>
        public bool IsEnd()
        {
            bool isEnd = false;
            if (positon == _listData.Count)
            {
                isEnd = true;
            }

            return isEnd;
        }


    }
}
