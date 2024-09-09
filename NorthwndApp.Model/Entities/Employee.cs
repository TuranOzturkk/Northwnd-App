using Infrastructure.Model;

namespace NorthwndApp.Model.Entities
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public string ApprovingCode { get; set; }
        public byte[] Photo { get; set; }
    }
}
