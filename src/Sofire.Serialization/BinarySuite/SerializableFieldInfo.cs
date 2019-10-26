using System;
using System.Collections.Generic;
using System.Text;
using Sofire.Dynamic.Factories;
using System.Reflection;

namespace Sofire.Serialization.BinarySuite
{
    internal class SerializableFieldInfo
    {

        private readonly static DynamicGetFieldFactory GetFieldFactory = DynamicGetFieldFactory.Instance;

        private readonly static DynamicSetFieldFactory SetFieldFactory = DynamicSetFieldFactory.Instance;

        public readonly FieldInfo Field;
        public readonly string Name;
        public readonly int NameHashCode;
        public readonly DynamicGetMemberHandler GetValue;
        public readonly DynamicSetMemberHandler SetValue;

        public SerializableFieldInfo(FieldInfo field, int depth)
        {
            this.Field = field;
            if(depth == 0) this.Name = field.Name;
            else this.Name = depth.ToString() + "#" + field.Name;
            this.GetValue = GetFieldFactory.Create(field);
            this.SetValue = SetFieldFactory.Create(field);
            this.NameHashCode = this.Name.GetHashCode();
        }

    }
}
