using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Project.Model
{
    public class Department
    {
        public int Id { get; set; }
        [ForeignKey("Manager")]
        public int? User_ManagerId {  get; set; }
        public User? Manager { get; set; }
        public string Name { get; set; }
    }
}
