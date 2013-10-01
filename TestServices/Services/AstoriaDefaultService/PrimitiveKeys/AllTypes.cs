//   Copyright 2011 Microsoft Corporation
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace Microsoft.Test.OData.Services.PrimitiveKeysService
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Common;

    [DataServiceKey("Id")]
    public class EdmBinary
    {
        public Byte[] Id { get; set; }

        public static IEnumerable<EdmBinary> GetData()
        {
            yield return new EdmBinary { Id = new Byte[] { } };
            yield return new EdmBinary { Id = new Byte[] { 1 } };
            yield return new EdmBinary { Id = new Byte[] { 2, 3, 4 } };
        }
    }

    [DataServiceKey("Id")]
    public class EdmBoolean
    {
        public Boolean Id { get; set; }

        public static IEnumerable<EdmBoolean> GetData()
        {
            yield return new EdmBoolean { Id = true };
            yield return new EdmBoolean { Id = false };
        }
    }

    [DataServiceKey("Id")]
    public class EdmByte
    {
        public Byte Id { get; set; }

        public static IEnumerable<EdmByte> GetData()
        {
            yield return new EdmByte { Id = Byte.MinValue };
            yield return new EdmByte { Id = Byte.MaxValue };
            yield return new EdmByte { Id = 0 };
            yield return new EdmByte { Id = 1 };
        }
    }

    [DataServiceKey("Id")]
    public class EdmDateTime
    {
        private static readonly DateTime CachedNow = DateTime.Now;
        private static readonly DateTime CachedUtcNow = DateTime.UtcNow.AddDays(1);

        public DateTime Id { get; set; }

        public static IEnumerable<EdmDateTime> GetData()
        {
            yield return new EdmDateTime { Id = DateTime.MaxValue };
            yield return new EdmDateTime { Id = DateTime.MinValue };
            yield return new EdmDateTime { Id = CachedNow };
            yield return new EdmDateTime { Id = DateTime.Today };
            yield return new EdmDateTime { Id = CachedUtcNow };
        }
    }

    [DataServiceKey("Id")]
    public class EdmDecimal
    {
        public Decimal Id { get; set; }

        public static IEnumerable<EdmDecimal> GetData()
        {
            yield return new EdmDecimal { Id = Decimal.MinValue };
            yield return new EdmDecimal { Id = Decimal.MaxValue };
            yield return new EdmDecimal { Id = Decimal.MinusOne };
            yield return new EdmDecimal { Id = Decimal.One };
            yield return new EdmDecimal { Id = Decimal.Zero };
        }
    }

    [DataServiceKey("Id")]
    public class EdmDouble
    {
        public Double Id { get; set; }

        public static IEnumerable<EdmDouble> GetData()
        {
            yield return new EdmDouble { Id = Double.Epsilon };
            yield return new EdmDouble { Id = Double.MaxValue };
            yield return new EdmDouble { Id = Double.MinValue };
            yield return new EdmDouble { Id = Double.NaN };
            yield return new EdmDouble { Id = Double.NegativeInfinity };
            yield return new EdmDouble { Id = Double.PositiveInfinity };
            yield return new EdmDouble { Id = 0 };
            yield return new EdmDouble { Id = -1 };
            yield return new EdmDouble { Id = 1 };
        }
    }

    [DataServiceKey("Id")]
    public class EdmSingle
    {
        public Single Id { get; set; }

        public static IEnumerable<EdmSingle> GetData()
        {
            yield return new EdmSingle { Id = Single.Epsilon };
            yield return new EdmSingle { Id = Single.MaxValue };
            yield return new EdmSingle { Id = Single.MinValue };
            yield return new EdmSingle { Id = Single.NaN };
            yield return new EdmSingle { Id = Single.NegativeInfinity };
            yield return new EdmSingle { Id = Single.PositiveInfinity };
            yield return new EdmSingle { Id = 0 };
            yield return new EdmSingle { Id = -1 };
            yield return new EdmSingle { Id = 1 };
        }
    }

    [DataServiceKey("Id")]
    public class EdmGuid
    {
        public Guid Id { get; set; }

        public static IEnumerable<EdmGuid> GetData()
        {
            yield return new EdmGuid { Id = Guid.NewGuid() };
            yield return new EdmGuid { Id = Guid.Empty };
        }
    }

    [DataServiceKey("Id")]
    public class EdmInt16
    {
        public Int16 Id { get; set; }

        public static IEnumerable<EdmInt16> GetData()
        {
            yield return new EdmInt16 { Id = Int16.MinValue };
            yield return new EdmInt16 { Id = Int16.MaxValue };
            yield return new EdmInt16 { Id = 0 };
            yield return new EdmInt16 { Id = -1 };
            yield return new EdmInt16 { Id = 1 };
        }
    }

    [DataServiceKey("Id")]
    public class EdmInt32
    {
        public Int32 Id { get; set; }

        public static IEnumerable<EdmInt32> GetData()
        {
            yield return new EdmInt32 { Id = Int32.MinValue };
            yield return new EdmInt32 { Id = Int32.MaxValue };
            yield return new EdmInt32 { Id = 0 };
            yield return new EdmInt32 { Id = -1 };
            yield return new EdmInt32 { Id = 1 };
        }
    }

    [DataServiceKey("Id")]
    public class EdmInt64
    {
        public Int64 Id { get; set; }

        public static IEnumerable<EdmInt64> GetData()
        {
            yield return new EdmInt64 { Id = Int64.MinValue };
            yield return new EdmInt64 { Id = Int64.MaxValue };
            yield return new EdmInt64 { Id = 0 };
            yield return new EdmInt64 { Id = -1 };
            yield return new EdmInt64 { Id = 1 };
        }
    }

    [DataServiceKey("Id")]
    public class EdmString
    {
        public String Id { get; set; }

        public static IEnumerable<EdmString> GetData()
        {
            // Do not include "/" in keys (see bugs 1035242, 1035548, 1036591, 1148207)
            // yield return new EdmString { Id = "/" };

            // Do not include empty string or strings ending with whitespace in (see bug 1144443)
            // yield return new EdmString { Id = " " };

            // Bug 1445023: Inconsistent reading and writing of key values
            // yield return new EdmString { Id = "?" };
            // yield return new EdmString { Id = "#" };

            yield return new EdmString { Id = "!" };
            yield return new EdmString { Id = "!!" };
            yield return new EdmString { Id = "!!!" };
            yield return new EdmString { Id = "*" };
            yield return new EdmString { Id = "**" };
            yield return new EdmString { Id = "***" };
            yield return new EdmString { Id = "(" };
            yield return new EdmString { Id = "((" };
            yield return new EdmString { Id = "(((" };
            yield return new EdmString { Id = ")" };
            yield return new EdmString { Id = "))" };
            yield return new EdmString { Id = ")))" };
            yield return new EdmString { Id = ";" };
            yield return new EdmString { Id = ";;" };
            yield return new EdmString { Id = ";;;" };
            yield return new EdmString { Id = ":" };
            yield return new EdmString { Id = "::" };
            yield return new EdmString { Id = ":::" };
            yield return new EdmString { Id = "@" };
            yield return new EdmString { Id = "@@" };
            yield return new EdmString { Id = "@@@" };
            yield return new EdmString { Id = "&" };
            yield return new EdmString { Id = "&&" };
            yield return new EdmString { Id = "&&&" };
            yield return new EdmString { Id = "=" };
            yield return new EdmString { Id = "==" };
            yield return new EdmString { Id = "===" };
            yield return new EdmString { Id = "+" };
            yield return new EdmString { Id = "++" };
            yield return new EdmString { Id = "+++" };
            yield return new EdmString { Id = "$" };
            yield return new EdmString { Id = "$$" };
            yield return new EdmString { Id = "$$$" };
            yield return new EdmString { Id = "," };
            yield return new EdmString { Id = ",," };
            yield return new EdmString { Id = ",,," };
            yield return new EdmString { Id = "[" };
            yield return new EdmString { Id = "[[" };
            yield return new EdmString { Id = "[[[" };
            yield return new EdmString { Id = "]" };
            yield return new EdmString { Id = "]]" };
            yield return new EdmString { Id = "]]]" };
        }
    }

    [DataServiceKey("Id")]
    public class EdmTime
    {
        public TimeSpan Id { get; set; }

        public static IEnumerable<EdmTime> GetData()
        {
            yield return new EdmTime { Id = TimeSpan.MinValue };
            yield return new EdmTime { Id = TimeSpan.MaxValue };
            yield return new EdmTime { Id = TimeSpan.Zero };
        }
    }

    [DataServiceKey("Id")]
    public class EdmDateTimeOffset
    {
        private static readonly DateTimeOffset CachedNow = DateTimeOffset.Now;
        private static readonly DateTimeOffset CachedUtcNow = DateTimeOffset.UtcNow.AddDays(1);

        public DateTimeOffset Id { get; set; }

        public static IEnumerable<EdmDateTimeOffset> GetData()
        {
            yield return new EdmDateTimeOffset { Id = DateTimeOffset.MinValue };
            yield return new EdmDateTimeOffset { Id = DateTimeOffset.MaxValue };
            yield return new EdmDateTimeOffset { Id = CachedNow };
            yield return new EdmDateTimeOffset { Id = CachedUtcNow };
        }
    }
}
