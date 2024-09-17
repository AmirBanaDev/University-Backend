using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using University_Project.Data;
using University_Project.DTO.CourseContent;
using University_Project.Model;
using University_Project.Repository.Interface;
using University_Project.Utility.Mapper;
using University_Project.Utility.PublicClasses;

namespace University_Project.Repository.Impliment
{
    public class CourseContentRepository : ICourseContentRepository
    {
        AppDbContext _context;
        Uploader _uploader;
        public CourseContentRepository(AppDbContext context, Uploader uploader)
        {
            _context = context;
            _uploader = uploader;
        }
        public async Task<List<GetContentDto>?> GetByCourse(int courseId)
        {
            List<CourseContent> courseContents =  await _context.coursesContent.ToListAsync();
            IEnumerable<CourseContent> contentList = courseContents.Where(e => e.CourseId == courseId);
            if (contentList.IsNullOrEmpty()) return null;
            List<GetContentDto> result = contentList.Select(e=>e.ContentToGetDto()).ToList();
            return result;
        }
        public async Task<GetContentDto> Create(int courseId, SendContentDto dto)
        {
            CourseContent item = dto.SendContentDtoToContent();
            foreach(var file in dto.File)
            {
                item.File.Add(_uploader.UploadFile(file, "images\\courseContent\\" + courseId));
            }
            await _context.coursesContent.AddAsync(item);
            await _context.SaveChangesAsync();
            return item.ContentToGetDto();
        }
        public async Task<GetContentDto?> Update(int id, UpdateContentDto dto)
        {
            CourseContent? item = await _context.coursesContent.FirstOrDefaultAsync(e => e.Id == id);
            if (item == null) return null;
            item = dto.UpdateSendDtoToCotent(item);
            item.File.Clear();
            foreach(var file in dto.File)
            {
                item.File.Add(_uploader.UploadFile(file, "images\\courseContent\\" + item.CourseId));
            }
            _context.coursesContent.Update(item);
            await _context.SaveChangesAsync();
            return item.ContentToGetDto();
        }
        public async Task<bool> Delete(int id)
        {
            CourseContent? item = _context.coursesContent.FirstOrDefault(e => e.Id == id);
            if (item == null) return false;
            _context.coursesContent.Remove(item);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
