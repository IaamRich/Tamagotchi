﻿namespace Tamagotchi.Web.Services.DTOs.OutPut
{
    public class PetFinderToken
    {
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string access_token { get; set; }
    }
}