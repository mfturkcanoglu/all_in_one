﻿namespace ApplicationCore.Dto.Response;

public class AuthResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}