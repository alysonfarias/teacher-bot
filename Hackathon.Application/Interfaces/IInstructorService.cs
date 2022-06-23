using Hackathon.Application.DTOS.Instructor;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Interfaces
{
    public interface IInstructorService : IUserService<Instructor, InstructorRequest, InstructorResponse>
    {
    }
}