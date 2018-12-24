using AutoMapper;
using DomainModels.Models;
using WebApi.Dto;

namespace WebApi.Configurators
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDto, User>();

            CreateMap<UserEditDto, User>();

            CreateMap<User, UserReturnDto>();

            CreateMap<BoardCreateDto, Board>();

            CreateMap<BoardEditDto, Board>();

            CreateMap<Board, BoardReturnDto>();

            CreateMap<TaskCreateDto, Task>();

            CreateMap<TaskEditDto, Task>();

            CreateMap<Task, TaskReturnDto>();

            CreateMap<NoteCreateDto, Note>();

            CreateMap<NoteEditDto, Note>();

            CreateMap<Note, NoteReturnDto>();

            CreateMap<SubtaskCreateDto, Subtask>();

            CreateMap<SubtaskEditDto, Subtask>();

            CreateMap<Subtask, SubtaskReturnDto>();

            CreateMap<ContactCreateDto, Contact>();

            CreateMap<Contact, ContactReturnDto>();

            CreateMap<ContactRequestCreateDto, ContactRequest>();

            CreateMap<ContactRequest, ContactRequestReturnDto>();

            CreateMap<ContactRequest, Contact>()
                .ForMember(contact => contact.FirstUserId,
                    opt => opt.MapFrom(request => request.SenderId))
                .ForMember(contact => contact.SecondUserId,
                    opt => opt.MapFrom(request => request.ReceiverId));
        }
    }
}
