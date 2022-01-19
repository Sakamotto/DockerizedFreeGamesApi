using FluentValidation;
using System;
using System.Linq;

namespace DockerizedCrud.Requests
{
    public class PlatformRequest
    {
        public string Platform { get; set; }

        public PlatformRequest(string platform)
        {
            Platform = platform;
        }
    }

    public class PlatformRequestValidator : AbstractValidator<PlatformRequest>
    {
        public PlatformRequestValidator()
        {
            RuleFor(x => x.Platform).NotEmpty()
                .WithMessage("The platform parameter must be provided.");

            RuleFor(x => x.Platform).Must(BeValidOption).WithMessage("The provided platform option is not valid. Try pc, browser or all");
        }

        private bool BeValidOption(string platform)
        {
            string[] allowedPlatforms = new string[] { "pc", "browser", "all" };

            return allowedPlatforms.Any(x => string.Equals(x, platform, StringComparison.OrdinalIgnoreCase));
        }
    }
}
