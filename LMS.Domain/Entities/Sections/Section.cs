using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Sections
{
    public class Section : AggregateRoot
    {
        private Section(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
        public string Name { get; private set; }

        public ResultT<Section> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return SectionErrors.Section.InvalidName;

            return new Section(Guid.NewGuid(), name);
        }
    }   
}
