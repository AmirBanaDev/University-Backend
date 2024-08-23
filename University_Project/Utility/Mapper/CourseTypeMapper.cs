using University_Project.DTO.CourseType;
using University_Project.Model;

namespace University_Project.Utility.Mapper
{
    public static class CourseTypeMapper
    {
        public static CourseType CourseTypeDtoToModel(this CourseTypeDto dto)
        {
            return new CourseType
            {
                Name = dto.Name,
            };
        }
        public static CourseType UpdateDtoToModel(this CourseTypeDto dto, CourseType item)
        {
            item.Name = dto.Name;
            return item;
        }
    }
}
