using System;
using WorkingWithVisualStudio.Models;
using Xunit.Abstractions;

namespace WorkingWithVisualStudio.Tests
{
    public class CouponValidateTestCase : Coupon, IXunitSerializable
    {
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue(nameof(Id), Id.ToString());
            info.AddValue(nameof(IsValid), IsValid.ToString());
        }

        public void Deserialize(IXunitSerializationInfo info)
        {
            Id = Guid.Parse(info.GetValue<string>("Id"));
            IsValid = bool.Parse(info.GetValue<string>("IsValid"));
        }
    }
}