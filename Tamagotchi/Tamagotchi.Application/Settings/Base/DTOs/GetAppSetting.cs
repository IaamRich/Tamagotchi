﻿
namespace Tamagotchi.Application.Settings.Base.DTOs
{
    public class GetAppSetting
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public bool BoolValue { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}