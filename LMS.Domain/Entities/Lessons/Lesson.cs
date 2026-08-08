using SharedKernel.Primitives;
using SharedKernel.Shared;

namespace LMS.Domain.Entities.Lessons;

public class Lesson : AggregateRoot
{
    private readonly List<Guid> _fileIds = [];
    private readonly List<Guid> _videoIds = [];

    private Lesson(
        Guid id,
        Guid courseId,
        string title,
        string description,
        LessonType type,
        DateTime? releaseDate,
        bool allowDiscussion)
        : base(id)
    {
        CourseId = courseId;
        Title = title;
        Description = description;
        Type = type;
        ReleaseDate = releaseDate;
        AllowDiscussion = allowDiscussion;
    }

    public Guid CourseId { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public LessonType Type { get; private set; }

    public DateTime? ReleaseDate { get; private set; }

    public bool Published { get; private set; }

    public bool AllowDiscussion { get; private set; }

    public IReadOnlyCollection<Guid> Files => _fileIds;

    public IReadOnlyCollection<Guid> Videos => _videoIds;

    public static ResultT<Lesson> Create(
        Guid courseId,
        string title,
        string description,
        LessonType type,
        DateTime? releaseDate,
        bool allowDiscussion = true)
    {
        if (string.IsNullOrWhiteSpace(title))
            return GeneralErrors.General.Empty(nameof(title));

        if (string.IsNullOrWhiteSpace(description))
            return GeneralErrors.General.Empty(nameof(description));

        return new Lesson(
            Guid.NewGuid(),
            courseId,
            title,
            description,
            type,
            releaseDate,
            allowDiscussion);
    }

    public void UpdateDetails(
        string title,
        string description,
        LessonType type)
    {
        Title = title;
        Description = description;
        Type = type;
    }

    public void Schedule(DateTime releaseDate)
    {
        ReleaseDate = releaseDate;
    }

    public void Publish()
    {
        Published = true;
    }

    public void Unpublish()
    {
        Published = false;
    }

    public void EnableDiscussion()
    {
        AllowDiscussion = true;
    }

    public void DisableDiscussion()
    {
        AllowDiscussion = false;
    }

    public Result AddFile(Guid fileId)
    {
        if (_fileIds.Contains(fileId))
            return LessonErrors.Lesson.FileAlreadyAttached;

        _fileIds.Add(fileId);

        return Result.Success();
    }

    public Result RemoveFile(Guid fileId)
    {
        if (!_fileIds.Remove(fileId))
            return LessonErrors.Lesson.FileNotFound;

        return Result.Success();
    }

    public Result AddVideo(Guid videoId)
    {
        if (_videoIds.Contains(videoId))
            return LessonErrors.Lesson.VideoAlreadyAttached;

        _videoIds.Add(videoId);

        return Result.Success();
    }

    public Result RemoveVideo(Guid videoId)
    {
        if (!_videoIds.Remove(videoId))
            return LessonErrors.Lesson.VideoNotFound;

        return Result.Success();
    }
}