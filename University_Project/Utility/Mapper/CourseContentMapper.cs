using University_Project.DTO.CourseContent;
using University_Project.Model;
using University_Project.Utility.PublicClasses;

namespace University_Project.Utility.Mapper
{
    public static class CourseContentMapper
    {
        public static GetContentDto ContentToGetDto(this CourseContent item)
        {
            return new GetContentDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                Files = item.File,
                CreatedAt = item.CreatedAt,
            };
        }

        public static CourseContent SendContentDtoToContent(this SendContentDto dto)
        {
            return new CourseContent
            {
                CourseId = dto.CourseId,
                Title = dto.Title,
                Description = dto.Description
            };
        }
        public static CourseContent UpdateSendDtoToCotent(this UpdateContentDto dto, CourseContent item)
        {
            item.Title = dto.Title;
            item.Description = dto.Description;
            return item;
        }
    }
}