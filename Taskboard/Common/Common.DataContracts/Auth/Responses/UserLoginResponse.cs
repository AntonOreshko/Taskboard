﻿using Common.DataContracts.Auth.Dto;

namespace Common.DataContracts.Auth.Responses
{
    public class UserLoginResponse: Response
    {
        public UserDto Data { get; set; }
    }
}
