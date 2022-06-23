using Hackathon.Application.DTOS.Activity;
using Hackathon.Application.DTOS.ClassRoom;
using Microsoft.AspNetCore.Http;
using Hackathon.Application.Params;

namespace Hackathon.Application.Interfaces.Services
{
    public interface IClassRoomService
    {
        Task<IEnumerable<ClassRoomResponse>> GetAsync(ClassRoomParams queryParams = null);
        Task<ClassRoomResponse> GetById(int id);
        Task<ClassRoomResponse> RegisterAsync(ClassRoomRequest classRoomRequest, int id);
        Task<ClassRoomResponse> UpdateAsync(int id, ClassRoomRequest classRoomRequest);
        Task<ClassRoomResponse> DeleteAsync(int id);
        Task<ActivityResponse> RegisterActivityAsync(int classRoomId, int instructorId, ActivityRequest activityRequest);
        Task<ActivityResponse> UpdateActivityAsync(int classRoomId,int activityId, int instructorId, ActivityRequest activityRequest);
        Task<ActivityResponse> DeleteActivityAsync(int classRoomId, int activityId, int instructorId);
        Task<ActivityResponse> RegisterFileActivity(int classRoomId, int activityId, int instructorId, List<IFormFile> files);
    }
}