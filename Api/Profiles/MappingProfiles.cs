using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos.Get.Block;
using Api.Dtos.Get.Notifications;
using Api.Dtos.Get.Person;
using Api.Dtos.Post.Block;
using Api.Dtos.Post.Notification;
using Api.Dtos.Post.Person;
using AutoMapper;
using Core.Entities.Block;
using Core.Entities.Notifications;
using Core.Entities.Person;

namespace Api.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Auditor, AuditorDto>()
        .ReverseMap();

        CreateMap<BlockChain, BlockChainDto>()
        .ReverseMap();
        /* Add Dto for request Post */
        CreateMap<BlockChain, BlockChainPDto>()
        .ReverseMap();

        CreateMap<FiledNumber, FiledNumberDto>()
        .ReverseMap();

        CreateMap<Formats, FormatsDto>()
        .ReverseMap();

        CreateMap<NotificationModule, NotificationModuleDto>()
        .ReverseMap();
        /* Add Dto for request Post */
        CreateMap<NotificationModule, NotificationModulePDto>()
        .ReverseMap();

        CreateMap<NotificationResponse, NotificationResponseDto>()
        .ReverseMap();

        CreateMap<NotificationStatus, NotificationStatusDto>()
        .ReverseMap();

        CreateMap<NotificationType, NotificationTypeDto>()
        .ReverseMap();

        CreateMap<RequirementType, RequirementTypeDto>()
        .ReverseMap();

        CreateMap<GenericPermissions, GenericPermissionsDto>()
        .ReverseMap();

        CreateMap<GenericSubModules, GenericSubModulesDto>()
        .ReverseMap();
        /* Add Dto for request Post */
        CreateMap<GenericSubModules, GenericSubModulesPDto>()
        .ReverseMap();

        CreateMap<Rol, RolDto>()
        .ReverseMap();

        CreateMap<RolTeacher, RolTeacherDto>()
        .ReverseMap();

        CreateMap<SubModules, SubModulesDto>()
        .ReverseMap();

        CreateMap<TeacherModule, TeacherModuleDto>()
        .ReverseMap();

        CreateMap<TeacherSubModule, TeacherSubModuleDto>()
        .ReverseMap();
        /* Add Dto for request Post */
        CreateMap<TeacherSubModule, TeacherSubModulePDto>()
        .ReverseMap();

    }
}