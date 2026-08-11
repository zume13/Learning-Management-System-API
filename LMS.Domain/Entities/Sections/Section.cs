using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Sections
{
    public class Section : AggregateRoot
    {
        private Section(
            Guid id, 
            string name, 
            string academicYear)
            : base(id)
        {
            Name = name;
            AcademicYear = academicYear;
        }
        public string Name { get; private set; }
        public string AcademicYear { get; private set; }

        public ResultT<Section> Create(string name, string academicYear)
        {
            if (string.IsNullOrWhiteSpace(name))
                return SectionErrors.Section.InvalidName;

            if (string.IsNullOrWhiteSpace(academicYear))
                return SectionErrors.Section.InvalidAcademicYear;

            return new Section(Guid.NewGuid(), name, academicYear);
        }
    }   
}
