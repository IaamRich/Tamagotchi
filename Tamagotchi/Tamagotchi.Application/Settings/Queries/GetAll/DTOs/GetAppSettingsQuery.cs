﻿using MediatR;
using Tamagotchi.Application.Settings.Base.DTOs;

namespace Tamagotchi.Application.Settings.Queries.GetAll.DTOs
{
    public class GetAppSettingsQuery : IRequest<GetAppSetting>
    {
        public string Name { get; set; }
    }
}