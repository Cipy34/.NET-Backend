using RecipeBlog.Models;
using RecipeBlog.Models.DTOs;
using System.Drawing.Drawing2D;

namespace RecipeBlog.Services.PersonService
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetPersons(int PersonId);
        Task AddPerson(Person p);
        Task<IEnumerable<PersonDTO>> DisplayPersons();
        Task<PersonDTO> IdByPerson(int id);
    }
}