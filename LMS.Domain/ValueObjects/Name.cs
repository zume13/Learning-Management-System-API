using LeaveManagement.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string value { get; private set; }

        public Name(string value)
        {
            this.value = value;
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return value;
        }

        public static ResultT<Name> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return ValueObjectErrors.Name.NameIsRequired;

            if (value.Length > 25)
                return ValueObjectErrors.Name.NameIsTooLong;

            return new Name(value);
        }
    }
}
