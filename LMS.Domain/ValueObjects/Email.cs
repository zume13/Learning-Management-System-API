
using LeaveManagement.SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string value)
        {
            this.Value = value;
        }
        public string Value { get; private set; }
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static ResultT<Email> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                return ValueObjectErrors.Email.EmailIsRequired;

            if (!value.Contains("@"))
                return ValueObjectErrors.Email.InvalidEmailFormat;

            return new Email(value);
        }
    }
}
