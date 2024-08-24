﻿using FluentValidation;

namespace CeoRankTask.Core.Dtos;

public class CeoRankRequestDto
{
    public string Keyword { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;
}

public class CeoRankRequestDtoValidator : AbstractValidator<CeoRankRequestDto>
{
    private const string UrlOptionalSchemeReg = @"^(http:\/\/|https:\/\/)?([a-zA-Z0-9-_]+\.)*[a-zA-Z0-9][a-zA-Z0-9-_]+(\.[a-zA-Z]{2,11})";

    public CeoRankRequestDtoValidator()
    {
        RuleFor(x => x.Keyword).NotEmpty();

        RuleFor(x => x.Url)
            .NotEmpty()
            .Matches(UrlOptionalSchemeReg)
                .WithMessage("Url is not valid.");
    }
}