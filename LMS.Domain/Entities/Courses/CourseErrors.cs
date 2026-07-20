
using SharedKernel.Shared;
using System.Reflection.Metadata.Ecma335;

namespace LMS.Domain.Entities.Courses
{
    internal class CourseErrors
    {
        public class Course
        {
            public static Error Empty(string errorName) =>
                Error.Failure($"{errorName}.Empty", $"{errorName} cannot be empty.");

            public static Error InvalidUnits() =>
                Error.Failure(
                    "Course.InvalidUnits", 
                    "Course units must be greater than zero.");

            public static Error InvalidMaxStudents() =>
                Error.Failure(
                    "Course.InvalidMaxStudents", 
                    "Maximum students must be greater than zero.");

            public static Error InvalidInstructor() =>
                Error.Failure(
                    "Course.InvalidInstructor", 
                    "Instructor ID is invalid.");

            public static Error DuplicateCourseCode(string courseCode) =>
                Error.Failure(
                    "Course.DuplicateCourseCode",
                    $"Course code '{courseCode}' already exists.");

            public static Error CourseAlreadyArchived() =>
                Error.Failure(
                    "Course.AlreadyArchived",
                    "The course has already been archived.");

            public static Error MaximumEnrollmentReached() =>
                Error.Failure(
                    "Course.MaximumEnrollmentReached",
                    "The course has reached its maximum enrollment.");

            public static Error InstructorAlreadyAssigned(Guid instructorId) =>
                Error.Failure(
                    "Course.InstructorAlreadyAssigned",
                    $"Instructor '{instructorId}' is already assigned to this course.");
        }
    }
}
