using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Sofire.Serialization;

namespace Daan.DataTransfer.DataCommon
{
    public class DataProcessFactory : DataProcessBase
    {

        #region 输入输出均为byte[]
        public override byte[] Process(byte[] data)
        {
            var processList = new List<DataProcessBase>();
            var zip = new ZipCompress();
            processList.Add(zip);
            var base64 = new Base64Convert();
            processList.Add(base64);
            data = processList.Aggregate(data, (current, dataProcessBase) => dataProcessBase.Process(current));

            return data;
        }

        public override byte[] DeProcess(byte[] data)
        {
            var processList = new List<DataProcessBase>();

            var base64 = new Base64Convert();
            processList.Add(base64);
            var zip = new ZipCompress();
            processList.Add(zip);

            return processList.Aggregate(data, (current, dataProcessBase) => dataProcessBase.DeProcess(current));
        }
        #endregion

        #region 实体与数据之间处理
        public string ProcessToString<T>(T data)
        {
            var fastBinarySerializer = new FastBinarySerializer();
            var result = fastBinarySerializer.WriteBytes(data);
            if (result.IsSucceed)
            {
                var bytes = result.Value;
                bytes = Process(bytes);
                return StringByteConver.ToString(bytes);
            }
            else
            {
                return null;
            }
        }

        public T ProcessToObject<T>(string data)
        {
            var bytes = StringByteConver.ToByte(data);
            bytes = DeProcess(bytes);
            var fastBinarySerializer = new FastBinarySerializer();
            var result = fastBinarySerializer.ReadBytes<T>(bytes);
            return result.IsSucceed ? result.Value : default(T);
        }
        #endregion

        #region 通用
        public bool CheckDataSegment(DataSegment dataSegment)
        {
            if (dataSegment == null)
            {
                return false;
            }

            return CrcHash.Compute(dataSegment.DataString).ToString(CultureInfo.InvariantCulture) == dataSegment.Crccode;
        }

        public DataParameter BuildDataParameter<T>(int actionId, T data)
        {
            var parameter = new DataParameter { Action = actionId };
            parameter.DataString = ProcessToString(data);
            parameter.CrcCode = CrcHash.Compute(parameter.DataString).ToString(CultureInfo.InvariantCulture);

            return parameter;
        }

        public DataSegment BuildDataSegment(int index, string dataId, int dataLength, int dataCount, string content)
        {
            var beginPos = index * dataLength;
            var legth = index == dataCount - 1 ? content.Length - beginPos : dataLength;
            var data = content.Substring(beginPos, legth);

            var dataSegment = new DataSegment();
            dataSegment.DataId = dataId;
            dataSegment.Crccode = CrcHash.Compute(data).ToString(CultureInfo.InvariantCulture);
            dataSegment.DataString = data;
            dataSegment.Index = index;
            return dataSegment;
        }
        #endregion
    }
}
