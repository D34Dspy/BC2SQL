using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace bc2sql
{
    public class StringUtil
    {
        public unsafe static string Join(string separator, IEnumerable<string> value)
        {
            if (separator == null)
            {
                separator = string.Empty;
            }

            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            int count = 0;
            var num = value.Sum(val => {
                count++;
                return val.Length;
                });

            num += (count - 1) * separator.Length;
            if (num < 0 || num + 1 < 0)
                throw new OutOfMemoryException();

            if (num == 0)
                return string.Empty;

            var enumerator = value.GetEnumerator();

            string text = new string('\0', num);
            fixed (char* buffer = text)
            {
                UnSafeCharBuffer unSafeCharBuffer = new UnSafeCharBuffer(buffer, num);
                enumerator.MoveNext();
                unSafeCharBuffer.AppendString(enumerator.Current);
                for (int j = 1; j < count; j++)
                {
                    enumerator.MoveNext();
                    unSafeCharBuffer.AppendString(separator);
                    unSafeCharBuffer.AppendString(enumerator.Current);
                }
            }

            return text;
        }
    }
}
