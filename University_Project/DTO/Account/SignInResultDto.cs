﻿namespace University_Project.DTO.Account
{
    public class SignInResultDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName {  get; set; }
        public List<string> Role {  get; set; }
        public int? Department {  get; set; }

    }
}
