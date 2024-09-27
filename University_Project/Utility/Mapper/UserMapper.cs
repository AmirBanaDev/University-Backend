using University_Project.DTO.User;
using University_Project.Model;

namespace University_Project.Utility.Mapper
{
    public static class UserMapper
    {
        public static User SignupDtoToUser(this SignUpDto admin, bool addPassword)
        {
            string? password = null;
            if (addPassword) password = admin.Password;
            return new User
            {
                DisplayName = admin.DisplayName,
                UserName = admin.UserName,
                IdCard = admin.IdCard,
                Position = admin.Position,
                DepartmentId = admin.DepartmentId,
                PhoneNumber = admin.PhoneNumber,
                PasswordHash = password
            };
        }
        public static GetUserResultDto UserToGetUserResultDto(this User user)
        {
            return new GetUserResultDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IdCard = user.IdCard,
                Position = user.Position,
                Department = user.Department?.Name,
                BirthDate = user.Birthdate,
                ProfilePicture = user.ProfilePicture,
                CourseAttendent = user.CourseAttendent
            };
        }
        public static User UpdateUserByAdminDtoToUser(this UpdateUserByAdminDto dto,User user)
        {
            user.DisplayName = dto.DisplayName ?? user.DisplayName;
            user.UserName = dto.UserName ?? user.UserName;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
            user.IdCard = dto.IdCard ?? user.IdCard;
            user.Position = dto.Position ?? user.Position;
            user.DepartmentId = dto.DepartmentId ?? user.DepartmentId;
            return user;
        }
    }
}
